package com.ccf.bip.biz.system.update.service;

import com.ccf.bip.biz.system.update.mapper.FileVersion;
import com.ccf.bip.framework.server.file.FileInfo;

import java.util.List;

/**
 * 程序自动更新类
 * Created by siy on 2016/7/11.
 */
public interface IProgramUpdateService {
	/**
	 * 获取服务器文件版 本列表
	 * @return
	 */
    List<FileVersion> findFileVersionList();
    
    /**
     * 更新服务器文件版本列表
     * @param fileVersionList
     * @return
     */
    Integer updateFileVersionList(List<FileVersion> fileVersionList);
    
    /**
     * 下载程序文件
     * @param fileName
     * @return
     */
    FileInfo download(String fileName);
    
    /**
     * 上传程序文件
     * @param fileInfo
     * @return
     */
    Integer upload(FileInfo fileInfo);
}
