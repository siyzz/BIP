package com.ccf.bip.framework.core;

import java.io.Serializable;

public class ReturnInfo implements Serializable {
    private static final long serialVersionUID = -5450924816521698349L;
    
    private int code;
    private String message;
    private Object value;
    
    public int getCode() {
        return code;
    }
    public void setCode(int code) {
        this.code = code;
    }
    public String getMessage() {
        return message;
    }
    public void setMessage(String message) {
        this.message = message;
    }
    public Object getValue() {
        return value;
    }
    public void setValue(Object value) {
        this.value = value;
    }
}
