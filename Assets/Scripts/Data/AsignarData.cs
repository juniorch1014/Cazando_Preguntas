using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]

public class AsignarData
{
    public string NombreEvaluacion;
    
    public AsignarData() { }

    public AsignarData(string nombreEvaluacion)
    {
        this.NombreEvaluacion = nombreEvaluacion;
    }
    public string ObtenerNomEvaluacion()
    {
        return NombreEvaluacion;
    }
    
}
