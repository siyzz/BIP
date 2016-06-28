package com.ccf.bip.biz.system.user.mapper;

import java.io.Serializable;
import java.util.Date;

import com.ccf.bip.biz.metadata.employee.mapper.SysEmployee;

public class SysUser implements Serializable{
	private static final long serialVersionUID = 6635534405873964972L;

	private String userId;

    private String userAccount;

    private String userPassword;

    private String employeeId;

    private String valid;

    private String creator;

    private Date createTime;

    private Date lastUpdateTime;
    
    private String superAdmin;
    
    private SysEmployee employee;

    public String getUserId() {
        return userId;
    }

    public void setUserId(String userId) {
        this.userId = userId == null ? null : userId.trim();
    }

    public String getUserAccount() {
        return userAccount;
    }

    public void setUserAccount(String userAccount) {
        this.userAccount = userAccount == null ? null : userAccount.trim();
    }

    public String getUserPassword() {
        return userPassword;
    }

    public void setUserPassword(String userPassword) {
        this.userPassword = userPassword == null ? null : userPassword.trim();
    }

    public String getEmployeeId() {
        return employeeId;
    }

    public void setEmployeeId(String employeeId) {
        this.employeeId = employeeId == null ? null : employeeId.trim();
    }

    public String getValid() {
        return valid;
    }

    public void setValid(String valid) {
        this.valid = valid == null ? null : valid.trim();
    }

    public String getCreator() {
        return creator;
    }

    public void setCreator(String creator) {
        this.creator = creator == null ? null : creator.trim();
    }

    public Date getCreateTime() {
        return createTime;
    }

    public void setCreateTime(Date createTime) {
        this.createTime = createTime;
    }

    public Date getLastUpdateTime() {
        return lastUpdateTime;
    }

    public void setLastUpdateTime(Date lastUpdateTime) {
        this.lastUpdateTime = lastUpdateTime;
    }

	public SysEmployee getEmployee() {
		return employee;
	}

	public void setEmployee(SysEmployee employee) {
		this.employee = employee;
	}
	
	public String getSuperAdmin() {
		return superAdmin;
	}

	public void setSuperAdmin(String superAdmin) {
		this.superAdmin = superAdmin;
	}

	@Override
    public String toString() {
        StringBuilder sb = new StringBuilder();
        sb.append(getClass().getSimpleName());
        sb.append(" [");
        sb.append("Hash = ").append(hashCode());
        sb.append(", userId=").append(userId);
        sb.append(", userAccount=").append(userAccount);
        sb.append(", userPassword=").append(userPassword);
        //sb.append(", employeeId=").append(employeeId);
        sb.append(", valid=").append(valid);
        sb.append(", creator=").append(creator);
        sb.append(", createTime=").append(createTime);
        sb.append(", lastUpdateTime=").append(lastUpdateTime);
        sb.append(", superAdmin=").append(superAdmin);
        sb.append(", employee=").append(employee);
        sb.append(", serialVersionUID=").append(serialVersionUID);
        sb.append("]");
        return sb.toString();
    }
}