package com.ccf.bip.biz.metadata.org.service;

import java.util.List;

import javax.annotation.Resource;

import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;

import com.ccf.bip.biz.metadata.org.mapper.SysOrganization;
import com.ccf.bip.biz.metadata.org.mapper.SysOrganizationMapper;

/*
 * @filename:OrganizationService.java
 * Modification History:
 * Version         Author      Date     Description
 * --------------------------------------------------------------
 *  V1.0           siy    2016年6月6日     初版
 * 
 *
 * @Copyright CCF All Rights Reserved.
 */
@Service("organizationService")
public class OrganizationService implements IOrganizationService {
	@Resource
	private SysOrganizationMapper mapper;
	
	public List<SysOrganization> findAll() {
		// TODO Auto-generated method stub
		return mapper.findAll();
	}

	public List<SysOrganization> findByParent(String parentId) {
		// TODO Auto-generated method stub
		return mapper.findByParent(parentId);
	}

	public Integer add(SysOrganization organization) {
		// TODO Auto-generated method stub
		return mapper.insertSelective(organization);
	}

	public Integer update(SysOrganization organization) {
		// TODO Auto-generated method stub
		return mapper.updateByPrimaryKeySelective(organization);
	}

	public Integer delete(String organizationId) {
		// TODO Auto-generated method stub
		return mapper.deleteByPrimaryKey(organizationId);
	}

	@Transactional
	public Integer delete(String[] organizationIdArray) {
		// TODO Auto-generated method stub
		Integer ret = 0;
		for(int i = 0; i < organizationIdArray.length;i++){
			ret += mapper.deleteByPrimaryKey(organizationIdArray[i]);
		}
		return ret;
	}

}
