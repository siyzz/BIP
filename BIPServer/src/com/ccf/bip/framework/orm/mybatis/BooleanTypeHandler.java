package com.ccf.bip.framework.orm.mybatis;

import java.sql.CallableStatement;
import java.sql.PreparedStatement;
import java.sql.ResultSet;
import java.sql.SQLException;

import org.apache.ibatis.type.JdbcType;
import org.apache.ibatis.type.TypeHandler;

/*
 * @filename:BooleanTypeHandler.java
 * Modification History:
 * Version         Author      Date     Description
 * --------------------------------------------------------------
 *  V1.0           siy    2016年6月14日     初版
 * 
 *
 * @Copyright CCF All Rights Reserved.
 */
public class BooleanTypeHandler implements TypeHandler<Boolean> {

	public Boolean getResult(ResultSet arg0, String arg1) throws SQLException {
		// TODO Auto-generated method stub
		String str = arg0.getString(arg1);		
		return str != null && (str.equalsIgnoreCase("Y") || str.equals("1"));
	}

	public Boolean getResult(ResultSet arg0, int arg1) throws SQLException {
		// TODO Auto-generated method stub
		String str = arg0.getString(arg1);	
		return str != null && (str.equalsIgnoreCase("Y") || str.equals("1"));
	}

	public Boolean getResult(CallableStatement arg0, int arg1) throws SQLException {
		// TODO Auto-generated method stub
		String str = arg0.getString(arg1);
		return str != null && (str.equalsIgnoreCase("Y") || str.equals("1"));
	}

	public void setParameter(PreparedStatement arg0, int arg1, Boolean arg2, JdbcType arg3) throws SQLException {
		// TODO Auto-generated method stub
		arg0.setString(arg1, arg2 ? "1" : "0");
	}

}
