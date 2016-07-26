package com.ccf.bip.biz.system.authorization.service;

import java.util.ArrayList;
import java.util.List;

import javax.annotation.Resource;

import com.ccf.bip.biz.system.authorization.mapper.*;
import com.ccf.bip.framework.core.BipGuid;
import org.apache.log4j.Logger;
import org.springframework.stereotype.Service;

import org.springframework.transaction.annotation.Transactional;

/*
 * @filename:RoleService.java
 * Modification History:
 * Version         Author      Date     Description
 * --------------------------------------------------------------
 *  V1.0           siy    2016年6月20日     初版
 * 
 *
 * @Copyright CCF All Rights Reserved.
 */
@Service("roleService")
public class RoleService implements IRoleService {
	private static final Logger logger = Logger.getLogger(RoleService.class);
	@Resource
	private SysRoleMapper mapper;
	@Resource
	private SysRoleFunctionMapper roleFunctionMapper;
	@Resource
	private SysFunctionMapper functionMapper;

	public List<SysRole> findAll() {
		// TODO Auto-generated method stub
		return mapper.selectAll();
	}

	public Integer add(SysRole role) {
		// TODO Auto-generated method stub
		return mapper.insertSelective(role);
	}

	public Integer update(SysRole role) {
		// TODO Auto-generated method stub
		return mapper.updateByPrimaryKeySelective(role);
	}

	public Integer delete(String roleId) {
		// TODO Auto-generated method stub
		return null;
	}

	public List<SysFunction> findAuthor(String roleId) {
		return functionMapper.selectAuthor(roleId);
	}

	@Transactional
	public Integer authorize(String roleId, ArrayList<SysFunction> functionList) {
		//删除原授权
		roleFunctionMapper.deleteByRoleId(roleId);
		
		logger.debug(roleId);
		//添加新授权
		SysRoleFunction roleFunction = null;
		for (int i = 0; i < functionList.size(); i++) {
			SysFunction fun = functionList.get(i);
			roleFunction = new SysRoleFunction();
			roleFunction.setRelationId(BipGuid.getGuid());
			roleFunction.setRoleId(roleId);
			roleFunction.setFunctionId(fun.getFunctionId());
			roleFunction.setParentFunctionId(fun.getParentId());
			roleFunction.setFunctionSeq(fun.getSeq());
			roleFunctionMapper.insert(roleFunction);
		}
		return 0;
	}
}
