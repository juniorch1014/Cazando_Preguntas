using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    public GameObject bt_Preguntas;
    public GameObject bt_PreguntasText;
    public GameObject bt_REstudiante;
    public GameObject bt_REstudianteText;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
//***Iniciar Sesion
    public void MostrarVentanaInSesion (){
        ventanaInSesion.SetActive(true);
    }
    public void OcultarVentanaInSesion(){
        ventanaInSesion.SetActive(false);
    }
//***Inicio
    public void MostrarVentanaInicio (){
        ventanaInicio.SetActive(true);
        ventanaInSesion.SetActive(false);
        ventanaLogin.SetActive(false);
    }
    public void OcultarVentanaInicio (){
        ventanaInicio.SetActive(false);
        ventanaLogin.SetActive(true);
    }
//***Docente_Registrar
    public void MostrarVenRegistrarDoc (){
        ventanaRegistrar_DocEst.SetActive(true);
        ventanaLogin.SetActive(false);

    }
    public void OcultarVenRegistrarDoc (){
        ventanaRegistrar_DocEst.SetActive(false);
        ventanaLogin.SetActive(true);

    }
//***Estudiante_Registrar
    public void MostrarVenRegistrarEst (){
        ventanaRegistrar_Estudiante.SetActive(true);
        ventanaInicio.SetActive(false);
    }
    public void OcultarVenRegistrarEst (){
        ventanaRegistrar_Estudiante.SetActive(false);
        ventanaInicio.SetActive(true);       
    }

//***CRUD_Pregunta
    public void MostrarVCRUD_Pregunta (){
        ventanaInicio.SetActive(false);
        ventanaCRUD_Pregunta.SetActive(true);
    }
    public void OcultarVCRUD_Pregunta (){
        ventanaInicio.SetActive(true);
        ventanaCRUD_Pregunta.SetActive(false);
    }
//***Botton Pregunda_Estudiante
    public void MostrarBtPregunta (){
        bt_Preguntas.SetActive(true);
        bt_PreguntasText.SetActive(true);
        bt_REstudiante.SetActive(true);
        bt_REstudianteText.SetActive(true);

    }
    public void OcultarBtPregunta (){
        bt_Preguntas.SetActive(false);
        bt_PreguntasText.SetActive(false);
        bt_REstudiante.SetActive(false);
        bt_REstudianteText.SetActive(false);
    }
//***PREGUTAS Registrar
    public void MostrarVenRegistrarPregunta(){
        ventanaRegistrar_Pregunta.SetActive(true);
        ventanaCRUD_Pregunta.SetActive(false);
    }
    public void OcultarVenRegistrarPregunta(){
        ventanaRegistrar_Pregunta.SetActive(false);
        ventanaCRUD_Pregunta.SetActive(true);
    }
//***PREGUNTAS Actualizar
    public void MostrarVenActualizarPregunta(){
        ventanaActualizar_Pregunta.SetActive(true);
        ventanaCRUD_Pregunta.SetActive(false);
    }
    public void OcultarVenActualizarPregunta(){
        ventanaActualizar_Pregunta.SetActive(false);
        ventanaCRUD_Pregunta.SetActive(true);
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
