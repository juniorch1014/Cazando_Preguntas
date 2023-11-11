using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class AsignarPreguntaData
{
    public int ID_AsigPregunta;
    public int ID_Evaluacion;
    public int ID_Estudiante;
    public int ID_Pregunta;
    public string Estado;

    public AsignarPreguntaData() {

    }
    public AsignarPreguntaData(int idAPRegunta, int idEvaluacion,int idEstudiante, int idPregunta, string estado){

        this.ID_AsigPregunta    = idAPRegunta;
        this.ID_Evaluacion      = idEvaluacion;
        this.ID_Estudiante      = idEstudiante;
        this.ID_Pregunta        = idPregunta;
        this.Estado             = estado;
        
    }
}
