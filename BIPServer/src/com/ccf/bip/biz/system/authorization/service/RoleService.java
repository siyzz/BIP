package com.ccf.bip.biz.system.authorization.service;

import java.util.List;

import javax.annotation.Resource;

import org.springframework.stereotype.Service;

import com.ccf.bip.biz.system.authorization.mapper.SysRole;
import com.ccf.bip.biz.system.authorization.mapper.SysRoleMapper;

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
	@Resource
	private SysRoleMapper mapper;

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

	public Integer authorize(String[] functionIdArray) {
		// TODO Auto-generated method stub
		return null;
	}

}
