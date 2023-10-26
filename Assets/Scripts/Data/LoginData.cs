using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class LoginData
{
  
    public int Id_Usuario;
    public string Tipo_Usuario;
    public LoginData(){

    }

    public LoginData(int id, string tipo){
        this.Id_Usuario    = id;
        this.Tipo_Usuario  = tipo;
    }
    public int ObtenerLoginID(){
        return Id_Usuario;
    }
    public string ObtenerLoginTipo(){
        return Tipo_Usuario;
    } 
}
