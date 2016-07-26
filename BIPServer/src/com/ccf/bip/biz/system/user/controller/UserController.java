package com.ccf.bip.biz.system.user.controller;

import javax.annotation.Resource;  
import javax.servlet.http.HttpServletRequest;  
  
import org.springframework.aop.support.AopUtils;
import org.springframework.stereotype.Controller;  
import org.springframework.ui.Model;  
import org.springframework.web.bind.annotation.RequestMapping;  

import com.ccf.bip.biz.system.user.mapper.SysUser;
import com.ccf.bip.biz.system.user.service.IUserService;


/**
 * 用户测试控制类
 * @author 
 * @since 2016-3-25
 */
@Controller  
@RequestMapping("/user")  
public class UserController {  
   
	@Resource
    private IUserService userService;
    
    /**
     * 方法注释编写处
     * @param request 参数说明
     * @param model  参数说明
     * @return 返回参数说明
     */
    @RequestMapping("/showUser")
    public String toIndex(HttpServletRequest request,Model model){  
        String userId = request.getParameter("id");  
        SysUser user = this.userService.getUserById(userId);  
        model.addAttribute("user", user);
        return "../jsp/showUser.jsp";  
    }
    
    @RequestMapping("/changePassword")
    public String changePassword(HttpServletRequest request,Model model){
        System.out.println(AopUtils.isAopProxy(this.userService));
        
        String userId = request.getParameter("id");
        SysUser user = this.userService.getUserById(userId);
        this.userService.changePassword(user,"123213");
        
        user = this.userService.getUserById(userId);  
        model.addAttribute("user", user);  
        return "../jsp/showUser.jsp";
    }
}  