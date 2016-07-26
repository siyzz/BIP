package com.ccf.bip.biz.system.user.service;

import java.util.List;

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
    
    public Integer changePassword(SysUser user,String newPassword);
    
    public String test(String str);
    /**
     * 用户登录
     * @author siy
     * @param List<Object> list[0]用户对名象 list[1]客户端tocken
     * @return SysUser 用户对象
     * @throws 
     * @version V1.0
     */
    public List<Object> login(SysUser user);
}