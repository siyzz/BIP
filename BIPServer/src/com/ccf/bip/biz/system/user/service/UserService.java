package com.ccf.bip.biz.system.user.service;

import javax.annotation.Resource;

import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;

import com.ccf.bip.biz.metadata.employee.mapper.SysEmployeeMapper;
import com.ccf.bip.biz.system.user.mapper.SysUser;
import com.ccf.bip.biz.system.user.mapper.SysUserMapper;
import com.ccf.bip.framework.core.BipException;
import com.ccf.bip.framework.util.EncryptionUtil;
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
	public Integer changePassword(SysUser user) {
		// TODO Auto-generated method stub
		user.setValid("1");
		this.userMapper.updateByPrimaryKey(user);

		user.setCreator(
				"aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaccccccccccccccccccccccccccccccccc");
		userMapper.updateByPrimaryKey(user);

		this.userMapper.deleteByPrimaryKey(user.getUserId());
		return 0;
	}
	
	public String test(String str){
		System.out.println(str);
		return "test:" + str;
	}

	public SysUser login(SysUser user) {
		// TODO Auto-generated method stub
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
		return userRet;
	}
}
