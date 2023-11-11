using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameWindowController : MonoBehaviour
{
    public GameObject ventanaCazarPreguntas;


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
}
