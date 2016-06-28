package com.ccf.bip.biz.system.authorization.mapper;

import java.io.Serializable;

public class SysPostDataright implements Serializable {
    private static final long serialVersionUID = 3922915688278396535L;
    private String datarightId;

    private String postId;

    public String getDatarightId() {
        return datarightId;
    }

    public void setDatarightId(String datarightId) {
        this.datarightId = datarightId == null ? null : datarightId.trim();
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
        sb.append(", datarightId=").append(datarightId);
        sb.append(", postId=").append(postId);
        sb.append(", serialVersionUID=").append(serialVersionUID);
        sb.append("]");
        return sb.toString();
    }
}