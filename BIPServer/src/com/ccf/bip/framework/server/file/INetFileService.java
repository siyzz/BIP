package com.ccf.bip.framework.server.file;

import java.util.ArrayList;
import java.util.List;

/**
 * Created by siy on 2016/7/7.
 */
public interface INetFileService {
    /**
     * 文件上传,支持同时上传多个文件
     * @param files FileInfo数组
     * @return
     */
    Integer upload(ArrayList<FileInfo> files);

    /**
     * 文件下载，支持按文件或文件夹下载
     * @param fileName
     * @return
     */
    List<FileInfo> download(String fileName);
}
