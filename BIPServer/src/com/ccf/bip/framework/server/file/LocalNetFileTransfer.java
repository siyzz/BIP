package com.ccf.bip.framework.server.file;

import com.ccf.bip.framework.core.BipException;
import com.ccf.bip.framework.core.Globals;
import com.ccf.bip.framework.util.FileUtil;
import com.ccf.bip.framework.util.StringUtil;
import org.apache.log4j.Logger;

import java.io.File;
import java.util.ArrayList;
import java.util.List;

/**
 * 服务器本地存储上传下载服务
 * Created by siy on 2016/7/5.
 */
public class LocalNetFileTransfer implements INetFileTransfer {
    private static final Logger logger = Logger.getLogger(LocalNetFileTransfer.class);
    @Override
    public Integer upload(ArrayList<FileInfo> fileList) {
        int count = 0;
        if(fileList != null && fileList.size() > 0){
            for (int i = 0;i < fileList.size(); i++){
                FileUtil.getFile(fileList.get(i).getContent(),Globals.LOCAL_DIR+fileList.get(i).getDirectory(),fileList.get(i).getName());
            }
        }
        else{
        	logger.warn("没有需要上传的文件！");
            throw new BipException("没有需要上传的文件！");
        }
        return count;
    }

    @Override
    public List<FileInfo> download(String fileName) {
        List<FileInfo> fileInfoList = new ArrayList<FileInfo>();
        FileInfo fileInfo = null;
        if(StringUtil.isNotEmpty(fileName)){
            File file = new File(Globals.LOCAL_DIR + fileName);
            if(file.exists()){
                if(file.isDirectory()){
                    File[] files = file.listFiles();
                    for (int i = 0;i < files.length;i++){
                        fileInfo = new FileInfo();
                        fileInfo.setDirectory(FileUtil.getPath(files[i].getAbsolutePath()));
                        fileInfo.setName(files[i].getName());
                        fileInfo.setContent(FileUtil.getBytes(files[i].getAbsolutePath()));
                        fileInfoList.add(fileInfo);
                    }
                }
                else if(file.isFile()){
                    fileInfo = new FileInfo();
                    fileInfo.setDirectory(FileUtil.getPath(file.getAbsolutePath()));
                    fileInfo.setName(file.getName());
                    fileInfo.setContent(FileUtil.getBytes(file.getAbsolutePath()));
                    fileInfoList.add(fileInfo);
                }
            }
        }
        else{
            throw new BipException("没有需要下载的文件或路径！");
        }
        return fileInfoList;
    }
}
