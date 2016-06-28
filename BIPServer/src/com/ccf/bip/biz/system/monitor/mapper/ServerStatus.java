package com.ccf.bip.biz.system.monitor.mapper;

import java.io.Serializable;

/**
 * Created by siy on 2016/6/23.
 */
public class ServerStatus implements Serializable {
    private static final long serialVersionUID = 2767708508367266646L;

    private Boolean serverNetworking;
    private Boolean appRunning;
    private Boolean databaseConnecting;

    public Boolean getServerNetworking() {
        return serverNetworking;
    }

    public void setServerNetworking(Boolean serverNetworking) {
        this.serverNetworking = serverNetworking;
    }

    public Boolean getAppRunning() {
        return appRunning;
    }

    public void setAppRunning(Boolean appRunning) {
        this.appRunning = appRunning;
    }

    public Boolean getDatabaseConnecting() {
        return databaseConnecting;
    }

    public void setDatabaseConnecting(Boolean databaseConnecting) {
        this.databaseConnecting = databaseConnecting;
    }

    @Override
    public String toString() {
        return "ServerStatus{" +
                "ServerNetworking=" + serverNetworking +
                ", AppRunning=" + appRunning +
                ", DatabaseConnecting=" + databaseConnecting +
                '}';
    }
}
