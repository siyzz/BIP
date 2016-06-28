package com.ccf.bip.biz.metadata.org.mapper;

import java.io.Serializable;

public class SysOrganization implements Serializable{
	private static final long serialVersionUID = -6517510668531181087L;

	private String organizationId;

    private String parentId;

    private String organizationCode;

    private String organizationName;

    private String organizationLevel;

    private String organizationType;
    
    private String organizationTypeDesc;
    
    private String organizationLeader;
    
    private String organizationLeaderName;
    
    private String organizationPhone;

    private String remark;

    public String getOrganizationId() {
        return organizationId;
    }

    public void setOrganizationId(String organizationId) {
        this.organizationId = organizationId == null ? null : organizationId.trim();
    }

    public String getParentId() {
        return parentId;
    }

    public void setParentId(String parentId) {
        this.parentId = parentId == null ? null : parentId.trim();
    }

    public String getOrganizationCode() {
        return organizationCode;
    }

    public void setOrganizationCode(String organizationCode) {
        this.organizationCode = organizationCode == null ? null : organizationCode.trim();
    }

    public String getOrganizationName() {
        return organizationName;
    }

    public void setOrganizationName(String organizationName) {
        this.organizationName = organizationName == null ? null : organizationName.trim();
    }

    public String getOrganizationLevel() {
        return organizationLevel;
    }

    public void setOrganizationLevel(String organizationLevel) {
        this.organizationLevel = organizationLevel == null ? null : organizationLevel.trim();
    }

    public String getOrganizationType() {
        return organizationType;
    }

    public void setOrganizationType(String organizationType) {
        this.organizationType = organizationType == null ? null : organizationType.trim();
    }
    
    public String getOrganizationTypeDesc() {
		return organizationTypeDesc;
	}

	public void setOrganizationTypeDesc(String organizationTypeDesc) {
		this.organizationTypeDesc = organizationTypeDesc;
	}

	public String getOrganizationLeader() {
		return organizationLeader;
	}

	public void setOrganizationLeader(String organizationLeader) {
		this.organizationLeader = organizationLeader;
	}

	public String getOrganizationLeaderName() {
		return organizationLeaderName;
	}

	public void setOrganizationLeaderName(String organizationLeaderName) {
		this.organizationLeaderName = organizationLeaderName;
	}

	public String getOrganizationPhone() {
		return organizationPhone;
	}

	public void setOrganizationPhone(String organizationPhone) {
		this.organizationPhone = organizationPhone;
	}

	public String getRemark() {
        return remark;
    }

    public void setRemark(String remark) {
        this.remark = remark == null ? null : remark.trim();
    }
    
    @Override
    public String toString() {
        StringBuilder sb = new StringBuilder();
        sb.append(getClass().getSimpleName());
        sb.append(" [");
        sb.append("Hash = ").append(hashCode());
        sb.append(", organizationId=").append(organizationId);
        sb.append(", parentId=").append(parentId);
        sb.append(", organizationCode=").append(organizationCode);
        sb.append(", organizationName=").append(organizationName);
        sb.append(", organizationLevel=").append(organizationLevel);
        sb.append(", organizationType=").append(organizationType);
        sb.append(", organizationLeader=").append(organizationLeader);
        sb.append(", organizationPhone=").append(organizationPhone);
        sb.append(", remark=").append(remark);
        sb.append(", serialVersionUID=").append(serialVersionUID);
        sb.append("]");
        return sb.toString();
    }
}