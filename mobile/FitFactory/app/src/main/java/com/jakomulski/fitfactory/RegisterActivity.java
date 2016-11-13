package com.jakomulski.fitfactory;

import android.support.v7.app.AppCompatActivity;
import android.os.Bundle;
import android.view.View;
import android.widget.Button;
import android.widget.EditText;
import com.jakomulski.fitfactory.dao.DBAccessObject;

public class RegisterActivity extends AppCompatActivity {

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_register);

        EditText login = (EditText) findViewById(R.id.login);
        EditText password = (EditText) findViewById(R.id.password);
        EditText email = (EditText) findViewById(R.id.email);
        EditText name = (EditText) findViewById(R.id.name);
        EditText lastname = (EditText) findViewById(R.id.lastname);
        EditText birthdate = (EditText) findViewById(R.id.birthdate);


        Button mEmailSignInButton = (Button) findViewById(R.id.sign_in_button);
        //mEmailSignInButton.setOnClickListener((e) -> {
        //});
        //db.addUser(login.toString(), email.toString(), name.toString(), lastname.toString(), 'M', birthdate.toString(), password.toString());
    }
}
