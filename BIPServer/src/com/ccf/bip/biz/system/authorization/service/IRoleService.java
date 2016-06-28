package com.ccf.bip.biz.system.authorization.service;

import java.util.ArrayList;
import java.util.List;

import com.ccf.bip.biz.system.authorization.mapper.SysFunction;
import com.ccf.bip.biz.system.authorization.mapper.SysRole;
/*
 * @filename:IRoleService.java
 * Modification History:
 * Version         Author      Date     Description
 * --------------------------------------------------------------
 *  V1.0           siy    2016年6月20日     初版
 * 
 *
 * @Copyright CCF All Rights Reserved.
 */
public interface IRoleService {
	/**
	 * 获取所有角色
	 * @author siy
	 * @return
	 * @throws 
	 * @version V1.0
	 */
	public List<SysRole> findAll();
	/**
	 * 增加角色
	 * @author siy
	 * @param role
	 * @return
	 * @throws 
	 * @version V1.0
	 */
	public Integer add(SysRole role);
	/**
	 * 修改角色
	 * @author siy
	 * @param role
	 * @return
	 * @throws 
	 * @version V1.0
	 */
	public Integer update(SysRole role);
	/**
	 * 删除角色
	 * @author siy
	 * @param roleId
	 * @return
	 * @throws 
	 * @version V1.0
	 */
	public Integer delete(String roleId);

	/**
	 * 获取授权功能
	 * @param roleId
	 * @return
     */
	public List<SysFunction> findAuthor(String roleId);
	/**
	 * 角色授权	
	 * @author siy
	 * @param functionList
	 * @return
	 * @throws 
	 * @version V1.0
	 */
	public Integer authorize(String roleId, ArrayList<SysFunction> functionList);
}
