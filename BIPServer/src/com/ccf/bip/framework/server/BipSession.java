package com.ccf.bip.framework.server;

import java.io.Serializable;
import java.util.Calendar;
import java.util.Enumeration;
import java.util.HashMap;
import java.util.Map;
import java.util.Vector;

import org.apache.log4j.Logger;

import com.ccf.bip.framework.core.BipGuid;

public class BipSession implements Serializable{
	private static final long serialVersionUID = 4753630503977643011L;
	private static final Logger logger = Logger.getLogger(BipSession.class);
	
	private Map<String,Object> attributes;
	private long creationTime;
	private long lastAccessedTime;
	private String sessionId;
	private int maxInactiveInterval = 1800;
	
	public BipSession(){
		sessionId = BipGuid.getGuid();
		creationTime = Calendar.getInstance().getTimeInMillis();
		lastAccessedTime = creationTime;
		attributes = new HashMap<String,Object>();
		logger.debug("session:" + sessionId + "created");
	}
	
	public Enumeration<String> getAttributeNames() {
		return new Vector<String>(attributes.keySet()).elements();
	}

	public long getCreationTime() {
		return creationTime;
	}

	public String getId() {
		return sessionId;
	}

	public long getLastAccessedTime() {
		return lastAccessedTime;
	}
	
	public void setLastAccessedTime(long lastAccessedTime){
		this.lastAccessedTime = lastAccessedTime;
	}

	public int getMaxInactiveInterval() {
		return maxInactiveInterval;
	}

	public void invalidate() {
		attributes.clear();
	}

	public void removeAttribute(String name) {
		attributes.remove(name);
	}

	public void setAttribute(String name, Object value) {
		attributes.put(name, value);
	}

	public void setMaxInactiveInterval(int interval) {
		maxInactiveInterval = interval;
	}

	public Object getAttribute(String name) {
		return attributes.get(name);
	}
}
