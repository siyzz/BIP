package com.ccf.bip.biz.metadata.employee.service;

import java.util.HashMap;
import java.util.List;

import javax.annotation.Resource;

import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;

import com.ccf.bip.biz.metadata.employee.mapper.SysEmployee;
import com.ccf.bip.biz.metadata.employee.mapper.SysEmployeeMapper;
import com.ccf.bip.biz.system.user.mapper.SysUser;
import com.ccf.bip.biz.system.user.mapper.SysUserMapper;
import com.ccf.bip.framework.core.BipException;

/*
 * @filename:EmployeeService.java
 * Modification History:
 * Version         Author      Date     Description
 * --------------------------------------------------------------
 *  V1.0           siy    2016年6月16日     初版
 * 
 *
 * @Copyright CCF All Rights Reserved.
 */
@Service("employeeService")
public class EmployeeService implements IEmployeeService {
	@Resource
	private SysEmployeeMapper mapper;
	@Resource
	private SysUserMapper userMapper;

	public List<SysEmployee> recursiveFindByOrgId(String orgId) {
		// TODO Auto-generated method stub
		return mapper.recursiveSelectByOrgId(orgId);
	}

	@Override
	public List<HashMap<String,Object>> findByPostId(String postId) {
		return mapper.selectByPostId(postId);
	}

	public Integer update(SysEmployee employee) {
		// TODO Auto-generated method stub
		return mapper.updateByPrimaryKeySelective(employee);
	}

	public Integer add(SysEmployee employee) {
		// TODO Auto-generated method stub
		return mapper.insertSelective(employee);
	}

	@Transactional
	public Integer delete(String[] employeeIdArray) {
		// TODO Auto-generated method stub
		int ret = 0;
		if(employeeIdArray != null && employeeIdArray.length > 0){
			for(int i = 0; i < employeeIdArray.length; i++){
				//查询是否有帐号
				List<SysUser> userList = userMapper.selectByEmployeeId(employeeIdArray[i]);
				if(userList != null && userList.size() > 0)
					throw new BipException("被删除的员工已绑定系统帐号，请先注销帐号后再进行删除！");
				ret += mapper.deleteByPrimaryKey(employeeIdArray[i]);
			}
		}
		return ret;
	}	
}
