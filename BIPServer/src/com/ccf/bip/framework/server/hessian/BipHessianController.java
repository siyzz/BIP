package com.ccf.bip.framework.server.hessian;

import java.lang.reflect.InvocationTargetException;
import java.lang.reflect.Method;
import java.util.Arrays;
import java.util.Calendar;
import java.util.Date;

import javax.servlet.http.HttpServletRequest;

import org.apache.log4j.Logger;
import org.springframework.beans.BeansException;
import org.springframework.context.ApplicationContext;
import org.springframework.context.ApplicationContextAware;
import org.springframework.stereotype.Component;

import com.ccf.bip.framework.core.BipException;
import com.ccf.bip.framework.core.Globals;
import com.ccf.bip.framework.core.ParameterInfo;
import com.ccf.bip.framework.core.ReturnInfo;
import com.ccf.bip.framework.server.BipSession;
import com.ccf.bip.framework.util.MemCachedUtil;
import com.ccf.bip.framework.util.StringUtil;

/**
 * BIP Hessian Server调度类
 * 
 * @filename:HessianService.java Modification History: Version Author Date
 *                               Description
 *                               -----------------------------------------------
 *                               --------------- V1.0 siy 2016-5-17 初版
 * 
 *
 * @Copyright CCF All Rights Reserved.
 */
@Component("hessianController")
public class BipHessianController implements IHessianController, ApplicationContextAware {
	private ApplicationContext context;
	private static Logger logger = Logger.getLogger(BipHessianController.class);

	public void setApplicationContext(ApplicationContext context) throws BeansException {
		this.context = context;
	}

	public ReturnInfo call(ParameterInfo bipParam) {
        ReturnInfo ret = new ReturnInfo();
        try {
            logger.info("call:" + bipParam.getServiceName() + "." + bipParam.getFunctionName() + " " + Arrays.toString(bipParam.getValue()));
            //检验客户端tocken(login不检验)
            String tocken = bipParam.getTocken();
            Object obj = null;
            if(!StringUtil.isEmpty(tocken) && (obj = MemCachedUtil.getMemCachedClient().get(tocken)) != null || (bipParam.getServiceName()+"."+bipParam.getFunctionName()).equals("com.ccf.bip.biz.system.user.service.UserService.login")){
            	//更新session
            	if(bipParam.isSessionUpdate()){
	            	BipSession session = (BipSession)obj;
	            	if(session != null){
		            	session.setLastAccessedTime(Calendar.getInstance().getTimeInMillis());
		            	MemCachedUtil.getMemCachedClient().replace(tocken, session,new Date(Integer.parseInt(Globals.MEMCACHED_TIMEOUT) * 60 * 1000));
	            	}
            	}
            	//获得业务类Class
                Class<?> clazz = Thread.currentThread().getContextClassLoader().loadClass(bipParam.getServiceName());
                Object instance = context.getBean(clazz);//从ApplicationContext获取bean
                Class<?>[] paramTypeArray = null;
                //获取调用方法参数类型
                Object[] arguments = bipParam.getValue();
                if (arguments != null && arguments.length > 0) {
                    paramTypeArray = new Class<?>[arguments.length];
                    int i = 0;
                    do{
                        paramTypeArray[i] = arguments[i] != null ? arguments[i].getClass() : Object.class;
                    }
                    while(++i < paramTypeArray.length);
                }
                
                //调用方法
                Method method = clazz.getMethod(bipParam.getFunctionName(), paramTypeArray);
                /*通过参数名和参数长度遍历参数类型获取方法，可解决形参为子类时找不到方法的问题*/
                /**
                Method[] methods = clazz.getDeclaredMethods();
                int index = 0;
                do{
                	Method m = methods[index];
                	Class<?>[] parameterTypes = m.getParameterTypes();
                	if(m.getName().equals(bipParam.getFunctionName()) && parameterTypes.length == arguments.length){
                		int k = 0;
    	            	for(; k < parameterTypes.length; k++){
    	            		if(!parameterTypes[k].isAssignableFrom(arguments[k].getClass())){
    	            			break;
    	            		}
    	            	}
    	            	if(k == parameterTypes.length){
    	            		ret.setValue(m.invoke(instance, arguments));
    	            		break;
    	            	}
                	}            	
                }
                while(++index < methods.length);
                if(index == methods.length){
                	throw new NoSuchMethodException();
                }
                */
                Object result = method.invoke(instance, arguments);
                ret.setValue(result);
            }
            else{
            	ret.setCode(999);
            	ret.setMessage("登录超时，请重新登录！");
            }            
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

	private String getRemoteHost(HttpServletRequest request) {
		String ip = request.getHeader("x-forwarded-for");
		if (ip == null || ip.length() == 0 || "unknown".equalsIgnoreCase(ip)) {
			ip = request.getHeader("Proxy-Client-IP");
		}
		if (ip == null || ip.length() == 0 || "unknown".equalsIgnoreCase(ip)) {
			ip = request.getHeader("WL-Proxy-Client-IP");
		}
		if (ip == null || ip.length() == 0 || "unknown".equalsIgnoreCase(ip)) {
			ip = request.getRemoteAddr();
		}
		return ip.equals("0:0:0:0:0:0:0:1") ? "127.0.0.1" : ip;
	}
}
