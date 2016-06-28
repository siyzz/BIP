package com.ccf.bip.framework.web.interceptor;

/*import java.sql.Connection;
 import java.sql.PreparedStatement;
 import java.sql.ResultSet;
 import java.sql.SQLException;
 import java.util.Collection;
 import java.util.HashMap;
 import java.util.Iterator;
 import java.util.List;
 import java.util.Map;
 import java.util.Properties;

 import org.apache.ibatis.builder.StaticSqlSource;
 import org.apache.ibatis.executor.Executor;
 import org.apache.ibatis.executor.parameter.ParameterHandler;
 import org.apache.ibatis.executor.statement.StatementHandler;
 import org.apache.ibatis.logging.Log;
 import org.apache.ibatis.logging.jdbc.ConnectionLogger;
 import org.apache.ibatis.mapping.BoundSql;
 import org.apache.ibatis.mapping.MappedStatement;
 import org.apache.ibatis.mapping.SqlCommandType;
 import org.apache.ibatis.plugin.Interceptor;
 import org.apache.ibatis.plugin.Intercepts;
 import org.apache.ibatis.plugin.Invocation;
 import org.apache.ibatis.plugin.Plugin;
 import org.apache.ibatis.plugin.Signature;
 import org.apache.ibatis.session.Configuration;
 import org.apache.ibatis.transaction.Transaction;

 import com.eap.common.web.paging.Page;*/
import java.sql.Connection;
import java.util.Properties;
import java.util.regex.Pattern;

import org.apache.commons.lang3.StringUtils;
import org.apache.commons.lang3.reflect.FieldUtils;
import org.apache.ibatis.executor.statement.StatementHandler;
import org.apache.ibatis.mapping.BoundSql;
import org.apache.ibatis.plugin.Interceptor;
import org.apache.ibatis.plugin.Intercepts;
import org.apache.ibatis.plugin.Invocation;
import org.apache.ibatis.plugin.Plugin;
import org.apache.ibatis.plugin.Signature;
import org.apache.ibatis.session.RowBounds;
import org.apache.log4j.Logger;

/**
 * 
 * 分页拦截器，用于拦截需要进行分页查询的操作，然后对其进行分页处理。 利用拦截器实现Mybatis分页的原理：
 * 要利用JDBC对数据库进行操作就必须要有一个对应的Statement对象
 * ，Mybatis在执行Sql语句前就会产生一个包含Sql语句的Statement对象，而且对应的Sql语句
 * 是在Statement之前产生的，所以我们就可以在它生成Statement之前对用来生成Statement的Sql语句下手
 * 。在Mybatis中Statement语句是通过RoutingStatementHandler对象的
 * prepare方法生成的。所以利用拦截器实现Mybatis分页的一个思路就是拦截StatementHandler接口的prepare方法
 * ，然后在拦截器方法中把Sql语句改成对应的分页查询Sql语句，之后再调用
 * StatementHandler对象的prepare方法，即调用invocation.proceed()。
 * 对于分页而言，在拦截器里面我们还需要做的一个操作就是统计满足当前条件的记录一共有多少
 * ，这是通过获取到了原始的Sql语句后，把它改为对应的统计语句再利用Mybatis封装好的参数和设
 * 置参数的功能把Sql语句中的参数进行替换，之后再执行查询记录数的Sql语句进行总记录数的统计。
 * 
 */
@Intercepts({ @Signature(method = "prepare", type = StatementHandler.class, args = { Connection.class }) })
public class PaginationInterceptor implements Interceptor {
    private static Logger logger = Logger.getLogger(PaginationInterceptor.class);
	private static String SQL_SELECT_REGEX = "(?is)^\\s*SELECT.*$";
	private static String SQL_COUNT_REGEX = "(?is)^\\s*SELECT\\s+COUNT\\s*\\(\\s*(?:\\*|\\w+)\\s*\\).*$";

	public Object intercept(Invocation inv) throws Throwable {
		StatementHandler target = (StatementHandler) inv.getTarget();
		BoundSql boundSql = target.getBoundSql();
		String sql = boundSql.getSql();
		if (StringUtils.isBlank(sql)) {
			return inv.proceed();
		}
		logger.info("origin sql>>>>" + sql.replaceAll("\n", "")); // 限定为select查询语句且不能是查询count
		if (sql.matches(SQL_SELECT_REGEX)
				&& !Pattern.matches(SQL_COUNT_REGEX, sql)) {
			Object obj = FieldUtils.readField(target, "delegate", true); // 反射获取RowBounds对象
			RowBounds rowBounds = (RowBounds) FieldUtils.readField(obj,
					"rowBounds", true); // 分页参数存在且不为默认值时进行分页参数构造
			if (rowBounds != null && rowBounds != RowBounds.DEFAULT) {
				FieldUtils.writeField(boundSql, "sql", newSql(sql, rowBounds),
						true);
				logger.info("new sql>>>>" + newSql(sql, rowBounds).replaceAll("\n", ""));
			}
		}
		return inv.proceed();
	}

