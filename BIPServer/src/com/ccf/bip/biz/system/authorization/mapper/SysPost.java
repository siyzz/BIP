package com.ccf.bip.biz.system.authorization.mapper;

import java.io.Serializable;

public class SysPost implements Serializable {
    private static final long serialVersionUID = -4998485785624208025L;
    private String postId;

    private String postCode;

    private String postName;

    private String postType;

    private String postLevel;

    private String postOrgId;

    private String postOrgName;

    private String remark;

    private String roleId;

    private String roleName;

    public String getPostId() {
        return postId;
    }

    public void setPostId(String postId) {
        this.postId = postId == null ? null : postId.trim();
    }

    public String getPostCode() {
        return postCode;
    }

    public void setPostCode(String postCode) {
        this.postCode = postCode == null ? null : postCode.trim();
    }

    public String getPostName() {
        return postName;
    }

    public void setPostName(String postName) {
        this.postName = postName == null ? null : postName.trim();
    }

    public String getPostType() {
        return postType;
    }

    public void setPostType(String postType) {
        this.postType = postType == null ? null : postType.trim();
    }

    public String getPostLevel() {
        return postLevel;
    }

    public void setPostLevel(String postLevel) {
        this.postLevel = postLevel == null ? null : postLevel.trim();
    }

    public String getPostOrgId() {
        return postOrgId;
    }

    public void setPostOrgId(String postOrgId) {
        this.postOrgId = postOrgId == null ? null : postOrgId.trim();
    }

    public String getPostOrgName() {
        return postOrgName;
    }

    public void setPostOrgName(String postOrgName) {
        this.postOrgName = postOrgName == null ? null : postOrgName.trim();
    }

    public String getRemark() {
        return remark;
    }

    public void setRemark(String remark) {
        this.remark = remark == null ? null : remark.trim();
    }

    public String getRoleId() {
        return roleId;
    }

    public void setRoleId(String roleId) {
        this.roleId = roleId == null ? null : roleId.trim();
    }

    public String getRoleName() {
        return roleName;
    }

    public void setRoleName(String roleName) {
        this.roleName = roleName == null ? null : roleName.trim();
    }

    @Override
    public String toString() {
        StringBuilder sb = new StringBuilder();
        sb.append(getClass().getSimpleName());
        sb.append(" [");
        sb.append("Hash = ").append(hashCode());
        sb.append(", postId=").append(postId);
        sb.append(", postCode=").append(postCode);
        sb.append(", postName=").append(postName);
        sb.append(", postType=").append(postType);
        sb.append(", postLevel=").append(postLevel);
        sb.append(", postOrgId=").append(postOrgId);
        sb.append(", remark=").append(remark);
        sb.append(", roleId=").append(roleId);
        sb.append(", serialVersionUID=").append(serialVersionUID);
        sb.append("]");
        return sb.toString();
    }
}