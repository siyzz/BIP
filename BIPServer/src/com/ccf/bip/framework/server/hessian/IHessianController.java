package com.ccf.bip.framework.server.hessian;

import javax.servlet.http.HttpServletRequest;

import com.ccf.bip.framework.core.ParameterInfo;
import com.ccf.bip.framework.core.ReturnInfo;

/**
 * BIP Server hessian调用接口
 * @filename:IHessianController.java
 * Modification History:
 * Version         Author      Date     Description
 * --------------------------------------------------------------
 *  V1.0           siy    2016-5-17     初版
 * 
 *
 * 
 * @Coperight BJ CCF All Rights Reserved.
 */
public interface IHessianController {
   /**
    * BIP Server调用方法
    * @author siy
    * @param param BIP返回值
    * @return ReturnInfo BIP参数
    * @throws 
    * @version V1.0
    */
   ReturnInfo call(ParameterInfo param);
}
