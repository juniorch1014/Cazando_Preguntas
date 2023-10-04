using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PreguntaController : MonoBehaviour
{   
    public IniciarSesionController iniciarSesionController; 
    int idLoginUser;
    List<DocenteData> listDocentes = new List<DocenteData>();
    List<PreguntaData> listPreguntas = new List<PreguntaData>();
    List<AlternativasData> listAlternativas = new List<AlternativasData>();
    public DocenteRepository docenteRepository;
    public PreguntaRepository preguntaRepository;
    public AltenativaRepository altenativaRepository;

    WindowsController windowsController;
    //RegistrarPregunta
    public TMP_InputField inputFEnunciado;
    public TMP_InputField inputFRespuesta;
    public TMP_InputField inputFaltA;
    public TMP_InputField inputFaltB;
    public TMP_InputField inputFaltC;
    public TMP_InputField inputFaltD;

    int idPregunta = 0;
    int idAlternativa = 0;

    //Mostrar Pregunta
    public TMP_Text scrollVTMostrarPregunta;

    // Start is called before the first frame update
    void Start()
    {
        windowsController = GetComponent<WindowsController>();
        listDocentes     = docenteRepository.LoadingDataDocente();
        listPreguntas     = preguntaRepository.LoadingDataPregunta();
        listAlternativas  = altenativaRepository.LoadingDataAltenativa();

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Registrar_Preguntas(){

        if (inputFEnunciado.text == "" || inputFRespuesta.text == "" || inputFaltA.text == " " || inputFaltB.text == "" || inputFaltC.text == "" || inputFaltD.text == "")
        {
                Debug.Log("Llenar espacios en blanco");
        }else{
            //Preguntas
            idPregunta = listPreguntas.Count;
            PreguntaData preguntaData = new PreguntaData(idPregunta,
                                                         idLoginUser,
                                                         inputFEnunciado.text,
                                                         inputFRespuesta.text);
            listPreguntas.Add(preguntaData);
            preguntaRepository.SaveDataPregunta(listPreguntas);
            
            //Alternativas
            idAlternativa = listAlternativas.Count;
            AlternativasData alternativasData= new AlternativasData(idAlternativa,
                                                                    idPregunta,
                                                                    inputFaltA.text,
                                                                    inputFaltB.text,
                                                                    inputFaltC.text,
                                                                    inputFaltD.text);
            listAlternativas.Add(alternativasData);
            altenativaRepository.SaveDataAltenativa(listAlternativas);
            MostrarListaEnLog();
            vaciarEspacios();
            windowsController.OcultarVenRegistrarPregunta();
        }
    }
    public void MostrarPreguntas(){
        List<PreguntaData> listP = preguntaRepository.LoadingDataPregunta();
        string accumulatedText = "";
        foreach (var pregunta in listP){
            if(pregunta.id_Docente == idLoginUser){
                accumulatedText += $"ID: {pregunta.Id_Pregunta}, Enunciado: {pregunta.Enunciado}, Respuesta: {pregunta.Respuesta}\n";
            }
        }
        MostrarListaEnLog();
        scrollVTMostrarPregunta.text = accumulatedText;
    }
    public void vaciarEspacios(){
        inputFEnunciado.text    = "";
        inputFRespuesta.text    = "";
        inputFaltA.text         = "";
        inputFaltB.text         = "";
        inputFaltC.text         = "";
        inputFaltD.text         = "";
    }
    public void gIdDocente(){
            idLoginUser = iniciarSesionController.loginData.ObtenerLoginID();
            Debug.Log("LoginDataUser: "+ idLoginUser);
    }
    public void MostrarListaEnLog()
        {   
            foreach (var pregunta in listPreguntas) {
                Debug.Log($"ID:{pregunta.Id_Pregunta}, IDDoc: {pregunta.id_Docente}, Enunciado: {pregunta.Enunciado}, Respuesta: {pregunta.Respuesta}");
            }   

            foreach (var alternativa in listAlternativas) {
                Debug.Log($"ID:{alternativa.Id_Alternativas}, IDPregunta: {alternativa.Id_Pregunta}, AltA: {alternativa.Alternativa_A}, AltB: {alternativa.Alternativa_B}, AltC: {alternativa.Alternativa_C}, AltD: {alternativa.Alternativa_D }");
            }
        }
}
