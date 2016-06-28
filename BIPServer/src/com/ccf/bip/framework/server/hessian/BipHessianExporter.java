package com.ccf.bip.framework.server.hessian;

import java.io.IOException;

import javax.annotation.Resource;
import javax.servlet.ServletException;
import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;

import org.springframework.remoting.caucho.HessianExporter;
import org.springframework.stereotype.Controller;
import org.springframework.web.HttpRequestHandler;
import org.springframework.web.bind.annotation.RequestMapping;

/*
 * Hessian通信统一入口
 * @filename:BipHessianExporter.java
 * Modification History:
 * Version         Author      Date     Description
 * --------------------------------------------------------------
 *  V1.0           siy    2016-5-18     初版
 * 
 *
 * @Copyright CCF All Rights Reserved.
 */
@Controller
@RequestMapping("/hessian") 
public class BipHessianExporter extends HessianExporter implements HttpRequestHandler{    
    @Resource(name="hessianController")
    public void setService(IHessianController controller){
        super.setService(controller);
        super.setServiceInterface(IHessianController.class);
    }
    
    @RequestMapping("/handle")
    public void handleRequest(HttpServletRequest request, HttpServletResponse response)
            throws ServletException, IOException {
        // TODO Auto-generated method stub
        response.setContentType(CONTENT_TYPE_HESSIAN);
        try {
            this.invoke(request.getInputStream(), response.getOutputStream());
        }
        catch (Throwable e) {
            // TODO Auto-generated catch block
            
        }
    }

}
