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
    LoginData loginData = new LoginData();

    public DocenteRepository docenteRepository;
    public PreguntaRepository preguntaRepository;
    public AltenativaRepository altenativaRepository;
    public LoginRepository loginRepository;

    WindowsController windowsController;
    //RegistrarPregunta
    public TMP_InputField inputFEnunciado;
    public TMP_InputField inputFRespuesta;
    public TMP_InputField inputFaltA;
    public TMP_InputField inputFaltB;
    public TMP_InputField inputFaltC;
    public TMP_InputField inputFaltD;
    public TMP_Text txNotificacionRP;

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
    public TMP_Text ContPID;
    public TMP_Text ContPEnunciado;
    public TMP_Text ContPRespuesta;
    public TMP_Text ContPAltA;
    public TMP_Text ContPAltB;
    public TMP_Text ContPAltC;
    public TMP_Text ContPAltD;

    public TMP_InputField inputFBuscar;

    


    // Start is called before the first frame update
    void Start()
    {
        windowsController = GetComponent<WindowsController>();
        listDocentes = docenteRepository.LoadingDataDocente();
        listPreguntas = preguntaRepository.LoadingDataPregunta();
        listAlternativas = altenativaRepository.LoadingDataAltenativa();
        loginData = loginRepository.LoadDataLogin();
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void Registrar_Preguntas() {

        loginData = loginRepository.LoadDataLogin();

        if (inputFEnunciado.text == "" || inputFRespuesta.text == "" || inputFaltA.text == " " || inputFaltB.text == "" || inputFaltC.text == "" || inputFaltD.text == "")
        {
            txNotificacionRP.text = "Llenar espacios en blanco";
        } else {
            //Preguntas
            idPregunta = listPreguntas.Count;
            PreguntaData preguntaData = new PreguntaData(idPregunta,
                                                         loginData.Id_Usuario,
                                                         inputFEnunciado.text,
                                                         inputFRespuesta.text);
            listPreguntas.Add(preguntaData);
            preguntaRepository.SaveDataPregunta(listPreguntas);

            //Alternativas
            idAlternativa = listAlternativas.Count;
            AlternativasData alternativasData = new AlternativasData(idAlternativa,
                                                                    idPregunta,
                                                                    inputFaltA.text,
                                                                    inputFaltB.text,
                                                                    inputFaltC.text,
                                                                    inputFaltD.text);
            listAlternativas.Add(alternativasData);
            altenativaRepository.SaveDataAltenativa(listAlternativas);
            MostrarPreguntas();
            vaciarEspacios();
            windowsController.OcultarVenRegistrarPregunta();
        }
    }
    public void MostrarPreguntas() {

        loginData = loginRepository.LoadDataLogin();
        List<PreguntaData> listP = preguntaRepository.LoadingDataPregunta();
        List<AlternativasData> listA = altenativaRepository.LoadingDataAltenativa();

        string accumulatedTextPID = "";
        string accumulatedTextPEnunciado = "";
        string accumulatedTextPRespuesta = "";
        string accumulatedTextPAltA = "";
        string accumulatedTextPAltB = "";
        string accumulatedTextPAltC = "";
        string accumulatedTextPAltD = "";

        foreach (var pregunta in listP) {
            if (pregunta.Id_Docente == loginData.Id_Usuario && loginData.Tipo_Usuario == "Docente")
            {
                accumulatedTextPID += $"{pregunta.Id_Pregunta}\n";
                accumulatedTextPEnunciado += $"{pregunta.Enunciado}\n";
                accumulatedTextPRespuesta += $"{pregunta.Respuesta}\n";

                foreach (var alternativa in listA)
                {
                    if (alternativa.Id_Pregunta == pregunta.Id_Pregunta)
                    {
                        accumulatedTextPAltA += $"{alternativa.Alternativa_A}\n";
                        accumulatedTextPAltB += $"{alternativa.Alternativa_B}\n";
                        accumulatedTextPAltC += $"{alternativa.Alternativa_C}\n";
                        accumulatedTextPAltD += $"{alternativa.Alternativa_D}\n";
                    }
                }
            }
        }

        ContPID.text = accumulatedTextPID;
        ContPEnunciado.text = accumulatedTextPEnunciado;
        ContPRespuesta.text = accumulatedTextPRespuesta;
        ContPAltA.text = accumulatedTextPAltA;
        ContPAltB.text = accumulatedTextPAltB;
        ContPAltC.text = accumulatedTextPAltC;
        ContPAltD.text = accumulatedTextPAltD;
        MostrarListaEnLog();
    }
    public void BuscarPregunta()
    {
        loginData = loginRepository.LoadDataLogin();
        List<PreguntaData> listP = preguntaRepository.LoadingDataPregunta();
        List<AlternativasData> listA = altenativaRepository.LoadingDataAltenativa();

        string accumulatedTextPID = "";
        string accumulatedTextPEnunciado = "";
        string accumulatedTextPRespuesta = "";
        string accumulatedTextPAltA = "";
        string accumulatedTextPAltB = "";
        string accumulatedTextPAltC = "";
        string accumulatedTextPAltD = "";

        foreach (var pregunta in listP)
        {
            if (pregunta.Id_Docente == loginData.Id_Usuario && loginData.Tipo_Usuario == "Docente")
            {
                if (pregunta.Id_Pregunta.ToString() == inputFBuscar.text
                    || pregunta.Enunciado == inputFBuscar.text
                    || pregunta.Respuesta == inputFBuscar.text
                    )
                {
                    accumulatedTextPID += $"{pregunta.Id_Pregunta}\n";
                    accumulatedTextPEnunciado += $"{pregunta.Enunciado}\n";
                    accumulatedTextPRespuesta += $"{pregunta.Respuesta}\n";

                    foreach (var alternativa in listA)
                    {
                        if (alternativa.Id_Pregunta == pregunta.Id_Pregunta)
                        {
                            accumulatedTextPAltA += $"{alternativa.Alternativa_A}\n";
                            accumulatedTextPAltB += $"{alternativa.Alternativa_B}\n";
                            accumulatedTextPAltC += $"{alternativa.Alternativa_C}\n";
                            accumulatedTextPAltD += $"{alternativa.Alternativa_D}\n";
                        }
                    }
                }
                if(inputFBuscar.text == "")
                {
                    accumulatedTextPID += $"{pregunta.Id_Pregunta}\n";
                    accumulatedTextPEnunciado += $"{pregunta.Enunciado}\n";
                    accumulatedTextPRespuesta += $"{pregunta.Respuesta}\n";

                    foreach (var alternativa in listA)
                    {
                        if (alternativa.Id_Pregunta == pregunta.Id_Pregunta)
                        {
                            accumulatedTextPAltA += $"{alternativa.Alternativa_A}\n";
                            accumulatedTextPAltB += $"{alternativa.Alternativa_B}\n";
                            accumulatedTextPAltC += $"{alternativa.Alternativa_C}\n";
                            accumulatedTextPAltD += $"{alternativa.Alternativa_D}\n";
                        }
                    }
                }
            }
        }

        ContPID.text = accumulatedTextPID;
        ContPEnunciado.text = accumulatedTextPEnunciado;
        ContPRespuesta.text = accumulatedTextPRespuesta;
        ContPAltA.text = accumulatedTextPAltA;
        ContPAltB.text = accumulatedTextPAltB;
        ContPAltC.text = accumulatedTextPAltC;
        ContPAltD.text = accumulatedTextPAltD;
    }
    public void EditarPregunta () {

        loginData = loginRepository.LoadDataLogin();
        List<PreguntaData> listEPregunta = preguntaRepository.LoadingDataPregunta();
        List<AlternativasData> listEAlternativa = altenativaRepository.LoadingDataAltenativa();
      
        foreach(var pregunta in listEPregunta) {
            if(inputFEditEnun.text == "" || inputFEditResp.text == "" || inputFEditA.text == "" || inputFEditB.text == "" || inputFEditC.text == "" || inputFEditD.text == "") 
            {
                Debug.Log("Llenar espacios en blanco");
            }else{
                if(pregunta.Id_Docente == loginData.Id_Usuario && loginData.Tipo_Usuario == "Docente") {

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
                preguntaRepository.LoadingDataPregunta();
                altenativaRepository.LoadingDataAltenativa();
                MostrarPreguntas();
            }
            
            
        }
        vaciarEspacios();
    }
    public void LlenarDatosEditar () {

        loginData = loginRepository.LoadDataLogin();
        List<PreguntaData> listLlenarEPregunta = preguntaRepository.LoadingDataPregunta();
        List<AlternativasData> listLlenarEAlter = altenativaRepository.LoadingDataAltenativa();

        foreach(var pregunta in listLlenarEPregunta) {
            if(pregunta.Id_Docente == loginData.Id_Usuario && loginData.Tipo_Usuario == "Docente") {
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
            if (preguntaEliminar.Id_Docente == loginData.Id_Usuario && loginData.Tipo_Usuario == "Docente")
            {
                AlternativasData alternativaEliminar = listAlternativas.FirstOrDefault(
                                                alternativa =>
                                                alternativa.Id_Pregunta
                                                .ToString() == InputF_IDEditar.text);
                if (alternativaEliminar != null)
                {
                    listAlternativas.Remove(alternativaEliminar);
                    altenativaRepository.DeleteDataAltenativa();
                    altenativaRepository.SaveDataAltenativa(listAlternativas);
                    altenativaRepository.LoadingDataAltenativa();
                }
                listPreguntas.Remove(preguntaEliminar);
                preguntaRepository.DeleteDataPregunta();
                preguntaRepository.SaveDataPregunta(listPreguntas);
                preguntaRepository.LoadingDataPregunta();
                MostrarPreguntas();
            }
            else
            {
                txNotificacion.text = "Estudiante no Encontrado";
            }
        }
    }



    public void Mayus(TMP_InputField inputFAMayus)
    {
        inputFAMayus.text = inputFAMayus.text.ToUpper();
    }
    public void Minus(TMP_InputField inputFAMinus)
    {
        inputFAMinus.text = inputFAMinus.text.ToLower();
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
                Debug.Log($"ID:{pregunta.Id_Pregunta}, " +
                      $"IDDoc: {pregunta.Id_Docente}, " +
                  $"Enunciado: {pregunta.Enunciado}, " +
                  $"Respuesta: {pregunta.Respuesta}");
            }   

            foreach (var alternativa in listAlternativas) {
                Debug.Log($"ID:{alternativa.Id_Alternativas}, " +
                 $"IDPregunta: {alternativa.Id_Pregunta}, " +
                       $"AltA: {alternativa.Alternativa_A}, " +
                       $"AltB: {alternativa.Alternativa_B}, " +
                       $"AltC: {alternativa.Alternativa_C}, " +
                       $"AltD: {alternativa.Alternativa_D }");
            }
        }
}
