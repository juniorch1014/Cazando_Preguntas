using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class IniciarSesionController : MonoBehaviour
{   
    List<DocenteData> listaDocentes = new List<DocenteData>();
    List<EstudianteData> listaEstudiantes = new List<EstudianteData>();
    LoginData listaLogin = new LoginData();

    public LoginData loginData;
    public DocenteRepository docenteRepository;
    public EstudianteRepository estudianteRepository;
    public LoginRepository loginRepository;
    public WindowsController wc;
    public TMP_Text txNotificacionError;
    public TMP_InputField InputF_ID;
    public TMP_InputField InputF_Pass;
    public TMP_Text txMostrarUsuario;
    public TMP_Text txMostrarUsuarioR;
    public TMP_Text txMostrarUsuarioCRUDEs;

  
    // Start is called before the first frame update
    void Start()
    {
        listaDocentes = docenteRepository.LoadingDataDocente();
        listaEstudiantes = estudianteRepository.LoadingDataEstudiante();
        listaLogin = loginRepository.LoadDataLogin();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void IniciarSesionDocente() {
        listaDocentes   = docenteRepository.LoadingDataDocente();

        if(InputF_ID.text != "" && InputF_Pass.text != ""){
            foreach (var docente in listaDocentes) {
                MostrarListaDocentes(docente);
                if (InputF_ID.text == docente.Email && InputF_Pass.text == docente.Contraseña) {
                    IniciarDocente();
                    loginData = new LoginData(docente.Id_Docente,"Docente");
                    loginRepository.SaveDataLogin(loginData);
                    Limpiar();
                }else{
                    txNotificacionError.text = "ID o Contrasela Erroneas";
                }
                
            }
            listaEstudiantes   = estudianteRepository.LoadingDataEstudiante();
            foreach (var estudiante in listaEstudiantes) {
                MostrarListaEstudiante(estudiante);
                if (InputF_ID.text == estudiante.Email && InputF_Pass.text == estudiante.Contraseña) {
                    IniciarAlumno();
                    loginData = new LoginData(estudiante.id_Estudiante,"Estudiante");
                    loginRepository.SaveDataLogin(loginData);
                    Limpiar();
                }else{
                    txNotificacionError.text = "ID o Contrasela Erroneas";
                }
                
            }
        } else{
             txNotificacionError.text = "Llenar los espacios en Blanco";
        }
        listaLogin = loginRepository.LoadDataLogin();
        MostrarLoginData(listaLogin);

        
       
    }
    public void Mostrarusuario (){
        if(listaLogin.Tipo_Usuario == "Docente"){
            foreach (var docente in listaDocentes)
            {
                if (docente.Id_Docente == listaLogin.Id_Usuario)
                {
                    txMostrarUsuario.text       = $"DOCENTE: {docente.Nombre} {docente.Apellido} ";
                    txMostrarUsuarioR.text      = $"DOCENTE: {docente.Nombre} {docente.Apellido} ";
                    txMostrarUsuarioCRUDEs.text = $"DOCENTE: {docente.Nombre} {docente.Apellido} ";
                }
            }
        }
        if(listaLogin.Tipo_Usuario == "Estudiante"){
            foreach (var estudiante in listaEstudiantes)
            {
                if (estudiante.id_Estudiante == listaLogin.Id_Usuario)
                {
                   txMostrarUsuario.text       = $"ESTUDIANTE: {estudiante.Nombre} {estudiante.Apellido} ";
                   txMostrarUsuarioR.text      = $"ESTUDIANTE: {estudiante.Nombre} {estudiante.Apellido} ";
                   txMostrarUsuarioCRUDEs.text = $"ESTUDIANTE: {estudiante.Nombre} {estudiante.Apellido} ";  
                 }
            }
        }
    }

    public void Limpiar(){
        txNotificacionError.text = "";
        InputF_ID.text   = "";
        InputF_Pass.text = "";
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
            Debug.Log($"Docente--ID: {docente.Id_Docente}, Nombre: {docente.Nombre}, Apellido: {docente.Apellido}, User: {docente.Email}, Pass: {docente.Contraseña}");
    }
    public void MostrarListaEstudiante(EstudianteData estudiante)
    {
            Debug.Log($"Estudiante--ID: {estudiante.id_Estudiante}, Nombre: {estudiante.Nombre}, Apellido: {estudiante.Apellido}, User: {estudiante.Email}, Pass: {estudiante.Contraseña}");  
    }
    public void MostrarLoginData(LoginData login) {
        Debug.Log($"IDLogin: {login.Id_Usuario}, Tipo: {login.Tipo_Usuario}");
    }
}
