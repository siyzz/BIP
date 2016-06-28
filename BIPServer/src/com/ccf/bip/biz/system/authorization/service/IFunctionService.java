package com.ccf.bip.biz.system.authorization.service;

import java.util.List;

import com.ccf.bip.biz.system.authorization.mapper.SysFunction;
import com.ccf.bip.biz.system.user.mapper.SysUser;

/*
 * 功能菜单配置业务处理类
 * @filename:FunctionService.java
 * Modification History:
 * Version         Author      Date     Description
 * --------------------------------------------------------------
 *  V1.0           siy    2016年5月30日     初版
 * 
 *
 * @Copyright CCF All Rights Reserved.
 */
public interface IFunctionService {
	/**
	 * 新增功能项
	 * @author siy
	 * @param function
	 * @return
	 * @throws 
	 * @version V1.0
	 */
	public Integer add(SysFunction function);
	
	/**
	 * 删除功能
	 * @author siy
	 * @param functionId
	 * @return
	 * @throws 
	 * @version V1.0
	 */
	public Integer delete(String functionId);
	
	/**
	 * 修改功能
	 * @author siy
	 * @param function
	 * @return
	 * @throws 
	 * @version V1.0
	 */
	public Integer update(SysFunction function);
	
	/**
	 * 移动功能至另一功能前
	 * @author siy
	 * @param functionId
	 * @param destId
	 * @return
	 * @throws 
	 * @version V1.0
	 */
	public Integer moveBefore(String functionId,String destId);
	
	/**
	 * 移动功能至另一功能后
	 * @author siy
	 * @param functionId
	 * @param destId
	 * @return
	 * @throws 
	 * @version V1.0
	 */
	public Integer moveAfter(String functionId,String destId);
	
	/**
	 * 按用户获取功能菜单
	 * @author siy
	 * @param user
	 * @return
	 * @throws 
	 * @version V1.0
	 */
	public List<SysFunction> findFunctionListByUser(SysUser user);
	
	/**
	 * 获取全部功能菜单
	 * @author siy
	 * @return
	 * @throws 
	 * @version V1.0
	 */
	public List<SysFunction> findFunctionList();
	
	/**
	 * 按窗体ID查找功能按钮列表
	 * @author siy
	 * @param formFunctionId
	 * @return
	 * @throws 
	 * @version V1.0
	 */
	public List<SysFunction> findButtonList(String formFunctionId);
}
