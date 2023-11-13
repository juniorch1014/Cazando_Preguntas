using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PreguntaData
{
    public int Id_Pregunta;
    public int Id_Docente;
    public string Enunciado;
    public string Respuesta;
    
    public PreguntaData(){}
    
    public PreguntaData(int id_P, int id_D, string enunciado, string respuesta){
        this.Id_Pregunta  = id_P;
        this.Id_Docente   = id_D;
        this.Enunciado    = enunciado;
        this.Respuesta    = respuesta;
    }
}
