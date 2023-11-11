using System.Collections;
using System.Collections.Generic;
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


    public GameObject bt_Preguntas;
    public GameObject bt_PreguntasText;
    public GameObject bt_REstudiante;
    public GameObject bt_REstudianteText;
    public GameObject bt_CrearEvaluacion;
    public GameObject bt_Jugar;

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
        bt_Jugar.SetActive(false);

    }
    public void OcultarBtPregunta() {
        bt_Preguntas.SetActive(false);
        bt_PreguntasText.SetActive(false);
        bt_REstudiante.SetActive(false);
        bt_REstudianteText.SetActive(false);
        bt_CrearEvaluacion.SetActive(false);
        bt_Jugar.SetActive(true);
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
