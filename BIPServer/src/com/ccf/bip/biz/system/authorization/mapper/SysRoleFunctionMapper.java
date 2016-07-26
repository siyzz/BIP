package com.ccf.bip.biz.system.authorization.mapper;

public interface SysRoleFunctionMapper {
    int deleteByPrimaryKey(String relationId);

    int deleteByRoleId(String roleId);

    int insert(SysRoleFunction record);

    int insertSelective(SysRoleFunction record);

    SysRoleFunction selectByPrimaryKey(String relationId);

    int updateByPrimaryKeySelective(SysRoleFunction record);

    int updateByPrimaryKey(SysRoleFunction record);
}