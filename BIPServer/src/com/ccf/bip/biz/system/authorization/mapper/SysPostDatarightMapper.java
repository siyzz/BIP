package com.ccf.bip.biz.system.authorization.mapper;

import java.util.HashMap;
import java.util.List;

public interface SysPostDatarightMapper {
    int deleteByPrimaryKey(String datarightId);

    int insert(SysPostDataright record);

    int insertSelective(SysPostDataright record);

    SysPostDataright selectByPrimaryKey(String datarightId);

    int updateByPrimaryKeySelective(SysPostDataright record);

    int updateByPrimaryKey(SysPostDataright record);

    List<HashMap<String,Object>> selectPostDataRightByFormId(String formId);

    List<HashMap<String,Object>> selectEmployeeDataRightByFormId(String formId);
}