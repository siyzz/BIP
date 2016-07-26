package com.ccf.bip.framework.web.interceptor;

import java.util.List;

import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;
import javax.servlet.http.HttpSession;

import org.apache.log4j.Logger;
import org.springframework.web.servlet.HandlerInterceptor;
import org.springframework.web.servlet.ModelAndView;

public class ControllerInterceptor implements HandlerInterceptor {
    private static final Logger logger = Logger.getLogger(ControllerInterceptor.class);
	private List<String> excludedUrls;// 定义不经过拦截的路径，如登陆

	/**
	 * 这个方法在DispatcherServlet完全处理完请求后被调用，可以在该方法中进行一些资源清理的操作
	 */
	public void afterCompletion(HttpServletRequest request,
			HttpServletResponse response, Object obj, Exception exception)
			throws Exception {
	    logger.debug("ControllerInterceptor.afterCompletion()");
	}

	/**
	 * 这个方法在业务处理器处理完请求后，但是DispatcherServlet向客户端返回请求前被调用，在该方法中对用户请求request进行处理。
	 */
	public void postHandle(HttpServletRequest request, HttpServletResponse response,
			Object arg2, ModelAndView arg3) throws Exception {
	    logger.debug("ControllerInterceptor.postHandle()");
	}

	/**
	 * 这个方法在业务处理器处理请求之前被调用，在该方法中对用户请求request进行处理。如果程序员决定该拦截器对请求进行拦截处理后还要调用其他的拦截器
	 * ，或者是业务处理器去进行处理，则返回true；如果程序员决定不需要再调用其他的组件去处理请求，则返回false。
	 */
	public boolean preHandle(HttpServletRequest request, HttpServletResponse response,
			Object arg2) throws Exception {
	    logger.debug("ControllerInterceptor.preHandle()");
		String requestUri = request.getRequestURI();
		for (String url : excludedUrls) {
			if (requestUri.endsWith(url)) {
				return true;
			}
		}

		HttpSession session = request.getSession();
		if (session.getAttribute("user") == null) {
		    logger.info("session timeout:"+request.getRequestURI());
		    response.sendError(999);//session失效重定向，返回999到前台js处理
			return false;
		}
		return true;
	}

	public List<String> getExcludedUrls() {
		return excludedUrls;
	}

	public void setExcludedUrls(List<String> excludedUrls) {
		this.excludedUrls = excludedUrls;
	}
}
