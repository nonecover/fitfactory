package com.jakomulski.fitfactory.dao;


import android.os.StrictMode;
import android.util.Log;


import java.sql.*;


public class DBAccessObject {

    private static final String USER = "fitfactoryadmin";
    private static final String PASSWORD = "&(@#(*$yh383";
    private static final String SERVER = "fitfactory.database.windows.net:1433";
    private static final String DATABASE = "fitfactory_database";

    private static final Character USER_TYPE = 'U';
    private Connection connection = null;

    public DBAccessObject() {
        StrictMode.ThreadPolicy policy = new StrictMode.ThreadPolicy.Builder()
                .permitAll().build();
        StrictMode.setThreadPolicy(policy);

        String ConnectionURL = null;
        try {
            //new net.sourceforge.jtds.jdbc.Driver();
            Class.forName("net.sourceforge.jtds.jdbc.Driver");
            ConnectionURL = "jdbc:jtds:sqlserver://" + SERVER + ";"
                    + "databaseName=" + DATABASE + ";user=" + USER
                    + ";password=" + PASSWORD + ";";
            connection = DriverManager.getConnection(ConnectionURL);
        } catch (SQLException se) {
            Log.e("ERRO", se.getMessage());
            //} catch (Exception e) {
            //  Log.e("ERRO", e.getMessage());
        } catch (ClassNotFoundException se) {
            Log.e("ERRO", se.getMessage());
        }


    }

    public void addUser(String login, String email, String name, String lastName, Character sex, String birthDate, String password) {
        Statement stmt = null;
        try {
            stmt = connection.createStatement();
            ResultSet reset = stmt.executeQuery(" INSERT INTO UZYTKOWNICY (login, mail, imie, nazwisko, plec, data_ur, status_rej, haslo, typ ) " +
                    "VALUES ('" + login +
                    "', '" + email +
                    "', '" + name +
                    "', '" + lastName +
                    "', '" + sex +
                    "', '" + birthDate +
                    "', '" + 0 +
                    "', '" + password +
                    "', '" + USER_TYPE +
                    "')");

            Log.wtf("UZYTKOWNICY", reset.getStatement().toString());
        } catch (SQLException e) {
            Log.e("ERRO", e.getMessage());
        }
    }


}
