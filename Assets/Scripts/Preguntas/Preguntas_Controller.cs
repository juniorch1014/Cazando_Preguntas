using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Preguntas_Controller : MonoBehaviour
{
    public TMP_Text scrollViewText;
    public List<string> textoLista = new List<string>();

    void Start()
    {
        // Agrega el texto de la lista al Text del ScrollView
        textoLista.Add("1. Cual es tu nombre?");
        textoLista.Add("1. Cual es tu nombre?");
        textoLista.Add("1. Cual es tu nombre?");
        textoLista.Add("1. Cual es tu nombre?");
        textoLista.Add("1. Cual es tu nombre?");
        textoLista.Add("1. Cual es tu nombre?");
        textoLista.Add("1. Cual es tu nombre?");
        textoLista.Add("1. Cual es tu nombre?");
        textoLista.Add("2. Cuantos años tienes?");
        textoLista.Add("2. Cuantos años tienes?");
        textoLista.Add("2. Cuantos años tienes?");
        textoLista.Add("2. Cuantos años tienes?");
        
    }
    public void agregarPreguntas(){
        

        scrollViewText.text = string.Join("\n", textoLista);
    }
}
