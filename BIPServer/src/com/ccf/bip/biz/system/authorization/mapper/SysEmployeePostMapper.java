package com.ccf.bip.biz.system.authorization.mapper;

public interface SysEmployeePostMapper {
    int deleteByPrimaryKey(String employeePostId);
    
    int deleteByEmployeePost(SysEmployeePost record);

    int insert(SysEmployeePost record);

    int insertSelective(SysEmployeePost record);

    SysEmployeePost selectByPrimaryKey(String employeePostId);
    
    SysEmployeePost selectByEmployeePost(SysEmployeePost record);

    int updateByPrimaryKeySelective(SysEmployeePost record);

    int updateByPrimaryKey(SysEmployeePost record);
}