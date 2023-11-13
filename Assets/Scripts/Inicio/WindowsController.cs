using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WindowsController : MonoBehaviour
{

    public GameObject ventanaLogin;
    public GameObject ventanaInSesion;
    public GameObject ventanaInicio;
    public GameObject ventanaCRUD_Pregunta;
    public GameObject ventanaRegistrar_Pregunta;
    public GameObject ventanaActualizar_Pregunta;
    public GameObject ventanaRegistrar_DocEst;
    public GameObject ventanaRegistrar_Estudiante;
    public GameObject ventanaCRUD_Estudiante;
    public GameObject ventanaUREditar_Estudiante;
    public GameObject ventanaMostrar_Estudiante;
    public GameObject ventanaActualizar_Estudiante;
    public GameObject ventanaUREditar_Pregunta;
    public GameObject ventanaRegistrar_Evaluacion;
    public GameObject ventanaCVer_Evaluacion;

    public GameObject ventanaVer_Puntaje;


    public GameObject bt_Preguntas;
    public GameObject bt_PreguntasText;
    public GameObject bt_REstudiante;
    public GameObject bt_REstudianteText;
    public GameObject bt_CrearEvaluacion;
    public GameObject bt_VerEvaluacion;
    public GameObject bt_VerCVerEvaluacion;
    public GameObject bt_EliminarCVerEvaluacion;
    public GameObject bt_IniciarCVEvaluacion;
    public GameObject bt_Jugar;

    public GameObject bt_JugarText;  
    public static WindowsController instance;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    //***Iniciar Sesion
    public void MostrarVentanaInSesion() {
        ventanaInSesion.SetActive(true);
    }
    public void OcultarVentanaInSesion() {
        ventanaInSesion.SetActive(false);
    }
    //***Inicio
    public void MostrarVentanaInicio() {
        ventanaInicio.SetActive(true);
        ventanaInSesion.SetActive(false);
        ventanaLogin.SetActive(false);
    }   
    public void OcultarVentanaInicio() {
        ventanaInicio.SetActive(false);
        ventanaLogin.SetActive(true);

        ventanaCVer_Evaluacion.SetActive(false);
        ventanaVer_Puntaje.SetActive(false);
    }
    //***Docente_Registrar
    public void MostrarVenRegistrarDoc() {
        ventanaRegistrar_DocEst.SetActive(true);
        ventanaLogin.SetActive(false);

    }
    public void OcultarVenRegistrarDoc() {
        ventanaRegistrar_DocEst.SetActive(false);
        ventanaLogin.SetActive(true);

    }
    //***Estudiante_Registrar
    public void MostrarVenRegistrarEst() {
        ventanaRegistrar_Estudiante.SetActive(true);
        ventanaCRUD_Estudiante.SetActive(false);
    }
    public void OcultarVenRegistrarEst() {
        ventanaRegistrar_Estudiante.SetActive(false);
        ventanaCRUD_Estudiante.SetActive(true);
    }

    public void MostrarVenActualizarEstudiante() {
        ventanaActualizar_Estudiante.SetActive(true);
        ventanaCRUD_Estudiante.SetActive(false);
    }
    public void OcultarVenActualizarEstudiante() {
        ventanaActualizar_Estudiante.SetActive(false);
        ventanaCRUD_Estudiante.SetActive(true);

    }
    public void MostrarVenMostrarEstudiante() {
        ventanaMostrar_Estudiante.SetActive(true);
        ventanaCRUD_Estudiante.SetActive(false);
    }
    public void OcultarVenMostrarEstudiante() {
        ventanaMostrar_Estudiante.SetActive(false);
        ventanaCRUD_Estudiante.SetActive(true);

    }

    public void MostrarVentanaEditarEstudiante() {
        ventanaUREditar_Estudiante.SetActive(true);
    }
    public void OcultarVentanaEditarEstudiante() {
        ventanaUREditar_Estudiante.SetActive(false);
    }

    //***CRUD_Pregunta
    public void MostrarVCRUD_Pregunta() {
        ventanaInicio.SetActive(false);
        ventanaCRUD_Pregunta.SetActive(true);
    }
    public void OcultarVCRUD_Pregunta() {
        ventanaInicio.SetActive(true);
        ventanaCRUD_Pregunta.SetActive(false);
    }
    //***CRUD_Estudiante
    public void MostrarVCRUD_Estudiante() {
        ventanaInicio.SetActive(false);
        ventanaCRUD_Estudiante.SetActive(true);
    }
    public void OcultarVCRUD_Estudiante() {
        ventanaInicio.SetActive(true);
        ventanaCRUD_Estudiante.SetActive(false);
    }
    //***Botton Pregunda_Estudiante
    public void MostrarBtPregunta() {
        bt_Preguntas.SetActive(true);
        bt_PreguntasText.SetActive(true);
        bt_REstudiante.SetActive(true);
        bt_REstudianteText.SetActive(true);
        bt_CrearEvaluacion.SetActive(true);
        bt_VerEvaluacion.SetActive(true);
        bt_VerCVerEvaluacion.SetActive(true);
        bt_EliminarCVerEvaluacion.SetActive(true);
        bt_Jugar.SetActive(false);
        bt_IniciarCVEvaluacion.SetActive(false);

    }
    public void OcultarBtPregunta() {
        bt_Preguntas.SetActive(false);
        bt_PreguntasText.SetActive(false);
        bt_REstudiante.SetActive(false);
        bt_REstudianteText.SetActive(false);
        bt_CrearEvaluacion.SetActive(false);
        bt_VerEvaluacion.SetActive(false);
        bt_VerCVerEvaluacion.SetActive(false);
        bt_EliminarCVerEvaluacion.SetActive(false);
        bt_Jugar.SetActive(true);
        bt_IniciarCVEvaluacion.SetActive(true);
    }
    //***PREGUTAS Registrar
    public void MostrarVenRegistrarPregunta() {
        ventanaRegistrar_Pregunta.SetActive(true);
        ventanaCRUD_Pregunta.SetActive(false);
    }
    public void OcultarVenRegistrarPregunta() {
        ventanaRegistrar_Pregunta.SetActive(false);
        ventanaCRUD_Pregunta.SetActive(true);
    }
    //***PREGUNTAS Actualizar
    public void MostrarVentanaUREditPregunta() {
        ventanaUREditar_Pregunta.SetActive(true);
    }
    public void OcultarVentanaUREditPregunta() {
        ventanaUREditar_Pregunta.SetActive(false);
    }
    public void MostrarVenActualizarPregunta() {
        ventanaActualizar_Pregunta.SetActive(true);
        ventanaCRUD_Pregunta.SetActive(false);
    }
    public void OcultarVenActualizarPregunta() {
        ventanaActualizar_Pregunta.SetActive(false);
        ventanaCRUD_Pregunta.SetActive(true);
    }
    //***EVALUACION Registrar
    public void MostrarVenRegistrarEvaluacion()
    {
        ventanaRegistrar_Evaluacion.SetActive(true);
    }
    public void OcultarVenRegistrarEvaluacion()
    {
        ventanaRegistrar_Evaluacion.SetActive(false);
    }
    //***EVALUACION VER
    public void MostrarVenCVerEvaluacion()
    {
        ventanaCVer_Evaluacion.SetActive(true);
    }
    public void OcultarVenCVerEvaluacion()
    {
        ventanaCVer_Evaluacion.SetActive(false);
    }

    public void MostrarVenVerPuntaje()
    {
        ventanaVer_Puntaje.SetActive(true);
        ventanaCVer_Evaluacion.SetActive(false);
    }
    public void OcultarVenVerPuntaje()
    {
        ventanaVer_Puntaje.SetActive(false);
        ventanaCVer_Evaluacion.SetActive(true);
    }
    public void ScenaJugar(string scena) {
        SceneManager.LoadScene(scena);
    }




    //***Salir
    public void SalirPlay(){
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #else
            Application.Quit();
        #endif
    }

}
