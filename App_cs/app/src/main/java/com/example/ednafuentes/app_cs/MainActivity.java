package com.example.ednafuentes.app_cs;

import android.content.Intent;

import android.support.v7.app.AppCompatActivity;
import android.os.Bundle;
import android.view.View;
import android.widget.ArrayAdapter;
import android.widget.Button;
import android.widget.ListView;
import android.widget.Toast;


import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStream;
import java.io.InputStreamReader;
import java.util.ArrayList;
import java.util.List;

import static com.example.ednafuentes.app_cs.R.id.text;

public class MainActivity extends AppCompatActivity {
    ListView lista;


    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);
        lista = (ListView) findViewById(R.id.lvlista);

        //codigo para boton de salir
        final Button boton_salida = (Button) findViewById(R.id.exit_button);
        boton_salida.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                finish();
                Intent intent = new Intent(Intent.ACTION_MAIN);
                intent.addCategory(Intent.CATEGORY_HOME);
                intent.setFlags(Intent.FLAG_ACTIVITY_NEW_TASK);
                startActivity(intent);

            }
        });
        lista.setOnItemClickListener(this);


    }
    public void CargaDatos(View view) throws IOException {
        List<String> listado = new ArrayList<String>();
        String linea;

        InputStream is =this.getResources().openRawResource(R.raw.data);
        BufferedReader reader =new BufferedReader(new InputStreamReader(is));
        if(is !=null){
            while((linea=reader.readLine())!= null){
                // formato de como sale en la aplicacion concateno las posiciones
                listado.add(linea.split("         ")[0] + " " + linea.split("         ")[1] + " " + linea.split("         ")[2]);
            }
        }
        is.close();
        Toast.makeText(this, "Carga:" + listado.size(), Toast.LENGTH_LONG).show();

        String datos[] = listado.toArray(new String[listado.size()]);
        ArrayAdapter<String> adapter = new ArrayAdapter<String>(this,android.R.layout.simple_list_item_1,datos);
        lista.setAdapter(adapter);


    }


}
