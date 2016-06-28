package com.ccf.bip.biz.metadata.dictionary.service;

import java.util.List;
import com.ccf.bip.biz.metadata.dictionary.mapper.SysDictionary;
/*
 * 数据字典管理
 * @filename:IDictionaryService.java
 * Modification History:
 * Version         Author      Date     Description
 * --------------------------------------------------------------
 *  V1.0           siy    2016年6月6日     初版
 * 
 *
 * @Copyright CCF All Rights Reserved.
 */
public interface IDictionaryService {
	/**
	 * 根据上级编码获取数据字典
	 * @author siy
	 * @param parentCode
	 * @return
	 * @throws 
	 * @version V1.0
	 */
	public List<SysDictionary> findByParentCode(String parentCode);
}
