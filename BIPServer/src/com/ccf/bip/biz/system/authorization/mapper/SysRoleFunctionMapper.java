package com.ccf.bip.biz.system.authorization.mapper;

import java.util.List;

public interface SysRoleFunctionMapper {
    int deleteByPrimaryKey(String relationId);

    int deleteByRoleId(String roleId);

    int insert(SysRoleFunction record);

    int insertSelective(SysRoleFunction record);

    SysRoleFunction selectByPrimaryKey(String relationId);

    int updateByPrimaryKeySelective(SysRoleFunction record);

    int updateByPrimaryKey(SysRoleFunction record);
}