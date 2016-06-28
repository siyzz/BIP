package com.ccf.bip.framework.util;

import java.io.File;
import java.io.FileInputStream;
import java.io.FileOutputStream;
import java.io.IOException;
import java.io.InputStream;
import java.io.InputStreamReader;
import java.io.Reader;
import java.nio.channels.FileChannel;

/*
 * 文件处理工具类
 * @filename:FileUtil.java
 * Modification History:
 * Version         Author      Date     Description
 * --------------------------------------------------------------
 *  V1.0           siy    2016-5-19     初版
 * 
 *
 * @Copyright CCF All Rights Reserved.
 */
public class FileUtil {
    private final static int MB = 1048576;

    /**
     * 设置文件可写
     * @author siy
     * @param fileName
     * @throws
     * @version V1.0
     */
    public static void setWritable(String fileName) {
        File f = new File(fileName);
        if (f.exists() && f.canRead() && !f.canWrite()) {
            f.setWritable(true);
        }
    }

    /**
     * 设置文件只读
     * @author siy
     * @param fileName
     * @throws
     * @version V1.0
     */
    public static void setReadonly(String fileName) {
        File f = new File(fileName);
        if (f.exists() && f.canRead() && f.canWrite()) {
            f.setWritable(false);
        }
    }

    /**
     * 获取文件扩展名
     * @author siy
     * @param fileName
     * @return
     * @throws
     * @version V1.0
     */
    public static String getExtName(String fileName) {
        return StringUtil.isNotEmpty(fileName) ? fileName.substring(fileName
                .lastIndexOf('.') + 1) : "";
    }

    /**
     * 获取文件目录
     * @author siy
     * @param fileAbsoluteName
     * @return
     * @throws
     * @version V1.0
     */
    public static String getPath(String fileAbsoluteName) {
        String path = "";
        if (StringUtil.isNotEmpty(fileAbsoluteName)) {
            int pos = Math.max(fileAbsoluteName.lastIndexOf('\\'),
                    fileAbsoluteName.lastIndexOf('/'));
            path = pos != -1 ? fileAbsoluteName.substring(0, pos + 1) : "";
        }
        return path;
    }

    /**
     * 获取文件夹下所有文件名
     * @author siy
     * @param filePath
     * @return
     * @throws
     * @version V1.0
     */
    public static String[] getFileNames(String filePath) {
        String[] names = new String[0];
        if (StringUtil.isNotEmpty(filePath)) {
            File file = new File(filePath);
            if (!file.isFile()) {
                names = file.list();
            }
        }
        return names;
    }

    /**
     * 从绝对路径中获取文件名
     * @author siy
     * @param fileAbsoluteName
     * @return
     * @throws
     * @version V1.0
     */
    public static String getFileName(String fileAbsoluteName) {
        String fileName = "";
        if (StringUtil.isNotEmpty(fileAbsoluteName)) {
            int pos = Math.max(fileAbsoluteName.lastIndexOf('\\'),
                    fileAbsoluteName.lastIndexOf('/'));
            fileName = pos != -1 ? fileAbsoluteName.substring(pos) + 1
                    : fileAbsoluteName;
        }
        return fileName;
    }

    /**
     * 从输入流获取字符串
     * @author siy
     * @param is
     * @return
     * @throws java.io.IOException
     * @throws
     * @version V1.0
     */
    public final static String getTextFromInputStream(InputStream is)
            throws java.io.IOException {
        StringBuffer buf = new StringBuffer();
        if (is != null) {
            is.reset();
            Reader reader = new InputStreamReader(is);
            int c = 0;
            while (true) {
                c = reader.read();
                if (c == 0)
                    break;
                buf.append((char) c);
            }
        }
        return buf.toString();
    }

    /**
     * 判断文件是否在文件夹下
     * @author siy
     * @param filePath
     * @param fileName
     * @return
     * @throws
     * @version V1.0
     */
    public static boolean isFileExist(String filePath, String fileName) {
        return StringUtil.isNotEmpty(filePath)
                && StringUtil.isNotEmpty(fileName)
                && new File(
                        (filePath.endsWith("/") || filePath.endsWith("\\")) ? filePath
                                + fileName
                                : filePath + File.separator + fileName)
                        .exists();
    }

