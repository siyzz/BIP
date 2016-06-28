package com.ccf.bip.biz.metadata.dictionary.service;

import java.util.List;

import javax.annotation.Resource;

import org.springframework.stereotype.Service;

import com.ccf.bip.biz.metadata.dictionary.mapper.SysDictionary;
import com.ccf.bip.biz.metadata.dictionary.mapper.SysDictionaryMapper;

/*
 * @filename:DictionaryService.java
 * Modification History:
 * Version         Author      Date     Description
 * --------------------------------------------------------------
 *  V1.0           siy    2016年6月6日     初版
 * 
 *
 * @Copyright CCF All Rights Reserved.
 */
@Service("dictionaryService")
public class DictionaryService implements IDictionaryService{
	@Resource
	private SysDictionaryMapper mapper = null;

	public List<SysDictionary> findByParentCode(String parentCode) {
		// TODO Auto-generated method stub
		return mapper.selectByParentCode(parentCode);
	}

}
