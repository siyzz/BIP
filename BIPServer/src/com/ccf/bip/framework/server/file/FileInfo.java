package com.ccf.bip.framework.server.file;

import java.io.File;
import java.io.Serializable;

/**
 * Created by siy on 2016/7/5.
 */
public class FileInfo implements Serializable{
    private static final long serialVersionUID = -6103914117362178104L;
    private String name;
    private String directory;
    private byte[] content;

    public String getFullName() {
        return directory + (directory == null || directory.endsWith(File.separator) ? "" : File.separator) + name;
    }

    public String getName() {
        return name;
    }

    public void setName(String name) {
        this.name = name;
    }

    public String getDirectory() {
        return directory;
    }

    public void setDirectory(String directory) {
        this.directory = directory;
    }

    public byte[] getContent() {
        return content;
    }

    public void setContent(byte[] content) {
        this.content = content;
    }
}
