package com.ccf.bip.biz.system.user.mapper;

import java.util.List;

public interface SysUserMapper {
    int deleteByPrimaryKey(String userId);

    int insert(SysUser record);

    int insertSelective(SysUser record);

    SysUser selectByPrimaryKey(String userId);

    int updateByPrimaryKeySelective(SysUser record);

    int updateByPrimaryKey(SysUser record);
    
    SysUser selectByLogin(SysUser record);
    
    List<SysUser> selectByEmployeeId(String employeeId);
}