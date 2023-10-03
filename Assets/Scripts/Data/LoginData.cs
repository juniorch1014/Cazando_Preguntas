using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class LoginData
{
  
    public int id_Usuario;
    public string Tipo_Usuario;
    public LoginData(){

    }

    public LoginData(int id, string tipo){
        this.id_Usuario    = id;
        this.Tipo_Usuario   =tipo;
    }
    public int ObtenerLoginID(){
        return id_Usuario;
    }
    public string ObtenerLoginTipo(){
        return Tipo_Usuario;
    } 
}
