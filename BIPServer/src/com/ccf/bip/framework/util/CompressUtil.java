package com.ccf.bip.framework.util;

import java.io.BufferedInputStream;
import java.io.BufferedOutputStream;
import java.io.File;
import java.io.FileInputStream;
import java.io.FileNotFoundException;
import java.io.FileOutputStream;
import java.io.IOException;
import java.util.Enumeration;
import java.util.zip.CRC32;
import java.util.zip.CheckedOutputStream;
import java.util.zip.Deflater;
import java.util.zip.ZipException;

import org.apache.tools.zip.ZipEntry;
import org.apache.tools.zip.ZipFile;
import org.apache.tools.zip.ZipOutputStream;

/*
 * 压缩工具类
 * @filename:CompressUtil.java
 * Modification History:
 * Version         Author      Date     Description
 * --------------------------------------------------------------
 *  V1.0           siy    2016-5-19     初版
 * 
 *
 * @Copyright CCF All Rights Reserved.
 */
public class CompressUtil {
    /**
     * zip压缩
     * @author siy
     * @param srcFileName 需压缩的文件或文件夹
     * @param destFileName 输出文件名
     * @param comment 压缩注释
     * @throws FileNotFoundException
     * @throws IOException
     * @throws 
     * @version V1.0
     */
    public static void zip(String srcFileName, String destFileName,  
            String comment) throws FileNotFoundException, IOException {  
        //----压缩文件：  
        FileOutputStream f = new FileOutputStream(destFileName);  
        //使用指定校验和创建输出流  
        CheckedOutputStream csum = new CheckedOutputStream(f, new CRC32());  
  
        ZipOutputStream zos = new ZipOutputStream(csum);  
        //支持中文  
        zos.setEncoding("GBK");  
        BufferedOutputStream out = new BufferedOutputStream(zos);  
        //设置压缩包注释  
        zos.setComment(comment);  
        //启用压缩  
        zos.setMethod(ZipOutputStream.DEFLATED);  
        //压缩级别为最强压缩，但时间要花得多一点  
        zos.setLevel(Deflater.BEST_COMPRESSION);  
  
        File srcFile = new File(srcFileName);  
  
        if (!srcFile.exists() || (srcFile.isDirectory() && srcFile.list().length == 0)) {
        	zos.close();
            throw new FileNotFoundException(  
                    "File must exist and  ZIP file must have at least one entry.");  
        }  
        //获取压缩源所在父目录  
        srcFileName = srcFileName.replaceAll("\\\\", "/");  
        String prefixDir = null;  
        if (srcFile.isFile()) {  
            prefixDir = srcFileName.substring(0, srcFileName.lastIndexOf("/") + 1);  
        } else {  
            prefixDir = (srcFileName.replaceAll("/$", "") + "/");  
        }  
  
        //如果不是根目录  
        if (prefixDir.indexOf("/") != (prefixDir.length() - 1)) {  
            prefixDir = prefixDir.replaceAll("[^/]+/$", "");  
        }  
  
        //开始压缩  
        zip(zos, out, srcFile, prefixDir);  
  
        out.close();  
        // 注：校验和要在流关闭后才准备，一定要放在流被关闭后使用  
        System.out.println("Checksum: " + csum.getChecksum().getValue());  
    }  
    
    /**
     * unzip解压
     * @author siy
     * @param zipFileName zip文件名
     * @param destPath 输出目录
     * @throws
     * @version V1.0
     */
    public static void unzip(String zipFileName, String destPath)
            throws IOException, FileNotFoundException, ZipException {
        BufferedInputStream bi;

        ZipFile zf = new ZipFile(zipFileName, "GBK");// 支持中文

        Enumeration<?> e = zf.getEntries();
        while (e.hasMoreElements()) {
            ZipEntry ze2 = (ZipEntry) e.nextElement();
            String entryName = ze2.getName();
            String path = destPath + "/" + entryName;
            if (ze2.isDirectory()) {
                File decompressDirFile = new File(path);
                if (!decompressDirFile.exists()) {
                    decompressDirFile.mkdirs();
                }
            }
            else {
                String fileDir = path.substring(0, path.lastIndexOf("/"));
                File fileDirFile = new File(fileDir);
                if (!fileDirFile.exists()) {
                    fileDirFile.mkdirs();
                }
                BufferedOutputStream bos = new BufferedOutputStream(
                        new FileOutputStream(destPath + "/" + entryName));

                bi = new BufferedInputStream(zf.getInputStream(ze2));
                byte[] readContent = new byte[1024];
                int readCount = bi.read(readContent);
                while (readCount != -1) {
                    bos.write(readContent, 0, readCount);
                    readCount = bi.read(readContent);
                }
                bos.close();
            }
        }
        zf.close();
    }
    
    private static void zip(ZipOutputStream zos,
            BufferedOutputStream bo, File srcFile, String prefixDir)
            throws IOException, FileNotFoundException {
        ZipEntry zipEntry;

        String filePath = srcFile.getAbsolutePath().replaceAll("\\\\", "/")
                .replaceAll("//", "/");
        if (srcFile.isDirectory()) {
            filePath = filePath.replaceAll("/$", "") + "/";
        }
        String entryName = filePath.replace(prefixDir, "").replaceAll("/$", "");
        if (srcFile.isDirectory()) {
            if (!"".equals(entryName)) {
                // 如果是目录，则需要在写目录后面加上 /
                zipEntry = new ZipEntry(entryName + "/");
                zos.putNextEntry(zipEntry);
            }

            File srcFiles[] = srcFile.listFiles();
            for (int i = 0; i < srcFiles.length; i++) {
                zip(zos, bo, srcFiles[i], prefixDir);
            }
        }
        else {
            BufferedInputStream bi = new BufferedInputStream(
                    new FileInputStream(srcFile));

            // 开始写入新的ZIP文件条目并将流定位到条目数据的开始处
            zipEntry = new ZipEntry(entryName);
            zos.putNextEntry(zipEntry);
            byte[] buffer = new byte[1024];
            int readCount = bi.read(buffer);

            while (readCount != -1) {
                bo.write(buffer, 0, readCount);
                readCount = bi.read(buffer);
            }
            // 注，在使用缓冲流写压缩文件时，一个条件完后一定要刷新一把，不
            // 然可能有的内容就会存入到后面条目中去了
            bo.flush();
            // 文件读完后关闭
            bi.close();
        }
    }

}
