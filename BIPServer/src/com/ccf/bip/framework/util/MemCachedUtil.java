package com.ccf.bip.framework.util;

import org.apache.log4j.Logger;

import com.ccf.bip.framework.core.Globals;
import com.danga.MemCached.MemCachedClient;
import com.danga.MemCached.SockIOPool;

public class MemCachedUtil {
	private static final Logger logger = Logger.getLogger(MemCachedUtil.class);
	private static volatile MemCachedClient memCachedClient;

	public static MemCachedClient getMemCachedClient() {
		if (memCachedClient == null) {
			synchronized (MemCachedClient.class) {
				if (memCachedClient == null) {
					SockIOPool sockIOPool = SockIOPool.getInstance();

					sockIOPool.setServers(new String[] {Globals.MEMCACHED_ADDR});// 设置memcached服务器地址
					sockIOPool.setWeights(new Integer[] { 3 }); // 设置每个MemCached服务器权重
					sockIOPool.setFailover(true); // 当一个memcached服务器失效的时候是否去连接另一个memcached服务器.
					sockIOPool.setInitConn(10); // 初始化时对每个服务器建立的连接数目
					sockIOPool.setMinConn(10); // 每个服务器建立最小的连接数
					sockIOPool.setMaxConn(100); // 每个服务器建立最大的连接数
					sockIOPool.setMaintSleep(30); // 自查线程周期进行工作，其每次休眠时间
					sockIOPool.setNagle(false); // Socket的参数，如果是true在写数据时不缓冲，立即发送出去。Tcp的规则是在发送一个包之前，包的发送方会等待远程接收方确认已收到上一次发送过来的包；这个方法就可以关闭套接字的缓存——包准备立即发出。
					sockIOPool.setSocketTO(3000); // Socket阻塞读取数据的超时时间
					sockIOPool.setAliveCheck(true); // 设置是否检查memcached服务器是否失效
					sockIOPool.setMaxIdle(1000 * 30 * 30); // 设置最大处理时间
					sockIOPool.setSocketConnectTO(0); // 连接建立时对超时的控制

					sockIOPool.initialize(); // 初始化连接池
					memCachedClient = new MemCachedClient();
					memCachedClient.setPrimitiveAsString(true);
					logger.debug("memCached initialized.");
				}
			}
		}
		return memCachedClient;
	}
}
