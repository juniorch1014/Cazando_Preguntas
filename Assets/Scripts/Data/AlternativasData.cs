using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class AlternativasData
{
    public int Id_Alternativas;
    public int Id_Pregunta;
    public string Alternativa_A;
    public string Alternativa_B;
    public string Alternativa_C;
    public string Alternativa_D;
    
    public AlternativasData(){}
    
    public AlternativasData(int id_A, int id_P, string altA, string altB, string altc, string altD){
        this.Id_Alternativas = id_A;
        this.Id_Pregunta     = id_P;
        this.Alternativa_A   = altA;
        this.Alternativa_B   = altB;
        this.Alternativa_C   = altc;
        this.Alternativa_D   = altD;
    }
}
