using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class IniciarSesionController : MonoBehaviour
{   
    List<DocenteData> listaDocentes = new List<DocenteData>();
    public DocenteRepository docenteRepository;
    public WindowsController wc;
    public TMP_InputField InputF_ID;
    public TMP_InputField InputF_Pass;

  
    // Start is called before the first frame update
    void Start()
    {
        
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void IniciarSesionDocente() {
        listaDocentes   = docenteRepository.LoadingDataDocente();
        MostrarListaEnLog();
        foreach (var docente in listaDocentes) {
            Debug.Log($"ID: {docente.id_Docente}, Nombre: {docente.Nombre}, Apellido: {docente.Apellido}");
            if (InputF_ID.text == docente.Email && InputF_Pass.text == docente.Contraseña) {
                wc.MostrarVentanaInicio();
                wc.MostrarBtPregunta();
            }
            
        }
        
        InputF_ID.text   = "";
        InputF_Pass.text = "";
       
    }

    public void IniciarAlumno(){
        wc.MostrarVentanaInicio();
        wc.OcultarBtPregunta();
    }
    public void MostrarListaEnLog()
    {
        foreach (var docente in listaDocentes)
        {
            Debug.Log($"ID: {docente.id_Docente}, Nombre: {docente.Nombre}, Apellido: {docente.Apellido}, User: {docente.Email}, Pass: {docente.Contraseña}");
        }
    }
}
