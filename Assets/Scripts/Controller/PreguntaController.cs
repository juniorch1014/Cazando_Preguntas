using System.Net.Mail;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Linq;


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

    //EdItarPregunta
    public TMP_InputField InputF_IDEditar;
    public TMP_InputField inputFEditEnun;
    public TMP_InputField inputFEditResp;
    public TMP_InputField inputFEditA;
    public TMP_InputField inputFEditB;
    public TMP_InputField inputFEditC;
    public TMP_InputField inputFEditD;
    public TMP_Text txNotificacion;
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
            if(pregunta.Id_Docente == idLoginUser){
                accumulatedText += $"ID: {pregunta.Id_Pregunta}, Enunciado: {pregunta.Enunciado}, Respuesta: {pregunta.Respuesta}\n";
            }
        }
        MostrarListaEnLog();
        scrollVTMostrarPregunta.text = accumulatedText;
    }

    public void EditarPregunta () {
        List<PreguntaData> listEPregunta = preguntaRepository.LoadingDataPregunta();
        List<AlternativasData> listEAlternativa = altenativaRepository.LoadingDataAltenativa();
        vaciarEspacios();
        foreach(var pregunta in listEPregunta) {
            if(inputFEditEnun.text == "" || inputFEditResp.text == "" || inputFEditA.text == "" || inputFEditB.text == "" || inputFEditC.text == "" || inputFEditD.text == "") 
            {
                Debug.Log("Llenar espacios en blanco");
            }else{
                if(pregunta.Id_Docente == idLoginUser) {

                    if(pregunta.Id_Pregunta.ToString() == InputF_IDEditar.text) {

                        pregunta.Enunciado = inputFEditEnun.text;
                        pregunta.Respuesta = inputFEditResp.text;
                        
                        foreach(var alternativa in listEAlternativa) {
                            if(alternativa.Id_Pregunta == pregunta.Id_Pregunta){
                                alternativa.Alternativa_A = inputFEditA.text;
                                alternativa.Alternativa_B = inputFEditB.text;
                                alternativa.Alternativa_C = inputFEditC.text;
                                alternativa.Alternativa_D = inputFEditD.text;
                            }
                        }
                    }
                    preguntaRepository.SaveDataPregunta(listEPregunta);
                    altenativaRepository.SaveDataAltenativa(listEAlternativa);
                }  
            }
            
        }
    }
    public void LlenarDatosEditar () {
        List<PreguntaData> listLlenarEPregunta = preguntaRepository.LoadingDataPregunta();
        List<AlternativasData> listLlenarEAlter = altenativaRepository.LoadingDataAltenativa();

        foreach(var pregunta in listLlenarEPregunta) {
            if(pregunta.Id_Docente == idLoginUser) {
                if(pregunta.Id_Pregunta.ToString() == InputF_IDEditar.text){
                    inputFEditEnun.text = pregunta.Enunciado;
                    inputFEditResp.text = pregunta.Respuesta;
                    foreach (var alternativa in listLlenarEAlter){
                        if(alternativa.Id_Pregunta == pregunta.Id_Pregunta){
                            inputFEditA.text = alternativa.Alternativa_A;
                            inputFEditB.text = alternativa.Alternativa_B;
                            inputFEditC.text = alternativa.Alternativa_C;
                            inputFEditD.text = alternativa.Alternativa_D;
                        }
                    }
                    windowsController.OcultarVentanaUREditPregunta();
                    windowsController.MostrarVenActualizarPregunta();
                }else{
                    txNotificacion.text = "Pregunta no encontrada";
                }
            }
        }
    }
    public void EliminarPregunta () {
        PreguntaData preguntaEliminar = listPreguntas.FirstOrDefault(
                                        pregunta => 
                                        pregunta.Id_Pregunta.
                                        ToString() == InputF_IDEditar.text);
        if(preguntaEliminar != null){
            AlternativasData alternativaEliminar = listAlternativas.FirstOrDefault(
                                                alternativa =>
                                                alternativa.Id_Pregunta
                                                .ToString() == InputF_IDEditar.text);
            if(alternativaEliminar != null){
                listAlternativas.Remove(alternativaEliminar);
                altenativaRepository.DeleteDataAltenativa();
                altenativaRepository.SaveDataAltenativa(listAlternativas);
                altenativaRepository.LoadingDataAltenativa();
            }
            
        }
    }
    public void vaciarEspacios(){
        inputFEnunciado.text    = "";
        inputFRespuesta.text    = "";
        inputFaltA.text         = "";
        inputFaltB.text         = "";
        inputFaltC.text         = "";
        inputFaltD.text         = "";

        InputF_IDEditar.text    = "";
        txNotificacion.text     = "";
    }
    public void gIdDocente(){
            idLoginUser = iniciarSesionController.loginData.ObtenerLoginID();
            Debug.Log("LoginDataUser: "+ idLoginUser);
    }
    public void MostrarListaEnLog()
        {   
            foreach (var pregunta in listPreguntas) {
                Debug.Log($"ID:{pregunta.Id_Pregunta}, IDDoc: {pregunta.Id_Docente}, Enunciado: {pregunta.Enunciado}, Respuesta: {pregunta.Respuesta}");
            }   

            foreach (var alternativa in listAlternativas) {
                Debug.Log($"ID:{alternativa.Id_Alternativas}, IDPregunta: {alternativa.Id_Pregunta}, AltA: {alternativa.Alternativa_A}, AltB: {alternativa.Alternativa_B}, AltC: {alternativa.Alternativa_C}, AltD: {alternativa.Alternativa_D }");
            }
        }
}
