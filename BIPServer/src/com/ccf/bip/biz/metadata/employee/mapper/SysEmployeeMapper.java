package com.ccf.bip.biz.metadata.employee.mapper;

import java.util.List;

public interface SysEmployeeMapper {
    int deleteByPrimaryKey(String employeeId);

    int insert(SysEmployee record);

    int insertSelective(SysEmployee record);

    SysEmployee selectByPrimaryKey(String employeeId);
    
    List<SysEmployee> recursiveSelectByOrgId(String orgId);

    int updateByPrimaryKeySelective(SysEmployee record);

    int updateByPrimaryKeyWithBLOBs(SysEmployee record);

    int updateByPrimaryKey(SysEmployee record);
}