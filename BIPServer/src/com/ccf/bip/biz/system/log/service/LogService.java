package com.ccf.bip.biz.system.log.service;

import java.io.File;
import java.util.ArrayList;
import java.util.List;

import org.springframework.stereotype.Service;

import com.ccf.bip.framework.server.file.LocalNetFileTransfer;
import com.ccf.bip.framework.util.FileUtil;

@Service("logService")
public class LogService implements ILogService{
	private static final String directory = System.getProperty("catalina.base") + "/logs/bip";

	@Override
	public List<String> findRunningLogNameList() {
		// TODO Auto-generated method stub
		List<String> fileNameList = new ArrayList<String>();
		File path = new File(directory);
		if(path.exists()){
			File[] files = path.listFiles();
			for(int i = 0;i < files.length;i++){
				if(files[i].isFile()){
					fileNameList.add(files[i].getName());
				}
			}
		}
		return fileNameList;
	}

	@Override
	public byte[] findRunningLogContent(String logName) {
		// TODO Auto-generated method stub
		return FileUtil.getBytes(directory + File.separator + logName);
	}
	
	

}
