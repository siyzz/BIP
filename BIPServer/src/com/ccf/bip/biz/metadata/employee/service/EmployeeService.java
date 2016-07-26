package com.ccf.bip.biz.metadata.employee.service;

import java.util.HashMap;
import java.util.List;

import javax.annotation.Resource;

import com.ccf.bip.framework.core.BipGuid;
import com.ccf.bip.framework.util.EncryptionUtil;
import com.ccf.bip.framework.util.StringUtil;
import org.apache.log4j.Logger;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;

import com.ccf.bip.biz.metadata.employee.mapper.SysEmployee;
import com.ccf.bip.biz.metadata.employee.mapper.SysEmployeeMapper;
import com.ccf.bip.biz.system.user.mapper.SysUser;
import com.ccf.bip.biz.system.user.mapper.SysUserMapper;
import com.ccf.bip.framework.core.BipException;

/*
 * @filename:EmployeeService.java
 * Modification History:
 * Version         Author      Date     Description
 * --------------------------------------------------------------
 *  V1.0           siy    2016年6月16日     初版
 * 
 *
 * @Copyright CCF All Rights Reserved.
 */
@Service("employeeService")
public class EmployeeService implements IEmployeeService {
	private static final Logger logger = Logger.getLogger(EmployeeService.class);
	@Resource
	private SysEmployeeMapper mapper;
	@Resource
	private SysUserMapper userMapper;

	public List<SysEmployee> recursiveFindByOrgId(String orgId) {
		// TODO Auto-generated method stub
		return mapper.recursiveSelectByOrgId(orgId);
	}
	
	public List<HashMap<String, Object>> recursiveSingleFindByOrgId(String orgId) {
		// TODO Auto-generated method stub
		return mapper.recursiveSingleSelectByOrgId(orgId);
	}

	@Override
	public List<HashMap<String, Object>> findWithAccount(String orgId) {
		return mapper.selectWithAccount(orgId);
	}

	@Override
	public List<HashMap<String,Object>> findByPostId(String postId) {
		return mapper.selectByPostId(postId);
	}

	public Integer update(SysEmployee employee) {
		// TODO Auto-generated method stub
		return mapper.updateByPrimaryKeySelective(employee);
	}

	public Integer add(SysEmployee employee) {
		// TODO Auto-generated method stub
		return mapper.insertSelective(employee);
	}

	@Transactional
	public Integer delete(String[] employeeIdArray) {
		// TODO Auto-generated method stub
		int ret = 0;
		if(employeeIdArray != null && employeeIdArray.length > 0){
			for(int i = 0; i < employeeIdArray.length; i++){
				//查询是否有帐号
				List<SysUser> userList = userMapper.selectByEmployeeId(employeeIdArray[i]);
				if(userList != null && userList.size() > 0)
					throw new BipException("被删除的员工已绑定系统帐号，请先注销帐号后再进行删除！");
				ret += mapper.deleteByPrimaryKey(employeeIdArray[i]);
			}
		}
		return ret;
	}

	@Override
	@Transactional
	public Integer setAccount(String[] params) {
		int count = 0;
		String userId = userMapper.selectUserIdByEmployeeId(params[0]);
		SysUser user = null;
		if(StringUtil.isNotEmpty(userId)){
			//update
			user = userMapper.selectByPrimaryKey(userId);
			user.setUserAccount(params[1]);
			if(StringUtil.isNotEmpty(params[2])){
				user.setUserPassword(EncryptionUtil.MD5(params[2]));
			}
			user.setValid(params[3]);
			count = userMapper.updateByPrimaryKeySelective(user);
		}
		else{
			//insert
			user = new SysUser();
			user.setUserId(BipGuid.getGuid());
			user.setEmployeeId(params[0]);
			user.setUserAccount(params[1]);
			if(StringUtil.isEmpty(params[2])){
				logger.warn("新增帐号请输入初始密码！");
				throw  new BipException("新增帐号请输入初始密码！");
			}
			user.setUserPassword(EncryptionUtil.MD5(params[2]));
			user.setValid(params[3]);
			count = userMapper.insertSelective(user);
		}
		return count;
	}
}
