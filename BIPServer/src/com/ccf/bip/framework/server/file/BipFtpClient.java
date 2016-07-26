package com.ccf.bip.framework.server.file;

import com.ccf.bip.framework.core.Globals;
import com.ccf.bip.framework.util.StringUtil;
import org.apache.commons.net.ftp.FTP;
import org.apache.commons.net.ftp.FTPFile;
import org.apache.log4j.Logger;
import org.apache.commons.net.ftp.FTPClient;

import java.io.ByteArrayInputStream;
import java.io.ByteArrayOutputStream;
import java.io.IOException;
import java.io.InputStream;

/**
 * Created by siy on 2016/7/5.
 */
public class BipFtpClient extends FTPClient {
    private static BipFtpClient instance = null;

    public Logger logger = Logger.getLogger(BipFtpClient.class);

    private String ip = null;
    private int port = 21;
    private String userName = null;
    private String password = null;
    private String encoding = "";

    public String getEncoding() {
        return encoding;
    }

    public void setEncoding(String encoding) {
        this.encoding = encoding;
    }

    private BipFtpClient() {

    }

    /**
     * 获取BipFtpClient实例
     * @return
     */
    public synchronized static BipFtpClient newInstance() {
        if (instance == null) {
            instance = new BipFtpClient();
        }
        return instance;
    }

    /**
     * 从配置文件获取FtpServer连接信息
     */
    private void init() {
//        Properties pro = new Properties();
//        try {
//            pro.load(BipFtpClient.class.getResourceAsStream("/resource/config/configuration.properties"));
//            ip = pro.getProperty("FTP_IP");
//            userName = pro.getProperty("FTP_USER");
//            password = pro.getProperty("FTP_PASSWORD");
//        }
//        catch (IOException e) {
//            logger.error(e);
//        }
        ip = Globals.FTP_IP;
        password = Globals.FTP_PASSWORD;
        userName = Globals.FTP_USER;
    }

    /**
     * 创建FTP目录
     * @param path 路径
     * @return 是否成功
     * @throws IOException
     */
    public boolean createDir(String path) throws IOException {
        if (StringUtil.isEmpty(path)) {
            return false;
        }
        if (path.startsWith("/")) {
            path = path.substring(1, path.length());
        }
        String[] paths = path.split("/");
        String workPath = "/";
        for (int i = 0; i < paths.length; i++) {
            this.makeDirectory(paths[i]);
            workPath = workPath + "/" + paths[i];
            this.changeWorkingDirectory(workPath);
        }
        return true;
    }

    /**
     * 判断路径是目录还是文件
     * @param path 路径名称
     * @return
     */
    public boolean isPath(String path) {
        boolean flag = true;
        try {
            flag = this.changeWorkingDirectory(path); // 不是目录时，将报错
            this.changeWorkingDirectory("/"); // 回到根目录
        }
        catch (Exception e) {
            flag = false;
        }

        return flag;
    }

    /**
     * 删除目录及目录中的文件
     * @param pathname 目录路径
     * @return 是否删除成功
     */
    public boolean deletePath(String pathname) {
        try {
            FTPFile[] files = this.listFiles(pathname);
            for (FTPFile f : files) {
                if (f.isDirectory()) {
                    this.deletePath(pathname + "/" + f.getName());
                    this.removeDirectory(pathname);
                }
                if (f.isFile()) {
                    this.deleteFile(pathname + "/" + f.getName());
                }
            }
            if(this.isPath(pathname)){
                this.removeDirectory(pathname);
            }
        }
        catch (IOException e) {
            e.printStackTrace();
            return false;
        }
        return true;
    }

    /**
     * 连接FTP服务
     * @return 是否连接成功
     * @throws Exception
     */
    public boolean open() throws Exception {
        boolean connected = true;
        try {
            if (StringUtil.isEmpty(ip)) {
                init();
            }
            this.connect(ip, port);;
            connected = this.login(userName, password);
            encoding = this.getControlEncoding();
            //this.setControlEncoding("UTF-8");
            this.setBufferSize(1024);
            // 设置文件类型（二进制）
            this.setFileType(FTP.BINARY_FILE_TYPE);
        }
        catch (Exception e) {
            // TODO Auto-generated catch block
            throw (e);
        }

        return connected;
    }

    /**
     * 关闭FTP连接
     * @return 是否关闭成功
     * @throws Exception
     */
    public boolean close() throws Exception {
        boolean closed = true;
        try {
            if (this.isConnected()) {
                this.logout();
                this.disconnect();
            }
        }
        catch (Exception e) {
            // TODO Auto-generated catch block
            throw (e);
        }

        return closed;
    }

    /**
     * 上传文件
     * @param b 文件byte数组
     * @param name 文件名
     * @param path 文件保存路径
     * @throws Exception
     */
    public void upload(byte[] b, String name, String path) throws Exception {
        try {
            ByteArrayInputStream stream = new ByteArrayInputStream(b);

            // 设置上传目录
            boolean changed = this.changeWorkingDirectory(path);
            if (!changed) {
                createDir(path);
            }

            this.storeFile(new String(name.getBytes(), encoding),
                    stream);
            stream.close();
            this.changeWorkingDirectory("/");
        }
        catch (Exception e) {
            throw (e);
        }
    }

    /**
     * 下载文件
     * @param fileName 文件全名
     * @return 文件byte数组
     * @throws Exception
     */
    public byte[] download(String fileName) throws Exception {
        InputStream is = null;
        byte[] bytes = null;
        try {
            is = this.retrieveFileStream(fileName);
            ByteArrayOutputStream out = new ByteArrayOutputStream();
            byte[] buffer = new byte[1024];
            int count =0;
            while((count = is.read(buffer)) > 0){
                out.write(buffer,0,count);
            }

            bytes = out.toByteArray();//CoreUtil.toByteArray(is);
            out.close();
            is.close();
            this.completePendingCommand();
        }
        catch (Exception e) {
            throw (e);
        }
        return bytes;
    }
}
