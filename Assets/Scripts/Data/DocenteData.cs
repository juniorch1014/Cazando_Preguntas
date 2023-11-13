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
    public string Estado;

    public DocenteData() {
        
    }
    public DocenteData(int idDocente, 
                       string nombre, 
                     string apellido, 
                        string email, 
                   string contraseña,
                       string estado){
        
        this.Id_Docente = idDocente;
        this.Nombre     = nombre;
        this.Apellido   = apellido;
        this.Email      = email;
        this.Contraseña = contraseña;
        this.Estado     = estado;
        nextId++;
    }

    
}
