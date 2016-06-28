package com.ccf.bip.biz.system.authorization.service;

import java.util.List;

import javax.annotation.Resource;

import com.ccf.bip.biz.system.authorization.mapper.SysPost;
import com.ccf.bip.biz.system.authorization.mapper.SysPostMapper;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;

import com.ccf.bip.biz.system.authorization.mapper.SysFunction;
import com.ccf.bip.biz.system.authorization.mapper.SysFunctionMapper;
import com.ccf.bip.biz.system.user.mapper.SysUser;
import com.ccf.bip.framework.core.BipException;
import com.ccf.bip.framework.util.StringUtil;

/*
 * @filename:FunctionService.java
 * Modification History:
 * Version         Author      Date     Description
 * --------------------------------------------------------------
 *  V1.0           siy    2016年5月30日     初版
 * 
 *
 * @Copyright CCF All Rights Reserved.
 */
@Service("functionService")
public class FunctionService implements IFunctionService {
	@Resource
	private SysFunctionMapper mapper;

	@Transactional
	public Integer add(SysFunction function) {
		int ret = mapper.insertSelective(function);
		if(function.getFunctionType().equals("1014") && function.getButtonList() != null){
			for(int i = 0;i < function.getButtonList().size();i++){
				ret += mapper.insertSelective(function.getButtonList().get(i));
			}
		}
		return ret;
	}

	@Transactional
	public Integer delete(String functionId) {
		int ret = 0;
		SysFunction function = mapper.selectByPrimaryKey(functionId);
		if(function.getFunctionType().equals("1014")){
			//删除按钮
			ret += mapper.deleteByParentId(functionId);
		}
		else{
			//如果有子项，抛出异常
			if(mapper.hasChildren(functionId) > 0){
				throw new BipException("请先删除下级节点");
			}
		}
		ret += mapper.deleteByPrimaryKey(functionId);
		
		return ret;
	}

	@Transactional
	public Integer update(SysFunction function) {
		int ret = mapper.updateByPrimaryKeySelective(function);
		if(function.getFunctionType().equals("1014") && function.getButtonList() != null){
			int btnCount = function.getButtonList().size();
			String[] btnIdArray = new String[btnCount];
			for(int i = 0; i < btnCount; i++){
				SysFunction btn = function.getButtonList().get(i);
				btnIdArray[i] = btn.getFunctionId();
				if(StringUtil.isNotEmpty(btn.getParentId())){//修改现有按钮
					ret += mapper.updateButton(btn);
				}
				else{
					btn.setParentId(function.getFunctionId());//插入新增按钮
					ret += mapper.insertSelective(btn);
				}
			}
			//删除不存在按钮
			List<SysFunction> btnList = mapper.selectButtonList(function.getFunctionId());
			String btnIds = StringUtil.join(btnIdArray, "-");
			for(int i = 0; i < btnList.size();i++){
				SysFunction tmpBtn = btnList.get(i);
				if(btnIds.contains(tmpBtn.getFunctionId())){
					continue;
				}
				ret += mapper.deleteByPrimaryKey(tmpBtn.getFunctionId());
			}
		}
		
		return ret;
	}

	public Integer moveBefore(String functionId, String destId) {
		return null;
	}

	public Integer moveAfter(String functionId, String destId) {
		// TODO Auto-generated method stub
		return null;
	}

	public List<SysFunction> findFunctionListByUser(SysUser user) {
		List<SysFunction> list = null;
		if(user.getSuperAdmin().equals("1")){
			list = mapper.selectBySuperAdmin();
		}
		else{
			list = mapper.selectByUser(user.getEmployeeId());
		}
		
		return list;
	}

	public List<SysFunction> findButtonList(String formFunctionId) {
		// TODO Auto-generated method stub
		return mapper.selectButtonList(formFunctionId);
	}

	public List<SysFunction> findFunctionList() {
		// TODO Auto-generated method stub
		return mapper.selectAll();
	}

}
