using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Registrar_Controller : MonoBehaviour
{
    public TMP_InputField  inputfPregunta;
    public TMP_InputField  inputfRespuesta;
    public TMP_InputField  inputfA;
    public TMP_InputField  inputfB;
    public TMP_InputField  inputfC;
    public TMP_InputField  inputfD;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void vaciarEspacios(){
        inputfPregunta.text  = "";
        inputfRespuesta.text = "";
        inputfA.text         = "";
        inputfB.text         = "";
        inputfC.text         = "";
        inputfD.text         = "";
    }
}
