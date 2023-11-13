using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]

public class EvaluacionData
{
    public int Id_Evaluacion;
    public int Id_Docente;
    public string Nombre;
    public string Grado;
    public string Seccion;
    public string Estado;
    public List<AsignarPreguntaData> AsignarPregunta;

    public EvaluacionData() { }

    public EvaluacionData (int id_Evaluacion, 
                              int id_Docente, 
                               string nombre, 
                                string grado, 
                              string seccion,
                               string estado)
    {
        this.Id_Evaluacion = id_Evaluacion;
        this.Id_Docente = id_Docente;
        this.Nombre = nombre;
        this.Grado = grado;
        this.Seccion = seccion;
        this.Estado = estado;
        this.AsignarPregunta = new List<AsignarPreguntaData> ();
    }
}
