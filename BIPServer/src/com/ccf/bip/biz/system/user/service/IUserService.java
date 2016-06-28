package com.ccf.bip.biz.system.user.service;

import com.ccf.bip.biz.system.user.mapper.SysUser;

/**
 * 用户管理及登录业务处理类
 * @filename:IUserService.java
 * Modification History:
 * Version         Author      Date     Description
 * --------------------------------------------------------------
 *  V1.0           siy    2016年5月30日     初版
 * 
 *
 * 
 * @Coperight CCF All Rights Reserved.
 */
public interface IUserService {  
    public SysUser getUserById(String userId);
    
    public Integer changePassword(SysUser user);
    
    public String test(String str);
    /**
     * 用户登录
     * @author siy
     * @param SysUser 用户对象
     * @return SysUser 用户对象
     * @throws 
     * @version V1.0
     */
    public SysUser login(SysUser user);
}