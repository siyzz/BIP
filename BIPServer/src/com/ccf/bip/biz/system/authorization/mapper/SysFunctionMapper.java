package com.ccf.bip.biz.system.authorization.mapper;

import java.util.List;

public interface SysFunctionMapper {
    int deleteByPrimaryKey(String functionId);
    
    int deleteByParentId(String parentId);

    int insert(SysFunction record);

    int insertSelective(SysFunction record);

    SysFunction selectByPrimaryKey(String functionId);
    
    List<SysFunction> selectBySuperAdmin();
    
    List<SysFunction> selectButtonList(String parentId);

    int updateByPrimaryKeySelective(SysFunction record);

    int updateByPrimaryKey(SysFunction record);
    
    int hasChildren(String parentId);
    
    int updateButton(SysFunction record);
}