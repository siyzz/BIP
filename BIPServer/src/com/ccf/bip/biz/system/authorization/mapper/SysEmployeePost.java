package com.ccf.bip.biz.system.authorization.mapper;

import java.io.Serializable;

public class SysEmployeePost implements Serializable {
    private static final long serialVersionUID = 6812061745401841172L;

    private String employeePostId;

    private String employeeId;

    private String postId;

    public String getEmployeePostId() {
        return employeePostId;
    }

    public void setEmployeePostId(String employeePostId) {
        this.employeePostId = employeePostId == null ? null : employeePostId.trim();
    }

    public String getEmployeeId() {
        return employeeId;
    }

    public void setEmployeeId(String employeeId) {
        this.employeeId = employeeId == null ? null : employeeId.trim();
    }

    public String getPostId() {
        return postId;
    }

    public void setPostId(String postId) {
        this.postId = postId == null ? null : postId.trim();
    }

    @Override
    public String toString() {
        StringBuilder sb = new StringBuilder();
        sb.append(getClass().getSimpleName());
        sb.append(" [");
        sb.append("Hash = ").append(hashCode());
        sb.append(", employeePostId=").append(employeePostId);
        sb.append(", employeeId=").append(employeeId);
        sb.append(", postId=").append(postId);
        sb.append(", serialVersionUID=").append(serialVersionUID);
        sb.append("]");
        return sb.toString();
    }
}