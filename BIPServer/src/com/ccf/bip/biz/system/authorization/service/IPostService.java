package com.ccf.bip.biz.system.authorization.service;

import com.ccf.bip.biz.system.authorization.mapper.SysEmployeePost;
import com.ccf.bip.biz.system.authorization.mapper.SysPost;

import java.util.ArrayList;
import java.util.HashMap;
import java.util.List;

/**
 * Created by siy on 2016/6/22.
 */
public interface IPostService {
    /**
     * 根据组织机构获取岗位
     * @param organizationId
     * @return
     */
    List<SysPost> findByOrganizationId(String organizationId);

    /**
     * 查询拥有该功能界面的所有岗位
     * @param formId
     * @return
     */
    List<HashMap<String,Object>> findPostDataRightByFormId(String formId);
    /**
     * 查询拥有该功能界面的所有用户
     * @param formId
     * @return
     */
    List<HashMap<String,Object>> findEmployeeDataRightByFormId(String formId);

    /**
     * 添加岗位
     * @param post
     * @return
     */
    Integer add(SysPost post);

    /**
     * 修改岗位
     * @param post
     * @return
     */
    Integer update(SysPost post);

    /**
     * 删除岗位
     * @param postId
     * @return
     */
    Integer delete(String postId);
    
    /**
     * 添加员工
     * @param list
     * @return
     */
    Integer addEmployees(ArrayList<SysEmployeePost> list);
    
    /**
     * 移除员工
     * @param list
     * @return
     */
    Integer removeEmployees(ArrayList<SysEmployeePost> list);
}
