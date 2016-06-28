package com.ccf.bip.biz.system.monitor.service;

import com.ccf.bip.biz.system.monitor.mapper.ServerStatus;

/**
 * Created by siy on 2016/6/23.
 */
public interface IServerInfoService {
    ServerStatus getServerStatus();
}
