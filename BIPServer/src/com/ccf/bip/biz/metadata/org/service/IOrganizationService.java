package com.ccf.bip.biz.metadata.org.service;

import java.util.List;
import com.ccf.bip.biz.metadata.org.mapper.SysOrganization;;
/*
 * 结组结构管理服务类
 * @filename:IOrganizationService.java
 * Modification History:
 * Version         Author      Date     Description
 * --------------------------------------------------------------
 *  V1.0           siy    2016年6月6日     初版
 * 
 *
 * @Copyright CCF All Rights Reserved.
 */
public interface IOrganizationService {
	/**
	 * 获取全部组织机构
	 * @author siy
	 * @return
	 * @throws 
	 * @version V1.0
	 */
	public List<SysOrganization> findAll();
	
	/**
	 * 根据下级所有组织机构
	 * @author siy
	 * @param organization
	 * @return
	 * @throws 
	 * @version V1.0
	 */
	public List<SysOrganization> findByParent(String parentId);
	
	/**
	 * 添加组织
	 * @author siy
	 * @param organization
	 * @return
	 * @throws 
	 * @version V1.0
	 */
	public Integer add(SysOrganization organization);
	
	/**
	 * 修改组织
	 * @author siy
	 * @param organization
	 * @return
	 * @throws 
	 * @version V1.0
	 */
	public Integer update(SysOrganization organization);
	
	/**
	 * 删除组织
	 * @author siy
	 * @param organizationId
	 * @return
	 * @throws 
	 * @version V1.0
	 */
	public Integer delete(String organizationId);
	
	/**
	 * 删除组织
	 * @author siy
	 * @param organizationIdArray
	 * @return
	 * @throws 
	 * @version V1.0
	 */
	public Integer delete(String[] organizationIdArray);
}
