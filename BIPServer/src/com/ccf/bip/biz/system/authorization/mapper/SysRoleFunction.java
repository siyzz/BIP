package com.ccf.bip.biz.system.authorization.mapper;

import java.io.Serializable;

public class SysRoleFunction implements Serializable {
    private static final long serialVersionUID = -7713190147228620779L;
    private String relationId;

    private String roleId;

    private String functionId;

    private String parentFunctionId;

    private Short functionSeq;

    public String getRelationId() {
        return relationId;
    }

    public void setRelationId(String relationId) {
        this.relationId = relationId == null ? null : relationId.trim();
    }

    public String getRoleId() {
        return roleId;
    }

    public void setRoleId(String roleId) {
        this.roleId = roleId == null ? null : roleId.trim();
    }

    public String getFunctionId() {
        return functionId;
    }

    public void setFunctionId(String functionId) {
        this.functionId = functionId == null ? null : functionId.trim();
    }

    public String getParentFunctionId() {
        return parentFunctionId;
    }

    public void setParentFunctionId(String parentFunctionId) {
        this.parentFunctionId = parentFunctionId == null ? null : parentFunctionId.trim();
    }

    public Short getFunctionSeq() {
        return functionSeq;
    }

    public void setFunctionSeq(Short functionSeq) {
        this.functionSeq = functionSeq;
    }

    @Override
    public String toString() {
        StringBuilder sb = new StringBuilder();
        sb.append(getClass().getSimpleName());
        sb.append(" [");
        sb.append("Hash = ").append(hashCode());
        sb.append(", relationId=").append(relationId);
        sb.append(", roleId=").append(roleId);
        sb.append(", functionId=").append(functionId);
        sb.append(", parentFunctionId=").append(parentFunctionId);
        sb.append(", functionSeq=").append(functionSeq);
        sb.append(", serialVersionUID=").append(serialVersionUID);
        sb.append("]");
        return sb.toString();
    }
}