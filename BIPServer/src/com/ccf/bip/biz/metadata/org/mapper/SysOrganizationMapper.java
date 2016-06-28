package com.ccf.bip.biz.metadata.org.mapper;

import java.util.List;

public interface SysOrganizationMapper {
    int deleteByPrimaryKey(String organizationId);

    int insert(SysOrganization record);

    int insertSelective(SysOrganization record);
    
    List<SysOrganization> findAll();
    
    List<SysOrganization> findByParent(String parentId);

    SysOrganization selectByPrimaryKey(String organizationId);

    int updateByPrimaryKeySelective(SysOrganization record);

    int updateByPrimaryKey(SysOrganization record);
}