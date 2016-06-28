package com.ccf.bip.framework.core;

/*
 * BIP平台自定义异常，业务处理出现问题时抛出此异常
 * @filename:BipException.java
 * Modification History:
 * Version         Author      Date     Description
 * --------------------------------------------------------------
 *  V1.0           siy    2016-5-18     初版
 * 
 *
 * @Copyright CCF All Rights Reserved.
 */
public class BipException extends RuntimeException {
    private static final long serialVersionUID = 7592685022341738484L;

    public BipException() {
        super();
    }

    public BipException(String message) {
        super(message);
    }

    public BipException(String message, Throwable cause) {
        super(message, cause);
    }

    public BipException(Throwable cause) {
        super(cause);
    }
}
