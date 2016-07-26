package com.ccf.bip.biz.system.update.mapper;

import java.util.List;

import org.apache.ibatis.annotations.Param;

public interface FileVersionMapper {
    int deleteByPrimaryKey(String programVersionId);

    int insert(FileVersion record);

    int insertSelective(FileVersion record);

    FileVersion selectByPrimaryKey(String programVersionId);
    
    List<FileVersion> selectAll();
    
    FileVersion selectByFileName(@Param("directory")String diretory,@Param("fileName")String fileName);

    int updateByPrimaryKeySelective(FileVersion record);

    int updateByPrimaryKey(FileVersion record);
}