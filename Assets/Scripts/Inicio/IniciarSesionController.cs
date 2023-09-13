using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class IniciarSesionController : MonoBehaviour
{
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
    public void IniciarSesionProfesor(){
        if (InputF_ID.text == "admin" && InputF_Pass.text == "admin")
        {
            wc.MostrarVentanaInicio();
            wc.MostrarBtPregunta();
        }
        InputF_ID.text   = "";
        InputF_Pass.text = "";
    }

    public void IniciarAlumno(){
        wc.MostrarVentanaInicio();
        wc.OcultarBtPregunta();
    }
}
