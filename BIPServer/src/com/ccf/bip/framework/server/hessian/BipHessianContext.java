package com.ccf.bip.framework.server.hessian;

import javax.servlet.http.HttpServletRequest;

public class BipHessianContext {
	private HttpServletRequest _request;
	private static final ThreadLocal<BipHessianContext> _localContext = new ThreadLocal<BipHessianContext>() {
		@Override
		public BipHessianContext initialValue() {
			return new BipHessianContext();
		}
	};

	private BipHessianContext() {
	}

	public static void setRequest(HttpServletRequest request) {
		_localContext.get()._request = request;
	}

	public static HttpServletRequest getRequest() {
		return _localContext.get()._request;
	}

	public static void clear() {
		_localContext.get()._request = null;
	}
}
