using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System; 

public class Preguntas{
    public int Id;
    public string TextoPregunta;
       public Preguntas(int id, string texto)
        {
            Id = id;
            TextoPregunta = texto;
        }
}
public class Preguntas_Controller : MonoBehaviour
{
    public TMP_Text scrollViewText;
    public List<Preguntas> listaDePreguntas = new List<Preguntas>();
    public static string selectedItem;
    

    void Start()
    {   
        
        
        

        // Crear instancias de preguntas y agregarlas a la lista
        Preguntas pregunta1 = new Preguntas(1, "¿Cuál es tu nombre?");
        Preguntas pregunta2 = new Preguntas(2, "¿Cuál es tu edad?");

        listaDePreguntas.Add(pregunta1);
        listaDePreguntas.Add(pregunta2);
        
        // Agrega el texto de la lista al Text del ScrollView
        //textoLista = Add(001,"1. Cual es tu nombre?");
        // textoLista.Add("1. Cual es tu nombre?");
        // textoLista.Add("1. Cual es tu nombre?");
        // textoLista.Add("1. Cual es tu nombre?");
        // textoLista.Add("1. Cual es tu nombre?");
        // textoLista.Add("1. Cual es tu nombre?");
        // textoLista.Add("1. Cual es tu nombre?");
        // textoLista.Add("1. Cual es tu nombre?");
        // textoLista.Add("2. Cuantos años tienes?");
        // textoLista.Add("2. Cuantos años tienes?");
        // textoLista.Add("2. Cuantos años tienes?");
        // textoLista.Add("2. Cuantos años tienes?");
        
    }
    public void SetSelectedItem(string item)
    {
        selectedItem = item; // Capture the selected item
    }

    public void agregarPreguntas()
{
    // Initialize an empty string to accumulate the text
    string accumulatedText = "";

    foreach (Preguntas pregunta in listaDePreguntas)
    {
        // Append each question to the accumulated text
        accumulatedText += $"ID: {pregunta.Id}, Pregunta: {pregunta.TextoPregunta}\n";
    }

    // Set the accumulated text to the scrollViewText
    scrollViewText.text = accumulatedText;
}

}
