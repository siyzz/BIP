package com.ccf.bip.biz.system.authorization.controller;

import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;

import org.springframework.stereotype.Controller;
import org.springframework.ui.Model;
import org.springframework.web.bind.annotation.RequestMapping;

import com.ccf.bip.biz.system.user.mapper.SysUser;

/**
 * 用户登录控制类
 * @filename:LoginController.java
 * Modification History:
 * Version         Author      Date     Description
 * --------------------------------------------------------------
 *  V1.0           siy    2016-5-19     初版
 * 
 *
 * @Copyright CCF All Rights Reserved.
 */
@Controller  
@RequestMapping("/")  
public class LoginController {
    @RequestMapping("/login")  
    public String login(HttpServletRequest request,HttpServletResponse response,Model model){  
        request.getSession().setAttribute("user", new SysUser());
        return "index.jsp";  
    }
}
