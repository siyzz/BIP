package com.ccf.bip.framework.core;

import java.io.Serializable;

public class ParameterInfo implements Serializable {
    private static final long serialVersionUID = 1791430594578320471L;

    private String serviceName;
    private String functionName;
    private Object[] value;
    
    public String getServiceName() {
        return serviceName;
    }
    public void setServiceName(String serviceName) {
        this.serviceName = serviceName;
    }
    public String getFunctionName() {
        return functionName;
    }
    public void setFunctionName(String functionName) {
        this.functionName = functionName;
    }
    public Object[] getValue() {
        return value;
    }
    public void setValue(Object[] value) {
        this.value = value;
    }
}
