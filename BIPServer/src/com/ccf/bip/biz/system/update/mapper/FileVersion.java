package com.ccf.bip.biz.system.update.mapper;

import java.io.File;
import java.io.Serializable;
import java.util.Date;

import com.ccf.bip.framework.util.StringUtil;

/**
 * Created by siy on 2016/7/11.
 */
public class FileVersion implements Serializable{
	private String programVersionId;

    private String directory;

    private String name;

    private Short version;

    private Date updateTime;

    private static final long serialVersionUID = 1L;

    public String getProgramVersionId() {
        return programVersionId;
    }

    public void setProgramVersionId(String programVersionId) {
        this.programVersionId = programVersionId == null ? null : programVersionId.trim();
    }

    public String getDirectory() {
        return directory;
    }

    public void setDirectory(String directory) {
        this.directory = directory == null ? null : directory.trim();
    }

    public String getName() {
        return name;
    }

    public void setName(String name) {
        this.name = name == null ? null : name.trim();
    }

    public Short getVersion() {
        return version;
    }

    public void setVersion(Short version) {
        this.version = version;
    }

    public Date getUpdateTime() {
        return updateTime;
    }

    public void setUpdateTime(Date updateTime) {
        this.updateTime = updateTime;
    }

    @Override
    public String toString() {
        StringBuilder sb = new StringBuilder();
        sb.append(getClass().getSimpleName());
        sb.append(" [");
        sb.append("Hash = ").append(hashCode());
        sb.append(", programVersionId=").append(programVersionId);
        sb.append(", directory=").append(directory);
        sb.append(", name=").append(name);
        sb.append(", version=").append(version);
        sb.append(", updateTime=").append(updateTime);
        sb.append(", serialVersionUID=").append(serialVersionUID);
        sb.append("]");
        return sb.toString();
    }

    public String getFullName() {
        return directory + (StringUtil.isEmpty(directory) || directory.endsWith(File.separator) ? "" : File.separator) + name;
    }
}
