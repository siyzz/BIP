package com.ccf.bip.biz.system.authorization.mapper;

import java.util.List;

public interface SysPostMapper {
    int deleteByPrimaryKey(String postId);

    int insert(SysPost record);

    int insertSelective(SysPost record);

    SysPost selectByPrimaryKey(String postId);

    List<SysPost> selectByEmployeeId(String employeeId);

    List<SysPost> selectByOrganizationId(String postOrgId);

    int updateByPrimaryKeySelective(SysPost record);

    int updateByPrimaryKey(SysPost record);
}