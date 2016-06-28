package com.ccf.bip.framework.server.hessian;

import java.lang.reflect.InvocationTargetException;
import java.lang.reflect.Method;
import java.util.Arrays;

import org.apache.log4j.Logger;
import org.springframework.beans.BeansException;
import org.springframework.context.ApplicationContext;
import org.springframework.context.ApplicationContextAware;
import org.springframework.stereotype.Component;

import com.ccf.bip.framework.core.BipException;
import com.ccf.bip.framework.core.ParameterInfo;
import com.ccf.bip.framework.core.ReturnInfo;

/**
 * BIP Hessian Server调度类
 * @filename:HessianService.java
 * Modification History:
 * Version         Author      Date     Description
 * --------------------------------------------------------------
 *  V1.0           siy    2016-5-17     初版
 * 
 *
 * @Copyright CCF All Rights Reserved.
 */
@Component("hessianController")
public class BipHessianController implements IHessianController, ApplicationContextAware {
    private ApplicationContext context;
    private static Logger logger = Logger.getLogger(BipHessianController.class);
    
    public void setApplicationContext(ApplicationContext context)
            throws BeansException {
        this.context = context;
    }

    public ReturnInfo call(ParameterInfo bipParam) {
        ReturnInfo ret = new ReturnInfo();
        try {
            logger.info("call:" + bipParam.getServiceName() + "." + bipParam.getFunctionName() + " " + Arrays.toString(bipParam.getValue()));
            //获得业务类Class
            Class<?> clazz = Thread.currentThread().getContextClassLoader().loadClass(bipParam.getServiceName());
            Object instance = context.getBean(clazz);//从ApplicationContext获取bean
            Class<?>[] paramTypeArray = null;
            //获取调用方法参数类型
            Object[] params = bipParam.getValue();
            if (params != null && params.length > 0) {
                paramTypeArray = new Class<?>[params.length];
                int i = 0;
                do{
                    paramTypeArray[i] = params[i] != null ? params[i].getClass() : Object.class;
                }
                while(++i < paramTypeArray.length);
            }
            //调用方法
            Method method = clazz.getMethod(bipParam.getFunctionName(), paramTypeArray);
            Object result = method.invoke(instance, params);
            ret.setValue(result);
        }
        catch (InvocationTargetException e) {
        	if(e.getTargetException() instanceof BipException){
	            ret.setCode(1);
	            ret.setMessage(e.getTargetException().getMessage());
	            logger.warn(e.getTargetException().getMessage(),e.getTargetException());
        	}
        	else{
        		ret.setCode(-2);
                ret.setMessage("BIP服务处理失败！");
                logger.error(e.getMessage(),e);
        	}
        }
        catch (ClassNotFoundException e){
            ret.setCode(-1);
            ret.setMessage("BIP服务配置错误！");
            logger.error(e.getMessage(),e);
        }
        catch (NoSuchMethodException e) {
            ret.setCode(-1);
            ret.setMessage("BIP服务配置错误！");
            logger.error(e.getMessage(),e);
        }
        catch (Exception e){
            ret.setCode(-2);
            ret.setMessage("BIP服务处理失败！");
            logger.error(e.getMessage(),e);
        }
        return ret;
    }
}
