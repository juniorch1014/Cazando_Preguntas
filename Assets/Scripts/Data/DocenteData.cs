using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class DocenteData
{
    private static int nextId = 1;
    public int Id_Docente;
    public string Nombre;
    public string Apellido;
    public string Email;
    public string Contraseña;

    public DocenteData() {
        
    }
    public DocenteData(int idDocente, string nombre, string apellido, string email, string contraseña){
        
        this.Id_Docente = idDocente;
        this.Nombre     = nombre;
        this.Apellido   = apellido;
        this.Email      = email;
        this.Contraseña = contraseña;   
        nextId++;
    }

    
}
