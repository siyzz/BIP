package com.ccf.bip.framework.orm.mybatis;

import java.util.List;

/*
 * 平台通用Mapper
 * @filename:GenericMapper.java
 * Modification History:
 * Version         Author      Date     Description
 * --------------------------------------------------------------
 *  V1.0           siy    2016-5-19     初版
 * 
 *
 * @Copyright CCF All Rights Reserved.
 */
public interface GenericMapper<T, PK> {
    /**
     * 将对象中的数据写入数据库
     * @author siy
     * @param t
     * @throws 
     * @version V1.0
     */
    int insert(T t);
    
    /**
     * 将对象中的数据更新到数据库
     * @author siy
     * @param t
     * @throws 
     * @version V1.0
     */
    int update(T t);
    
    /**
     * 按条件从数据库中读取对象信息
     * @author siy
     * @param t 查询条件
     * @param skipResults 忽略记录数
     * @param maxResults 获取数据记录数
     * @return
     * @throws 
     * @version V1.0
     */
    public List<T> find(T t, int skipResults, int maxResults);
    
    /**
     * 按条件查询数据库中数据的条数
     * @author siy
     * @param t
     * @return
     * @throws 
     * @version V1.0
     */
    public int count(T t);
    
    /**
     * 复杂条件下从数据库中读取对象信息
     * @author siy
     * @param t 查询条件
     * @param skipResults 忽略记录数
     * @param maxResults 获取数据记录数
     * @param condition 查询条件语句
     * @param orderBy 排序语句
     * @return
     * @throws 
     * @version V1.0
     */
    public List<T> findWithCondition(T t, String condition, String orderBy, int skipResults, int maxResults);
    
    /**
     * 复杂条件下查询数据库中数据的条数
     * @author siy
     * @param t 查询条件
     * @param condition 叠加条件
     * @return
     * @throws 
     * @version V1.0
     */
    public int countWithCondition(T t, String condition);
    
    /**
     * 根据ID查询对象数据
     * @author siy
     * @param id
     * @return
     * @throws 
     * @version V1.0
     */
    public T findById(PK id);
    
    /**
     * 根据ID从数据库中删除对象数据
     * @author siy
     * @param id
     * @throws 
     * @version V1.0
     */
    public int delete(PK id);
}