    /**
     * 判断文件是否存在
     * @author siy
     * @param fileName
     * @return
     * @throws
     * @version V1.0
     */
    public static boolean isFileExist(String fileName) {
        return StringUtil.isNotEmpty(fileName) && new File(fileName).exists();
    }

    /**
     * 创建新文件
     * @author siy
     * @param fileName
     * @param deleteExists 是否删除现有文件
     * @return
     * @throws IOException
     * @throws
     * @version V1.0
     */
    public static boolean create(String fileName, boolean deleteExists)
            throws IOException {
        File file = new File(fileName);
        if (file.exists() && file.isFile() && deleteExists)
            file.delete();
        return file.createNewFile();
    }

    /**
     * 删除文件或文件夹
     * @author siy
     * @param fileName 需删除的文件名
     * @param isRecurse 是否递归删除
     * @return
     * @throws IOException
     * @throws
     * @version V1.0
     */
    public static boolean delete(String fileName, boolean isRecurse)
            throws IOException {
        return deleteFile(new File(fileName), isRecurse);
    }

    /**
     * 删除文件或文件夹
     * @author siy
     * @param file 需删除的文件
     * @param isRecurse 是否递归删除
     * @return
     * @throws IOException
     * @throws
     * @version V1.0
     */
    public static boolean deleteFile(File file, boolean isRecurse)
            throws IOException {
        boolean ret = false;
        if (file != null && file.exists()) {
            if (file.isDirectory() && isRecurse) {
                File[] subFiles = file.listFiles();
                for (int i = 0; i < subFiles.length; i++) {
                    if (subFiles[i].isDirectory()) {
                        deleteFile(subFiles[i], isRecurse);
                    }
                    else {
                        subFiles[i].delete();
                    }
                }
            }
            else {
                ret = file.delete();
            }
        }
        return ret;
    }

    /**
     * 文件复制
     * @author siy
     * @param sourceFileName 源文件名
     * @param destFileName 目标文件名
     * @throws IOException
     * @throws
     * @version V1.0
     */
    public static void copy(String sourceFileName, String destFileName)
            throws IOException {
        copy(new File(sourceFileName), new File(destFileName));
    }

    /**
     * 文件复制
     * @author siy
     * @param sourceFile 源文件
     * @param destFile 目标文件
     * @throws IOException
     * @throws
     * @version V1.0
     */
    public static void copy(File sourceFile, File destFile) throws IOException {
        byte[] buffer = new byte[MB];
        int len = 0;
        FileInputStream in = new FileInputStream(sourceFile);
        FileOutputStream out = new FileOutputStream(destFile);
        while ((len = in.read(buffer)) > 0) {
            out.write(buffer, 0, len);
        }
        in.close();
        out.close();
    }

    /**
     * 使用NIO进行文件复制（快速）
     * @author siy
     * @param source 源文件名
     * @param dest 目标文件名
     * @throws Exception
     * @throws
     * @version V1.0
     */
    public static void copy2(String sourceFileName, String destFileName)
            throws Exception {
        FileInputStream in = new FileInputStream(sourceFileName);
        FileOutputStream out = new FileOutputStream(destFileName);
        FileChannel inC = in.getChannel();
        FileChannel outC = out.getChannel();
        while (inC.position() < inC.size()) {
            inC.transferTo(inC.position(), MB, outC);
            inC.position(inC.position() + MB);
        }
        inC.close();
        outC.close();
        in.close();
        out.close();
    }

    /**
     * 移动文件
     * @author siy
     * @param sourceFileName 源文件名
     * @param destPath 目标路径
     * @return
     * @throws 
     * @version V1.0
     */
    public static boolean move(String sourceFileName, String destPath) {
        File file = new File(sourceFileName);
        File dir = new File(destPath);
        return file.renameTo(new File(dir, file.getName()));
    }
}
