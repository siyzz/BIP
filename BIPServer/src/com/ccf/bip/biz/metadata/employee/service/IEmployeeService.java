package com.ccf.bip.biz.metadata.employee.service;

import java.util.HashMap;
import java.util.List;

import com.ccf.bip.biz.metadata.employee.mapper.SysEmployee;

/*
 * @filename:IEmployeeService.java
 * Modification History:
 * Version         Author      Date     Description
 * --------------------------------------------------------------
 *  V1.0           siy    2016年6月16日     初版
 * 
 *
 * @Copyright CCF All Rights Reserved.
 */
public interface IEmployeeService {
	/**
	 * 按部门ID查找部门下所有员工
	 * @author siy
	 * @param orgId
	 * @return
	 * @throws 
	 * @version V1.0
	 */
	public List<SysEmployee> recursiveFindByOrgId(String orgId);

	/**
	 * 按组织ID获取组织下所有员工及帐号信息
	 * @param orgId
	 * @return
     */
	public List<HashMap<String,Object>> findWithAccount(String orgId);

	/**
	 * 根据岗位获取用户
	 * @param postId
	 * @return
     */
	List<HashMap<String,Object>> findByPostId(String postId);

	/**
	 * 修改员工信息
	 * @author siy
	 * @param employee
	 * @return
	 * @throws 
	 * @version V1.0
	 */
	public Integer update(SysEmployee employee);
	
	/**
	 * 添 加员工
	 * @author siy
	 * @param employee
	 * @return
	 * @throws 
	 * @version V1.0
	 */
	public Integer add(SysEmployee employee);
	
	/**
	 * 删除员工
	 * @author siy
	 * @param employeeIdArray
	 * @return
	 * @throws 
	 * @version V1.0
	 */
	public Integer delete(String[] employeeIdArray);

	/**
	 * 设置员工帐号
	 * @param params 1-员工ID,2-帐号，3-密码，4-是否有效
	 * @return
     */
	public Integer setAccount(String[] params);
}