	// 执行SQL的拼装
	private String newSql(String oldSql, RowBounds rowBounds) {
		String start = "SELECT * FROM (SELECT ROW_.*,ROWNUM rownum_ FROM (";
		String end = ") ROW_ WHERE ROWNUM<=" + rowBounds.getLimit()
				+ ") WHERE rownum_ > " + rowBounds.getOffset();
		return start + oldSql + end;
	}

	public Object plugin(Object obj) { // TODO Auto-generated method stub
		return Plugin.wrap(obj, this);
	}

	public void setProperties(Properties prop) { // TODO Auto-generated

	}
	/*
	 * // 存储所有语句名称 HashMap<String, String> map_statement = new HashMap<String,
	 * String>(); // 用户提供分页计算条数后缀 static final String COUNT_ID = "_count";
	 *//**
	 * 获取所有statement语句的名称
	 * <p>
	 * 
	 * @param configuration
	 */
	/*
	 * protected synchronized void initStatementMap(Configuration configuration)
	 * { if (!map_statement.isEmpty()) { return; } Collection<String> statements
	 * = configuration.getMappedStatementNames(); for (Iterator<String> iter =
	 * statements.iterator(); iter.hasNext();) { String element = iter.next();
	 * map_statement.put(element, element); } }
	 *//**
	 * 获取数据库连接
	 * <p>
	 * 
	 * @param transaction
	 * @param statementLog
	 * @return
	 * @throws SQLException
	 */
	/*
	 * protected Connection getConnection(Transaction transaction, Log
	 * statementLog) throws SQLException { Connection connection =
	 * transaction.getConnection(); if (statementLog.isDebugEnabled()) { return
	 * ConnectionLogger.newInstance(connection, statementLog); } else { return
	 * connection; } }
	 * 
	 * public Object intercept(Invocation invocation) throws Throwable { Object
	 * parameter = invocation.getArgs()[1]; Page page = seekPage(parameter); if
	 * (page == null) { return invocation.proceed(); } else { return
	 * handlePaging(invocation, parameter, page); }
	 * 
	 * }
	 *//**
	 * 处理分页的情况
	 * <p>
	 * 
	 * @param invocation
	 * @param parameter
	 * @param page
	 * @throws SQLException
	 */
	/*
	 * @SuppressWarnings("rawtypes") protected List handlePaging(Invocation
	 * invocation, Object parameter, Page page) throws Exception {
	 * MappedStatement mappedStatement = (MappedStatement) invocation
	 * .getArgs()[0]; Configuration configuration =
	 * mappedStatement.getConfiguration(); if (map_statement.isEmpty()) {
	 * initStatementMap(configuration); } BoundSql boundSql =
	 * mappedStatement.getBoundSql(parameter); // 查询结果集 StaticSqlSource
	 * sqlsource = new StaticSqlSource(configuration,
	 * getLimitString(boundSql.getSql(), page),
	 * boundSql.getParameterMappings()); MappedStatement.Builder builder = new
	 * MappedStatement.Builder( configuration, "id_temp_result", sqlsource,
	 * SqlCommandType.SELECT);
	 * builder.resultMaps(mappedStatement.getResultMaps())
	 * .resultSetType(mappedStatement.getResultSetType())
	 * .statementType(mappedStatement.getStatementType()); MappedStatement
	 * query_statement = builder.build();
	 * 
	 * List data = (List) exeQuery(invocation, query_statement); // 设置到page对象
	 * page.setRecords(data); page.setCount(getTotalSize(invocation,
	 * configuration, mappedStatement, boundSql, parameter));
	 * 
	 * return data; }
	 *//**
	 * 根据提供的语句执行查询操作
	 * <p>
	 * 
	 * @param invocation
	 * @param query_statement
	 * @return
	 * @throws Exception
	 */
	/*
	 * protected Object exeQuery(Invocation invocation, MappedStatement
	 * query_statement) throws Exception { Object[] args = invocation.getArgs();
	 * return invocation.getMethod().invoke(invocation.getTarget(), new Object[]
	 * { query_statement, args[1], args[2], args[3] }); }
	 *//**
	 * 获取总记录数量
	 * <p>
	 * 
	 * @param configuration
	 * @param mappedStatement
	 * @param sql
	 * @param parameter
	 * @return
	 * @throws SQLException
	 */
	/*
	 * @SuppressWarnings("rawtypes") protected int getTotalSize(Invocation
	 * invocation, Configuration configuration, MappedStatement mappedStatement,
	 * BoundSql boundSql, Object parameter) throws Exception {
	 * 
	 * String count_id = mappedStatement.getId() + COUNT_ID; int totalSize = 0;
	 * if (map_statement.containsKey(count_id)) { // 优先查找能统计条数的sql List data =
	 * (List) exeQuery(invocation, mappedStatement
	 * .getConfiguration().getMappedStatement(count_id)); if (data.size() > 0) {
	 * totalSize = Integer.parseInt(data.get(0).toString()); } } else { Executor
	 * exe = (Executor) invocation.getTarget(); Connection connection =
	 * getConnection(exe.getTransaction(), mappedStatement.getStatementLog());
	 * String countSql = getCountSql(boundSql.getSql()); totalSize =
	 * getTotalSize(configuration, mappedStatement, boundSql, countSql,
	 * connection, parameter); }
	 * 
	 * return totalSize; }
	 *//**
	 * 拼接查询sql,加入limit
	 * <p>
	 * 
	 * @param sql
	 * @param page
	 */
	/*
	 * protected String getLimitString(String sql, Page page) { StringBuffer sb
	 * = new StringBuffer(sql.length() + 100); sb.append(sql);
	 * sb.append(" limit ").append(page.getStartNo() - 1).append(",")
	 * .append(page.getPageSize()); return sb.toString(); }
	 *//**
	 * 拼接获取条数的sql语句
	 * <p>
	 * 
	 * @param sqlPrimary
	 */
	/*
	 * protected String getCountSql(String sqlPrimary) { String sqlUse =
	 * sqlPrimary.replaceAll("[\\s]+", " "); String upperString =
	 * sqlUse.toUpperCase(); int order_by =
	 * upperString.lastIndexOf(" ORDER BY "); if (order_by > -1) { sqlUse =
	 * sqlUse.substring(0, order_by); } String[] paramsAndMethod =
	 * sqlUse.split("\\s"); int count = 0; int index = 0; for (int i = 0; i <
	 * paramsAndMethod.length; i++) { String upper =
	 * paramsAndMethod[i].toUpperCase(); if (upper.length() == 0) { continue; }
	 * if (upper.contains("SELECT")) { count++; } else if
	 * (upper.contains("FROM")) { count--; } if (count == 0) { index = i; break;
	 * } } StringBuilder return_sql = new
	 * StringBuilder("SELECT COUNT(1) AS cnt "); StringBuilder common_count =
	 * new StringBuilder(); for (int j = index; j < paramsAndMethod.length; j++)
	 * { common_count.append(" "); common_count.append(paramsAndMethod[j]); } if
	 * (upperString.contains(" GROUP BY ")) { throw new RuntimeException(
	 * "不支持group by 分页,请自行提供sql语句以 查询语句+_count结尾."); } return
	 * return_sql.append(common_count).toString(); }
	 *//**
	 * 计算总条数
	 * <p>
	 * 
	 * @param parameterObj
	 * @param countSql
	 * @param connection
	 * @return
	 */
	/*
	 * protected int getTotalSize(Configuration configuration, MappedStatement
	 * mappedStatement, BoundSql boundSql, String countSql, Connection
	 * connection, Object parameter) throws SQLException { PreparedStatement
	 * stmt = null; ResultSet rs = null; int totalSize = 0; try {
	 * ParameterHandler handler = configuration.newParameterHandler(
	 * mappedStatement, parameter, boundSql); stmt =
	 * connection.prepareStatement(countSql); handler.setParameters(stmt); rs =
	 * stmt.executeQuery(); if (rs.next()) { totalSize = rs.getInt(1); } } catch
	 * (SQLException e) { throw e; } finally { if (rs != null) { rs.close(); rs
	 * = null; } if (stmt != null) { stmt.close(); stmt = null; } } return
	 * totalSize; }
	 *//**
	 * 寻找page对象
	 * <p>
	 * 
	 * @param parameter
	 */
	/*
	 * @SuppressWarnings("rawtypes") protected Page seekPage(Object parameter) {
	 * Page page = null; if (parameter == null) { return null; } if (parameter
	 * instanceof Page) { page = (Page) parameter; } else if (parameter
	 * instanceof Map) { Map map = (Map) parameter; for (Object arg :
	 * map.values()) { if (arg instanceof Page) { page = (Page) arg; } } }
	 * return page; }
	 * 
	 * public Object plugin(Object target) { return Plugin.wrap(target, this); }
	 * 
	 * public void setProperties(Properties properties) { }
	 */

}
