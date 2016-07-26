package com.ccf.bip.biz.system.user.service;

import java.util.ArrayList;
import java.util.Calendar;
import java.util.Date;
import java.util.List;

import javax.annotation.Resource;
import javax.servlet.http.HttpServletRequest;

import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;

import com.ccf.bip.biz.metadata.employee.mapper.SysEmployeeMapper;
import com.ccf.bip.biz.system.user.mapper.SysUser;
import com.ccf.bip.biz.system.user.mapper.SysUserMapper;
import com.ccf.bip.framework.core.BipException;
import com.ccf.bip.framework.core.Globals;
import com.ccf.bip.framework.server.BipSession;
import com.ccf.bip.framework.server.hessian.BipHessianContext;
import com.ccf.bip.framework.util.EncryptionUtil;
import com.ccf.bip.framework.util.MemCachedUtil;
import com.ccf.bip.framework.util.StringUtil;

@Service("userService")
public class UserService implements IUserService {
	@Resource
	private SysUserMapper userMapper;
	@Resource
	private SysEmployeeMapper employeeMapper;

	public SysUser getUserById(String userId) {
		return this.userMapper.selectByPrimaryKey(userId);
	}

	@Transactional
	public Integer changePassword(SysUser user,String newPassword) {
		// TODO Auto-generated method stub
		int count = 0;
		SysUser sysUser = userMapper.selectByPrimaryKey(user.getUserId());
		if(sysUser.getUserPassword().equals(EncryptionUtil.MD5(user.getUserPassword()))){
			sysUser.setUserPassword(EncryptionUtil.MD5(newPassword));
			count = userMapper.updatePassword(sysUser);
		}
		else{
			throw new BipException("密码不正确！");
		}
		return count;
	}
	
	public String test(String str){
		System.out.println(str);
		return "test:" + str;
	}

	public List<Object> login(SysUser user) {
		// TODO Auto-generated method stub
		List<Object> list = new ArrayList<Object>();
		SysUser userRet = null;
		if (user != null && StringUtil.isNotEmpty(user.getUserAccount())
				&& StringUtil.isNotEmpty(user.getUserPassword())) {
			user.setUserPassword(EncryptionUtil.MD5(user.getUserPassword()));
			userRet = userMapper.selectByLogin(user);
			if (userRet != null) {
				if (userRet.getValid().equals("1")) {
					userRet.setEmployee(employeeMapper.selectByPrimaryKey(userRet.getEmployeeId()));
				} else {
					throw new BipException("帐号已停用！");
				}
			} else {
				throw new BipException("帐号或密码不正确！");
			}
		} else {
			throw new BipException("登录用户信息不全!");
		}
		
		//设置用户session
		String tocken = "";
		if(userRet != null){
			String ip = getRemoteHost(BipHessianContext.getRequest());
			Date now = Calendar.getInstance().getTime();
			tocken = ip+userRet.getUserId()+now.getTime();
			BipSession session = new BipSession();
			session.setAttribute("user", userRet);
			Calendar cal = Calendar.getInstance();
			cal.setTimeInMillis(now.getTime() + 30000);
			
			MemCachedUtil.getMemCachedClient().set(tocken, session, new Date(Integer.parseInt(Globals.MEMCACHED_TIMEOUT)*60*1000));
		}
		
		list.add(userRet);
		list.add(tocken);
		return list;
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
