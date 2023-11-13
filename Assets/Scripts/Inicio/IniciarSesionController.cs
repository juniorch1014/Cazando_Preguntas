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
       // estudianteRepository.LoadingDataEstudiante();
       // MostrarListaEnLogEstudiante();
    }
    public void IniciarSesionDocente() {
        listaDocentes   = docenteRepository.LoadingDataDocente();

        if(InputF_ID.text != "" && InputF_Pass.text != "") 
        {
            foreach (var docente in listaDocentes) {
                if (InputF_ID.text == docente.Email && InputF_Pass.text == docente.Contraseña) {
                    IniciarDocente();
                    loginData = new LoginData(docente.Id_Docente,"Docente");
                    loginRepository.SaveDataLogin(loginData);
                    docente.Estado = "Conectado";
                    docenteRepository.SaveDataDocente(listaDocentes);
                    Limpiar();

                }else{
                    txNotificacionError.text = "ID o Contrasela Erroneas";
                }
                MostrarListaDocentes(docente);
            }
            listaEstudiantes   = estudianteRepository.LoadingDataEstudiante();
            foreach (var estudiante in listaEstudiantes) {
                if (InputF_ID.text == estudiante.Email && InputF_Pass.text == estudiante.Contraseña) {
                    IniciarAlumno();
                    loginData = new LoginData(estudiante.id_Estudiante,"Estudiante");
                    loginRepository.SaveDataLogin(loginData);
                    estudiante.Estado = "Conectado";
                    estudianteRepository.SaveDataEstudiante(listaEstudiantes);
                    Limpiar();
                }else{
                    txNotificacionError.text = "ID o Contrasela Erroneas";
                }
                MostrarListaEstudiante(estudiante);

            }
        } else{
             txNotificacionError.text = "Llenar los espacios en Blanco";
        }
        listaLogin = loginRepository.LoadDataLogin();
        listaDocentes =  docenteRepository.LoadingDataDocente();
        listaEstudiantes = estudianteRepository.LoadingDataEstudiante();
        MostrarListaEnLogEstudiante();
        MostrarLoginData(listaLogin);
 
    }
    public void Cerrar_Sesion()
    {
        listaLogin = loginRepository.LoadDataLogin();
        listaDocentes = docenteRepository.LoadingDataDocente();
        if (listaLogin.Tipo_Usuario == "Docente")
        {
            foreach (var docente in listaDocentes)
            {

                if (listaLogin.Id_Usuario == docente.Id_Docente)
                {
                    if (docente.Estado == "Conectado")
                    {
                        docente.Estado = "Desconectado";
                        docenteRepository.SaveDataDocente(listaDocentes);
                        listaDocentes = docenteRepository.LoadingDataDocente();
                        loginRepository.DeleteDataLogin();

                    }
                }
                MostrarListaDocentes(docente);

            }
        }
        listaEstudiantes = estudianteRepository.LoadingDataEstudiante();

        if (listaLogin.Tipo_Usuario == "Estudiante")
        {
            foreach (var estudiante in listaEstudiantes)
            {
                if (listaLogin.Id_Usuario == estudiante.id_Estudiante)
                {
                    if (estudiante.Estado == "Conectado")
                    {
                        estudiante.Estado = "Desconectado";
                        estudianteRepository.SaveDataEstudiante(listaEstudiantes);
                        listaEstudiantes = estudianteRepository.LoadingDataEstudiante();
                        loginRepository.DeleteDataLogin();

                    }
                }
                MostrarListaEstudiante(estudiante);

            }
        }
        listaLogin = loginRepository.LoadDataLogin();
        listaDocentes =  docenteRepository.LoadingDataDocente();
        listaEstudiantes = estudianteRepository.LoadingDataEstudiante();
        MostrarListaEnLogDocente();
        MostrarListaEnLogEstudiante();
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
            Debug.Log($"Docente--ID: {docente.Id_Docente}, " +
                           $"Nombre: {docente.Nombre}, " +
                         $"Apellido: {docente.Apellido}, " +
                             $"User: {docente.Email}, " +
                             $"Pass: {docente.Contraseña}, " +
                             $"Estado: {docente.Estado}");
    }
    public void MostrarListaEstudiante(EstudianteData estudiante)
    {
            Debug.Log($"Estudiante--ID: {estudiante.id_Estudiante}, " +
                              $"Nombre: {estudiante.Nombre}, " +
                            $"Apellido: {estudiante.Apellido}, " +
                                $"User: {estudiante.Email}, " +
                                $"Pass: {estudiante.Contraseña}, " +
                              $"Estado: {estudiante.Estado}");  
    }
    public void MostrarLoginData(LoginData login) {
        Debug.Log($"IDLogin: {login.Id_Usuario}, " +
                     $"Tipo: {login.Tipo_Usuario}");
    }
    public void MostrarListaEnLogDocente()
    {
        listaDocentes = docenteRepository.LoadingDataDocente();
        foreach (var docente in listaDocentes)
        {
            Debug.Log($"Docente_IniciarSesion - ID: {docente.Id_Docente}, " +
                                      $"Nombre: {docente.Nombre}, " +
                                    $"Apellido: {docente.Apellido}, " +
                                        $"User: {docente.Email}, " +
                                        $"Pass: {docente.Contraseña}, " +
                                      $"Estado: {docente.Estado}");

        }
    }
    public void MostrarListaEnLogEstudiante()
    {
        listaEstudiantes = estudianteRepository.LoadingDataEstudiante();
        foreach (var estudiante in listaEstudiantes)
        {
            Debug.Log(message: $"Estudiante_IniciarSesion - ID: {estudiante.id_Estudiante}, " +
                                                  $"Nombre: {estudiante.Nombre}, " +
                                                $"Apellido: {estudiante.Apellido}, " +
                                                    $"User: {estudiante.Email}, " +
                                                    $"Pass: {estudiante.Contraseña}, " +
                                                  $"Id_Doc: {estudiante.Id_Docente}, " +
                                                  $"Estado: {estudiante.Estado}");
        }
    }
}
