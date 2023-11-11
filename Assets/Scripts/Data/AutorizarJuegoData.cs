using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class AutorizarJuegoData
{
    public int ID_AutJugar;
    public int ID_Docente;
    public int Generar_Codigo;

    public AutorizarJuegoData() {

    }
    public AutorizarJuegoData(int idAJugar, int idDocente, int gCodigo){
        this.ID_AutJugar    = idAJugar;
        this.ID_Docente     = idDocente;
        this.Generar_Codigo = gCodigo;
    }
}
