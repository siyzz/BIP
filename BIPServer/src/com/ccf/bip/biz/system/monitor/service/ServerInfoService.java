package com.ccf.bip.biz.system.monitor.service;

import com.ccf.bip.biz.system.monitor.mapper.ServerStatus;
import com.ccf.bip.biz.system.monitor.mapper.ServerStatusMapper;
import org.apache.log4j.Logger;
import org.springframework.stereotype.Service;

import javax.annotation.Resource;
import java.sql.SQLException;

/**
 * Created by siy on 2016/6/23.
 */
@Service("serverInfoService")
public class ServerInfoService implements IServerInfoService {
    private Logger logger = Logger.getLogger(ServerInfoService.class);
    @Resource
    private ServerStatusMapper mapper;
    @Override
    public ServerStatus getServerStatus() {
        ServerStatus serverStatus = new ServerStatus();
        serverStatus.setServerNetworking(true);
        serverStatus.setAppRunning(true);
        boolean dbConnecting = true;
        try{
            mapper.testDb();
        }
        catch (RuntimeException e){
            dbConnecting = false;
        }
        serverStatus.setDatabaseConnecting(dbConnecting);
        logger.debug(serverStatus);
        return serverStatus;
    }
}
