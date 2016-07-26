package com.ccf.bip.biz.system.update.service;

import com.ccf.bip.biz.system.update.mapper.FileVersion;
import com.ccf.bip.biz.system.update.mapper.FileVersionMapper;
import com.ccf.bip.framework.core.BipGuid;
import com.ccf.bip.framework.core.Globals;
import com.ccf.bip.framework.server.file.FileInfo;
import com.ccf.bip.framework.server.file.INetFileService;

import net.sf.json.JSONArray;

import org.springframework.stereotype.Service;

import javax.annotation.Resource;

import java.io.File;
import java.util.ArrayList;
import java.util.Calendar;
import java.util.List;

/**
 * Created by siy on 2016/7/13.
 */
@Service("programUpdateService")
public class ProgramUpdateService implements IProgramUpdateService {
	@Resource
	INetFileService netFileService;
	@Resource
	FileVersionMapper mapper;

	@Override
	public List<FileVersion> findFileVersionList() {
//		List<FileVersion> list = new ArrayList<FileVersion>();
//		List<FileInfo> fileInfoList = netFileService
//				.download(Globals.VERSION_DIRECTORY + File.separator + Globals.VERSION_CONFIG_NAME);
//		if (fileInfoList != null && fileInfoList.size() > 0) {
//			FileInfo info = fileInfoList.get(0);
//			String verJson = new String(info.getContent());
//			JSONArray jsonArray = JSONArray.fromObject(verJson);
//			@SuppressWarnings("unchecked")
//			List<FileVersion> fileVersionList = (List<FileVersion>) JSONArray.toCollection(jsonArray,
//					FileVersion.class);
//			list.addAll(fileVersionList);
//		}
//		return list;
		return mapper.selectAll();
	}

	@Override
	public Integer updateFileVersionList(List<FileVersion> fileVersionList) {		
		return null;
	}

	@Override
	public FileInfo download(String fileName) {
		FileInfo fileInfo = null;
		List<FileInfo> fileInfoList = netFileService
				.download(Globals.VERSION_DIRECTORY + File.separator + fileName);
		if(fileInfoList != null && fileInfoList.size() > 0){
			fileInfo = fileInfoList.get(0);
		}
		return fileInfo;
	}

	@Override
	public Integer upload(FileInfo fileInfo) {
		String directory = fileInfo.getDirectory();
		fileInfo.setDirectory(Globals.VERSION_DIRECTORY + File.separator + directory);
		ArrayList<FileInfo> fileInfoList = new ArrayList<FileInfo>();
		fileInfoList.add(fileInfo);
		Integer count = netFileService.upload(fileInfoList);
		FileVersion fileVersion = mapper.selectByFileName(directory, fileInfo.getName());
		if(fileVersion == null){
			fileVersion = new FileVersion();
			fileVersion.setProgramVersionId(BipGuid.getGuid());
			fileVersion.setDirectory(directory);
			fileVersion.setName(fileInfo.getName());
			fileVersion.setVersion((short)1);
			fileVersion.setUpdateTime(Calendar.getInstance().getTime());
			mapper.insertSelective(fileVersion);
		}
		else{
			fileVersion.setVersion((short)(fileVersion.getVersion()+1));
			fileVersion.setUpdateTime(Calendar.getInstance().getTime());
			mapper.updateByPrimaryKeySelective(fileVersion);
		}
		return count;
	}
}
