package com.ccf.bip.biz.system.authorization.mapper;

import java.io.Serializable;
import java.util.ArrayList;

public class SysFunction implements Serializable {
	private static final long serialVersionUID = 6564811311245561099L;

	private String functionId;

	private String key;
	
    private String functionName;

    private String parentId;

    private String functionType;

    private String serverName;

    private String url;

    private String image;

    private String tag;

    private Short seq;
    
    private String assemblyname;
    
    private Boolean showToolBar;
    
    private Boolean useHotKey;
    
    private String formType;
    
    private ArrayList<SysFunction> buttonList;

    public String getFunctionId() {
        return functionId;
    }

    public void setFunctionId(String functionId) {
        this.functionId = functionId == null ? null : functionId.trim();
    }

    public String getKey() {
		return key;
	}

	public void setKey(String key) {
		this.key = key;
	}

	public String getFunctionName() {
        return functionName;
    }

    public void setFunctionName(String functionName) {
        this.functionName = functionName == null ? null : functionName.trim();
    }

    public String getParentId() {
        return parentId;
    }

    public void setParentId(String parentId) {
        this.parentId = parentId == null ? null : parentId.trim();
    }

    public String getFunctionType() {
        return functionType;
    }

    public void setFunctionType(String functionType) {
        this.functionType = functionType == null ? null : functionType.trim();
    }

    public String getServerName() {
        return serverName;
    }

    public void setServerName(String serverName) {
        this.serverName = serverName == null ? null : serverName.trim();
    }

    public String getUrl() {
        return url;
    }

    public void setUrl(String url) {
        this.url = url == null ? null : url.trim();
    }

    public String getImage() {
        return image;
    }

    public void setImage(String image) {
        this.image = image == null ? null : image.trim();
    }

    public String getTag() {
        return tag;
    }

    public void setTag(String tag) {
        this.tag = tag == null ? null : tag.trim();
    }

    public Short getSeq() {
        return seq;
    }

    public void setSeq(Short seq) {
        this.seq = seq;
    } 
    
    public String getAssemblyname() {
		return assemblyname;
	}

	public void setAssemblyname(String assemblyname) {
		this.assemblyname = assemblyname;
	}

	public Boolean getShowToolBar() {
		return showToolBar;
	}

	public void setShowToolBar(Boolean showToolBar) {
		this.showToolBar = showToolBar;
	}

	public Boolean getUseHotKey() {
		return useHotKey;
	}

	public void setUseHotKey(Boolean useHotKey) {
		this.useHotKey = useHotKey;
	}

	public String getFormType() {
		return formType;
	}

	public void setFormType(String formType) {
		this.formType = formType;
	}
	
	public ArrayList<SysFunction> getButtonList() {
		return buttonList;
	}

	public void setButtonList(ArrayList<SysFunction> buttonList) {
		this.buttonList = buttonList;
	}

	@Override
    public String toString() {
		StringBuilder sb = new StringBuilder();
        sb.append(getClass().getSimpleName());
        sb.append(" [");
        sb.append("Hash = ").append(hashCode());
        sb.append(", functionId=").append(functionId);
        sb.append(", functionName=").append(functionName);
        sb.append(", parentId=").append(parentId);
        sb.append(", functionType=").append(functionType);
        sb.append(", serverName=").append(serverName);
        sb.append(", url=").append(url);
        sb.append(", image=").append(image);
        sb.append(", tag=").append(tag);
        sb.append(", seq=").append(seq);
        sb.append(", assemblyname=").append(assemblyname);
        sb.append(", showToolBar=").append(showToolBar);
        sb.append(", useHotKey=").append(useHotKey);
        sb.append(", formType=").append(formType);
        sb.append(", serialVersionUID=").append(serialVersionUID);
        sb.append("]");
        return sb.toString();
    }
}