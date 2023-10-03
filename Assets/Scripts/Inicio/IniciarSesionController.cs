using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class IniciarSesionController : MonoBehaviour
{   
    List<DocenteData> listaDocentes = new List<DocenteData>();
    List<EstudianteData> listaEstudiantes = new List<EstudianteData>();
    public LoginData loginData;
    public DocenteRepository docenteRepository;
     public EstudianteRepository estudianteRepository;
    public WindowsController wc;
    public TMP_InputField InputF_ID;
    public TMP_InputField InputF_Pass;
    public TMP_Text txMostrarUsuario;
    public TMP_Text txMostrarUsuarioR;
  
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
        foreach (var docente in listaDocentes) {
            MostrarListaDocentes(docente);
            if (InputF_ID.text == docente.Email && InputF_Pass.text == docente.Contraseña) {
                IniciarDocente();
                loginData = new LoginData(docente.id_Docente,"Docente");
                Debug.Log("LoginData: "+ loginData.ObtenerLoginID() + "-- Tipo: " + loginData.ObtenerLoginTipo());
            }
            
        }
        listaEstudiantes   = estudianteRepository.LoadingDataEstudiante();
        foreach (var estudiante in listaEstudiantes) {
            MostrarListaEstudiante(estudiante);
            if (InputF_ID.text == estudiante.Email && InputF_Pass.text == estudiante.Contraseña) {
                IniciarAlumno();
                loginData = new LoginData(estudiante.id_Estudiante,"Estudiante");
                Debug.Log("LoginData: "+ loginData.ObtenerLoginID() + "-- Tipo: " + loginData.ObtenerLoginTipo());
            }
            
        }

        
        InputF_ID.text   = "";
        InputF_Pass.text = "";
       
    }
    public void Mostrarusuario (){
        if(loginData.ObtenerLoginTipo() == "Docente"){
            foreach (var docente in listaDocentes)
            {
                if (docente.id_Docente == loginData.ObtenerLoginID())
                {
                   txMostrarUsuario.text  = $"DOCENTE: {docente.Nombre} {docente.Apellido} ";
                   txMostrarUsuarioR.text = $"DOCENTE: {docente.Nombre} {docente.Apellido} ";
                
                }
            }
        }
        if(loginData.ObtenerLoginTipo() == "Estudiante"){
            foreach (var estudiante in listaEstudiantes)
            {
                if (estudiante.id_Estudiante == loginData.ObtenerLoginID())
                {
                   txMostrarUsuario.text = $"DOCENTE: {estudiante.Nombre}{estudiante.Apellido} ";
                   txMostrarUsuarioR.text = $"DOCENTE: {estudiante.Nombre}{estudiante.Apellido} ";
                     
                 }
            }
        }
    }
    public void IniciarDocente (){
        wc.MostrarVentanaInicio();
        wc.MostrarBtPregunta();
    }
    public void IniciarAlumno(){
        wc.MostrarVentanaInicio();
        wc.OcultarBtPregunta();
    }
    public void MostrarListaDocentes(DocenteData docente)
    {
            Debug.Log($"Docente--ID: {docente.id_Docente}, Nombre: {docente.Nombre}, Apellido: {docente.Apellido}, User: {docente.Email}, Pass: {docente.Contraseña}");
    }
    public void MostrarListaEstudiante(EstudianteData estudiante)
    {
            Debug.Log($"Estudiante--ID: {estudiante.id_Estudiante}, Nombre: {estudiante.Nombre}, Apellido: {estudiante.Apellido}, User: {estudiante.Email}, Pass: {estudiante.Contraseña}");  
    }
}
