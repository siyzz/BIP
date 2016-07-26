package com.ccf.bip.biz.system.authorization.service;

import com.ccf.bip.biz.system.authorization.mapper.SysEmployeePost;
import com.ccf.bip.biz.system.authorization.mapper.SysEmployeePostMapper;
import com.ccf.bip.biz.system.authorization.mapper.SysPost;
import com.ccf.bip.biz.system.authorization.mapper.SysPostDatarightMapper;
import com.ccf.bip.biz.system.authorization.mapper.SysPostMapper;
import org.springframework.stereotype.Service;

import javax.annotation.Resource;

import java.util.ArrayList;
import java.util.HashMap;
import java.util.List;

/**
 * Created by siy on 2016/6/22.
 */
@Service("postService")
public class PostService implements IPostService{
    @Resource
    private SysPostMapper mapper;
    @Resource
    private SysPostDatarightMapper rightMapper;
    @Resource
    private SysEmployeePostMapper empPostMapper;
    
    @Override
    public List<SysPost> findByOrganizationId(String organizationId) {
        return mapper.selectByOrganizationId(organizationId);
    }

    @Override
    public List<HashMap<String, Object>> findPostDataRightByFormId(String formId) {
        return rightMapper.selectPostDataRightByFormId(formId);
    }

    @Override
    public List<HashMap<String, Object>> findEmployeeDataRightByFormId(String formId) {
        return rightMapper.selectEmployeeDataRightByFormId(formId);
    }

    @Override
    public Integer add(SysPost post) {
        return mapper.insertSelective(post);
    }

    @Override
    public Integer update(SysPost post) {
        return mapper.updateByPrimaryKeySelective(post);
    }

    @Override
    public Integer delete(String postId) {
        return mapper.deleteByPrimaryKey(postId);
    }

	@Override
	public Integer addEmployees(ArrayList<SysEmployeePost> list) {
		// TODO Auto-generated method stub
		int count = 0;
		if(list != null){
			for(int i = 0; i < list.size(); i++){
				if(empPostMapper.selectByEmployeePost(list.get(i)) == null){
					count += empPostMapper.insert(list.get(i));
				}
			}
		}
		return count;
	}

	@Override
	public Integer removeEmployees(ArrayList<SysEmployeePost> list) {
		// TODO Auto-generated method stub
		int count = 0;
		if(list != null){
			for(int i = 0; i < list.size();i++){
				count += empPostMapper.deleteByEmployeePost(list.get(i));
			}
		}
		return count;
	}
}
