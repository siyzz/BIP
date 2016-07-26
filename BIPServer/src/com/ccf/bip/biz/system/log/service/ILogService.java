package com.ccf.bip.biz.system.log.service;

import java.util.List;

public interface ILogService {
	/**
	 * 获取运行日志列表
	 * @return List<String> log文件名列表
	 */
	List<String> findRunningLogNameList();
	
	byte[] findRunningLogContent(String logName);
}
