package com.ccf.bip.biz.system.authorization.mapper;

public interface SysEmployeePostMapper {
    int deleteByPrimaryKey(String employeePostId);

    int insert(SysEmployeePost record);

    int insertSelective(SysEmployeePost record);

    SysEmployeePost selectByPrimaryKey(String employeePostId);

    int updateByPrimaryKeySelective(SysEmployeePost record);

    int updateByPrimaryKey(SysEmployeePost record);
}