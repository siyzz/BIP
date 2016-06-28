package com.ccf.bip.biz.metadata.dictionary.mapper;

import java.util.List;

public interface SysDictionaryMapper {
    int deleteByPrimaryKey(String dictionaryId);

    int insert(SysDictionary record);

    int insertSelective(SysDictionary record);

    SysDictionary selectByPrimaryKey(String dictionaryId);
    
    List<SysDictionary> selectByParentCode(String parentCode);

    int updateByPrimaryKeySelective(SysDictionary record);

    int updateByPrimaryKey(SysDictionary record);
}