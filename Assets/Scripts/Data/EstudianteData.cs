using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class EstudianteData
{
    private static int nextId = 1;

    public int id_Estudiante;
    public string Nombre;
    public string Apellido;
    public string Email;
    public string Contraseña;
    public int Id_Docente;

    public EstudianteData(){

    }

    public EstudianteData(string nombre, string apellido, string email, string contraseña, int id_Docente){
        
        this.id_Estudiante = nextId;
        this.Nombre        = nombre;
        this.Apellido      = apellido;
        this.Email         = email;
        this.Contraseña    = contraseña;
        this.Id_Docente    = id_Docente;   
        nextId++;
    }
}
