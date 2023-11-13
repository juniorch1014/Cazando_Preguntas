using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameWindowController : MonoBehaviour
{
    public GameObject ventanaCazarPreguntas;
    public GameObject ventanaPreFelicitacion;
    public GameObject ventanaGanaste;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void MostrarVentanaC_Preguntas() { 
        ventanaCazarPreguntas.SetActive(true);
    }
    public void OcultarVentanaC_Preguntas() { 
        ventanaCazarPreguntas.SetActive(false);
    }
    public void MostrarVentana_PreFelicidad()
    {
        ventanaPreFelicitacion.SetActive(true);
    }
    public void OcultarVentana_PreFelicidad()
    {
        ventanaPreFelicitacion.SetActive(false);
    }
    public void MostrarVentana_Ganaste()
    {
        ventanaGanaste.SetActive(true);
    }
    public void OcultarVentana_Ganaste()
    {
        ventanaGanaste.SetActive(false);
    }
}
