package com.ccf.bip.framework.server.file;

import com.ccf.bip.framework.core.BipException;
import com.ccf.bip.framework.util.StringUtil;
import org.apache.commons.net.ftp.FTPFile;
import org.apache.log4j.Logger;

import java.util.ArrayList;
import java.util.List;

/**
 * FTP存储上传下载服务
 * Created by siy on 2016/7/5.
 */
public class FtpNetFileTransfer implements INetFileTransfer {
    private static final Logger logger = Logger.getLogger(FtpNetFileTransfer.class);
    @Override
    public Integer upload(ArrayList<FileInfo> fileList) {
        int count = 0;
        if(fileList != null && fileList.size() > 0){
            BipFtpClient ftpClient = BipFtpClient.newInstance();
            try {
                ftpClient.open();
                try {
                    for (int i = 0; i < fileList.size(); i++) {
                        ftpClient.upload(fileList.get(i).getContent(),
                                fileList.get(i).getName(), fileList.get(i)
                                        .getDirectory());
                        count++;
                    }
                }
                catch (Exception ex) {
                    logger.error(ex.getMessage());
                    try {
                        int size = count;
                        for (int i = 0; i < size; i++) {
                            ftpClient.deleteFile(fileList.get(i).getFullName());
                            count--;
                        }
                    }
                    catch (Exception ex1) {
                        logger.error(ex1.getMessage());
                    }
                }
            }
            catch (Exception ex) {
                logger.error(ex.getMessage());
            }
            finally {
                if (ftpClient.isConnected()) {
                    try {
                        ftpClient.close();
                    }
                    catch (Exception e) {
                        // TODO Auto-generated catch block
                        logger.error(e.getMessage());
                    }
                }
            }
        }
        else{
            throw new BipException("没有需要上传的文件！");
        }
        return count;
    }

    @Override
    public List<FileInfo> download(String fileName) {
        List<FileInfo> fileList = new ArrayList<FileInfo>();
        BipFtpClient ftpClient = BipFtpClient.newInstance();
        if(StringUtil.isNotEmpty(fileName)) {
            try {
                ftpClient.open();
                String path = "";
                FTPFile[] files = ftpClient.listFiles(fileName);
                if (files != null && files.length > 0) {
                    if (ftpClient.isPath(fileName)) {
                        path = fileName;
                    } else {
                        String[] args = fileName.split("/");
                        if (args.length > 1) {
                            path = fileName.substring(0, fileName.length()
                                    - (args[args.length - 1].length() + 1));
                        }
                    }

                    for (FTPFile ff : files) {
                        if (ff.isFile()) {
                            FileInfo file = new FileInfo();
                            byte[] content = ftpClient.download(path + "/" + ff.getName());
                            file.setContent(content);
                            file.setName(new String(ff.getName().getBytes(
                                    ftpClient.getEncoding()), "gb2312"));
                            file.setDirectory(path);
                            logger.debug(file.getName() + "   "
                                    + file.getContent().length);
                            fileList.add(file);
                        }
                    }
                }
            } catch (Exception ex) {
                logger.error(ex.getMessage());
            } finally {
                if (ftpClient.isConnected()) {
                    try {
                        ftpClient.close();
                    } catch (Exception e) {
                        logger.error(e.getMessage());
                    }
                }
            }
        }
        else{
            throw new BipException("没有需要下载的文件或路径！");
        }

        return fileList;
    }
}
