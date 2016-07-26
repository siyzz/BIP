package com.ccf.bip.framework.core;

import org.apache.log4j.Logger;

import java.io.IOException;
import java.util.Properties;

/**
 * Created by siy on 2016/7/5.
 */
public class Globals {
    private static Logger logger = Logger.getLogger(Globals.class);
    private static Properties pro = new Properties();
    
    static{
    	try{
    		pro.load(Globals.class.getResourceAsStream("/resource/config/configuration.properties"));
    	}
    	catch(Exception ex){
    		logger.error(ex.getMessage());
    	}
    }
    
    public static final String FTP_IP = pro.getProperty("FTP_IP");
    public static final String FTP_USER = pro.getProperty("FTP_USER");
    public static final String FTP_PASSWORD = pro.getProperty("FTP_PASSWORD");
    public static final String LOCAL_DIR = pro.getProperty("LOCAL_DIR");
    public static final String FILE_TRANSFER_MODE = pro.getProperty("FILE_TRANSFER_MODE");
    public static final String VERSION_DIRECTORY = pro.getProperty("VERSION_DIRECTORY");
    public static final String VERSION_CONFIG_NAME = pro.getProperty("VERSION_CONFIG_NAME");
    public static final String MEMCACHED_ADDR = pro.getProperty("MEMCACHED_ADDR");
    public static final String MEMCACHED_TIMEOUT = pro.getProperty("MEMCACHED_TIMEOUT");
}
