using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public GameWindowController gameWindowController;


    List<DocenteData> listaDocente = new List<DocenteData>();
    List<EstudianteData> listaEstudiante = new List<EstudianteData>();
    List<PreguntaData> listaPregunta = new List<PreguntaData>();
    List<AlternativasData> listaAlternativa = new List<AlternativasData>();
    List<EvaluacionData> listaEvaluaciones = new List<EvaluacionData>();
    List<AsignarPreguntaData> listaAsignarPregunta = new List<AsignarPreguntaData>();
    LoginData loginData = new LoginData();
    AsignarData asignarData = new AsignarData();

    public string PillarName;


    public DocenteRepository docenteRepository;
    public EstudianteRepository estudianteRepository;
    public PreguntaRepository preguntaRepository;
    public AltenativaRepository altenativaRepository;
    public EvaluacionRepository evaluacionRepository;
    public AsignarPreguntaRepository asignarpreguntaRepository;
    public LoginRepository loginRepository;
    public AsignarRepository asignarRepository;

    public TMP_Text idAP;
    public TMP_Text idPillar;

    public TMP_Text contenidoEnunciado;
    public Toggle AlternA;
    public Toggle AlternB;
    public Toggle AlternC;
    public Toggle AlternD;

    public ToggleGroup AlternGroup;

    public TMP_Text txEvaluacion;
    public TMP_Text contenidoIDEst;
    public TMP_Text contenidoNombres;
    public TMP_Text contenidoPuntaja;


    // Start is called before the first frame update
    void Start()
    {
   
        listaDocente     = docenteRepository.LoadingDataDocente();
        listaEstudiante  = estudianteRepository.LoadingDataEstudiante();
        listaPregunta    = preguntaRepository.LoadingDataPregunta();
        listaAlternativa = altenativaRepository.LoadingDataAltenativa();
        listaEvaluaciones = evaluacionRepository.LoadingDataEvaluacion();
        listaAsignarPregunta = asignarpreguntaRepository.LoadingDataAsignarPregunta();
        loginData = loginRepository.LoadDataLogin();
        asignarData = asignarRepository.LoadDataAsignarData();

    }

    // Update is called once per frame
    void Update()
    {
        LlenarTablaPuntuacion();
    }

    public void LlenarDatos_CazandoPreguntas(int indiceAsig)
    {
        listaEvaluaciones = evaluacionRepository.LoadingDataEvaluacion();
        asignarData = asignarRepository.LoadDataAsignarData();
        foreach (var evaluacion in listaEvaluaciones)
        {
            Debug.Log($"NombreEva_Juego: {asignarData.NombreEvaluacion}");

            if (evaluacion.Nombre == asignarData.NombreEvaluacion)
            {
                int aux = 0;
                foreach (var asignarPreg in evaluacion.AsignarPregunta)
                {
                    if (asignarPreg.Estado == "NoResuelta" && asignarPreg.ID_Estudiante == loginData.Id_Usuario)
                    {
                        foreach (var pregunta in listaPregunta)
                        {
                            if (asignarPreg.ID_Pregunta == pregunta.Id_Pregunta)
                            {
                                contenidoEnunciado.text = pregunta.Enunciado;
                                foreach (var alternativa in listaAlternativa)
                                {
                                    if (pregunta.Id_Pregunta == alternativa.Id_Pregunta)
                                    {
                                        AlternA.GetComponentInChildren<Text>().text = alternativa.Alternativa_A;
                                        AlternB.GetComponentInChildren<Text>().text = alternativa.Alternativa_B;
                                        AlternC.GetComponentInChildren<Text>().text = alternativa.Alternativa_C;
                                        AlternD.GetComponentInChildren<Text>().text = alternativa.Alternativa_D;
                                    }
                                }
                            }
                        }
                        idAP.text = asignarPreg.ID_AsigPregunta.ToString();
                    }
                    else
                    {
                        if (aux == 20)
                        {
                            gameWindowController.MostrarVentana_Ganaste();
                        }
                        aux++;
                        Debug.Log($"Puntaje:{aux} ");
                    }
                    
                }
            }
        }
        gameWindowController.MostrarVentanaC_Preguntas();



        //foreach (var asignarPregunta in listaAsignarPregunta)
        //{
        //    if (asignarPregunta.Estado == "NoResuelta" && asignarPregunta.ID_Estudiante == loginData.Id_Usuario)
        //    {
        //        foreach (var pregunta in listaPregunta)
        //        {
        //            if (asignarPregunta.ID_Pregunta == pregunta.Id_Pregunta)
        //            {
        //                contenidoEnunciado.text = pregunta.Enunciado;
        //                foreach (var alternativa in listaAlternativa)
        //                {
        //                    if (pregunta.Id_Pregunta == alternativa.Id_Pregunta)
        //                    {
        //                        AlternA.GetComponentInChildren<Text>().text = alternativa.Alternativa_A;
        //                        AlternB.GetComponentInChildren<Text>().text = alternativa.Alternativa_B;
        //                        AlternC.GetComponentInChildren<Text>().text = alternativa.Alternativa_C;
        //                        AlternD.GetComponentInChildren<Text>().text = alternativa.Alternativa_D;
        //                    }
        //                }
        //            }
        //        }
        //        idAP.text = asignarPregunta.ID_AsigPregunta.ToString();
        //    }
        //}
        //gameWindowController.MostrarVentanaC_Preguntas();
    }
    //public void VerificarEvaluacion()
    //{
    //    listaEstudiante = estudianteRepository.LoadingDataEstudiante();
    //    loginData = loginRepository.LoadDataLogin();
    //    listaEvaluaciones = evaluacionRepository.LoadingDataEvaluacion();

    //    foreach (var evaluacion in listaEvaluaciones)
    //    {
    //        if(evaluacion.Nombre == asignarData.NombreEvaluacion)
    //        {
    //            foreach (var asignarPre in evaluacion.AsignarPregunta)
    //            {
    //                if (asignarPre.ID_AsigPregunta.ToString() == idAP.text
    //                    && asignarPre.ID_Estudiante == loginData.Id_Usuario)
    //                {

    //                }
    //            }
    //        }
    //    }
    //}
    public void ResponderPregunta()
    {
        listaEvaluaciones = evaluacionRepository.LoadingDataEvaluacion();
        listaPregunta     = preguntaRepository.LoadingDataPregunta();
        asignarData       = asignarRepository.LoadDataAsignarData();
        foreach (var evaluacion in listaEvaluaciones)
        {
            if (evaluacion.Nombre == asignarData.NombreEvaluacion)
            {
                foreach (var asignarPre in evaluacion.AsignarPregunta)
                {
                    if (asignarPre.ID_AsigPregunta.ToString() == idAP.text
                        && asignarPre.ID_Estudiante == loginData.Id_Usuario)
                    {
                        foreach (var pregunta in listaPregunta)
                        {
                            if (asignarPre.ID_Pregunta == pregunta.Id_Pregunta)
                            {
                                Toggle[] toggles = AlternGroup.GetComponentsInChildren<Toggle>();

                                foreach (var toggle in toggles)
                                {
                                    if (toggle.isOn)
                                    {
                                        Debug.Log("Toggle1: " + toggle.GetComponentInChildren<Text>().text);
                                        string SelecToggle = toggle.GetComponentInChildren<Text>().text;
                                  
                                            if (pregunta.Respuesta == SelecToggle)
                                            {
                                                Debug.Log("Respuesta Correcta");
                                                asignarPre.Estado = "Resuelta";
                                                evaluacionRepository.SaveDataEvaluacion(listaEvaluaciones);
                                                idPillar.text = "1";
                                                gameWindowController.OcultarVentanaC_Preguntas();
                                                gameWindowController.MostrarVentana_PreFelicidad();

                                            }
                                        
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
        evaluacionRepository.LoadingDataEvaluacion();
        //foreach (var asignarPregunta in listaAsignarPregunta)
        //{
        //    if (asignarPregunta.ID_AsigPregunta.ToString() == idAP.text 
        //        && asignarPregunta.ID_Estudiante == loginData.Id_Usuario)
        //    {
        //        foreach (var pregunta in listaPregunta)
        //        {
        //            if (asignarPregunta.ID_Pregunta == pregunta.Id_Pregunta)
        //            {
        //                Toggle[] toggles = AlternGroup.GetComponentsInChildren<Toggle>();

        //                foreach (var toggle in toggles)
        //                {
        //                    if (toggle.isOn)
        //                    {
        //                        Debug.Log("Toggle1: " + toggle.GetComponentInChildren<Text>().text);
        //                        string SelecToggle = toggle.GetComponentInChildren<Text>().text;
        //                        if (pregunta.Respuesta == SelecToggle)
        //                        {
        //                            Debug.Log("Respuesta Correcta");
        //                            asignarPregunta.Estado = "Resuelta";
        //                            asignarpreguntaRepository.SaveDataAsignarPregunta(listaAsignarPregunta);
        //                        }
        //                    }
                            
        //                }
        //            }
        //        }
        //    }
        //}
    }

    public void LlenarTablaPuntuacion()
    {
        listaEvaluaciones = evaluacionRepository.LoadingDataEvaluacion();
        listaEstudiante   = estudianteRepository.LoadingDataEstudiante();
        asignarData       = asignarRepository.LoadDataAsignarData();
        string accumulatedIdEst     = "";
        string accumulatedNombreEst = "";
        string accumulatedPuntaje   = "";

        foreach (var evaluacion in listaEvaluaciones)
        {   
            if (evaluacion.Nombre == asignarData.NombreEvaluacion)
            {
                txEvaluacion.text = evaluacion.Nombre;
                
                foreach (var estudiante in listaEstudiante)
                {
                   
                    
                    if (evaluacion.Id_Docente == estudiante.Id_Docente)
                    {
                        int puntaje = 0;
                        foreach (var asignarPre in evaluacion.AsignarPregunta)
                        {
                            if (asignarPre.ID_Estudiante == estudiante.id_Estudiante)
                            {
                                if (asignarPre.Estado == "Resuelta")
                                {
                                    puntaje++;
                                }
                            }
                        }
                        accumulatedIdEst += $"{estudiante.id_Estudiante}\n";
                        accumulatedNombreEst += $"{estudiante.Nombre}\n";
                        accumulatedPuntaje += $"{puntaje}\n";
                    }
                }
            }

        }
        contenidoIDEst.text = accumulatedIdEst;
        contenidoNombres.text = accumulatedNombreEst;
        contenidoPuntaja.text = accumulatedPuntaje;

        //foreach (var asignarPregunta in listaAsignarPregunta)
        //{
        //    foreach (var estudiante in listaEstudiante)
        //    {
        //        accumulatedIdEst += $"{estudiante.id_Estudiante}\nv";
        //        accumulatedNombreEst += $"{estudiante.Nombre}\n";
        //    }
        //    contenidoIDEst.text   = accumulatedIdEst;
        //    contenidoNombres.text = accumulatedNombreEst;
        //}
    }
    public void Desactivar_Pillar(Collision2D coll)
    {
        Collider2D colliderObjetoPregunta = coll.collider;
        if (colliderObjetoPregunta != null)
        {
            if (idPillar.text == "1")
            {
                colliderObjetoPregunta.isTrigger = true;
            }
        }
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Pillar Preg 1")
        {
            Debug.Log("Pregunta 1");
            LlenarDatos_CazandoPreguntas(0);
        }
        if (collision.gameObject.name == "Pillar Preg 2")
        {
            Debug.Log("Pregunta 2");
            LlenarDatos_CazandoPreguntas(1);
        }
        if (collision.gameObject.name == "Pillar Preg 3")
        {
            Debug.Log("Pregunta 3");
            LlenarDatos_CazandoPreguntas(2);
        }
        if (collision.gameObject.name == "Pillar Preg 4")
        {
            Debug.Log("Pregunta 4");
            LlenarDatos_CazandoPreguntas(3);

        }
        if (collision.gameObject.name == "Pillar Preg 5 - G")
        {
            Debug.Log("Pregunta 5");
            LlenarDatos_CazandoPreguntas(4);

        }
        if (collision.gameObject.name == "Pillar Preg 6")
        {
            Debug.Log("Pregunta 6");
            LlenarDatos_CazandoPreguntas(5);

        }
        if (collision.gameObject.name == "Pillar Preg 7")
        {
            Debug.Log("Pregunta 7");
            LlenarDatos_CazandoPreguntas(6);
        }
        if (collision.gameObject.name == "Pillar Preg 8")
        {
            Debug.Log("Pregunta 8");
            LlenarDatos_CazandoPreguntas(7);
        }
        if (collision.gameObject.name == "Pillar Preg 9")
        {
            Debug.Log("Pregunta 9");
            LlenarDatos_CazandoPreguntas(8);
        }
        if (collision.gameObject.name == "Pillar Preg 10 - G")
        {
            Debug.Log("Pregunta 10");
            LlenarDatos_CazandoPreguntas(9);
        }
        if (collision.gameObject.name == "Pillar Preg 11 - M")
        {
            Debug.Log("Pregunta 11");
            LlenarDatos_CazandoPreguntas(10);
        }
        if (collision.gameObject.name == "Pillar Preg 12")
        {
            Debug.Log("Pregunta 12");
            LlenarDatos_CazandoPreguntas(11);
        }
        if (collision.gameObject.name == "Pillar Preg 13")
        {
            Debug.Log("Pregunta 13");
            LlenarDatos_CazandoPreguntas(12);
        }
        if (collision.gameObject.name == "Pillar Preg 14")
        {
            Debug.Log("Pregunta 14");
            LlenarDatos_CazandoPreguntas(13);
        }
        if (collision.gameObject.name == "Altar Preg 15")
        {
            Debug.Log("Pregunta 15");
            LlenarDatos_CazandoPreguntas(14);
        }
        if (collision.gameObject.name == "Pillar Preg 16")
        {
            Debug.Log("Pregunta 16");
            LlenarDatos_CazandoPreguntas(15);
        }
        if (collision.gameObject.name == "Pillar Preg 17")
        {
            Debug.Log("Pregunta 17");
            LlenarDatos_CazandoPreguntas(16);
        }
        if (collision.gameObject.name == "Pillar Preg 18")
        {
            Debug.Log("Pregunta 18");
            LlenarDatos_CazandoPreguntas(17);
        }
        if (collision.gameObject.name == "Pillar Preg 19")
        {
            Debug.Log("Pregunta 19");
            LlenarDatos_CazandoPreguntas(18);
        }
        if (collision.gameObject.name == "Altar Preg 20")
        {
            Debug.Log("Pregunta 20");
            LlenarDatos_CazandoPreguntas(19);
        }
    }
    public void OnCollisionStay2D(Collision2D collision)
    {
        
        if (collision.gameObject.name == "Pillar Preg 1")
        {   
            Desactivar_Pillar(collision);
        }
        if (collision.gameObject.name == "Pillar Preg 2")
        {
            Desactivar_Pillar(collision);
        }
        if (collision.gameObject.name == "Pillar Preg 3")
        {
            Desactivar_Pillar(collision);
        }
        if (collision.gameObject.name == "Pillar Preg 4")
        {
            Desactivar_Pillar(collision);
        }
        if (collision.gameObject.name == "Pillar Preg 5 - G")
        {
            Desactivar_Pillar(collision);
        }
        if (collision.gameObject.name == "Pillar Preg 6")
        {
            Desactivar_Pillar(collision);
        }
        if (collision.gameObject.name == "Pillar Preg 7")
        {
            Desactivar_Pillar(collision);
        }
        if (collision.gameObject.name == "Pillar Preg 8")
        {
            Desactivar_Pillar(collision);
        }
        if (collision.gameObject.name == "Pillar Preg 9")
        {
            Desactivar_Pillar(collision);
        }
        if (collision.gameObject.name == "Pillar Preg 10 - G")
        {
            Desactivar_Pillar(collision);
        }
        if (collision.gameObject.name == "Pillar Preg 11 - M")
        {
            Desactivar_Pillar(collision);
        }
        if (collision.gameObject.name == "Pillar Preg 12")
        {
            Desactivar_Pillar(collision);
        }
        if (collision.gameObject.name == "Pillar Preg 13")
        {
            Desactivar_Pillar(collision);
        }
        if (collision.gameObject.name == "Pillar Preg 14")
        {
            Desactivar_Pillar(collision);
        }
        if (collision.gameObject.name == "Altar Preg 15")
        {
            Desactivar_Pillar(collision);
        }
        if (collision.gameObject.name == "Pillar Preg 16")
        {
            Desactivar_Pillar(collision);
        }
        if (collision.gameObject.name == "Pillar Preg 17")
        {
            Desactivar_Pillar(collision);
        }
        if (collision.gameObject.name == "Pillar Preg 18")
        {
            Desactivar_Pillar(collision);
        }
        if (collision.gameObject.name == "Pillar Preg 19")
        {
            Desactivar_Pillar(collision);
        }
        if (collision.gameObject.name == "Altar Preg 20")
        {
            Desactivar_Pillar(collision);
        }
        idPillar.text = "0";
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Pillar Preg 1")
        {
            Debug.Log("Pregunta 1");
            gameWindowController.OcultarVentanaC_Preguntas();
        }
        if (collision.gameObject.name == "Pillar Preg 2")
        {
            Debug.Log("Pregunta 2");
            gameWindowController.OcultarVentanaC_Preguntas();
        }
        if (collision.gameObject.name == "Pillar Preg 3")
        {
            Debug.Log("Pregunta 3");
            gameWindowController.OcultarVentanaC_Preguntas();
        }
        if (collision.gameObject.name == "Pillar Preg 4")
        {
            Debug.Log("Pregunta 4");
            gameWindowController.OcultarVentanaC_Preguntas();
        }
        if (collision.gameObject.name == "Pillar Preg 5 - G")
        {
            Debug.Log("Pregunta 5");
            gameWindowController.OcultarVentanaC_Preguntas();
        }
        if (collision.gameObject.name == "Pillar Preg 6")
        {
            Debug.Log("Pregunta 6");
            gameWindowController.OcultarVentanaC_Preguntas();
        }
        if (collision.gameObject.name == "Pillar Preg 7")
        {
            Debug.Log("Pregunta 7");
            gameWindowController.OcultarVentanaC_Preguntas();
        }
        if (collision.gameObject.name == "Pillar Preg 8")
        {
            Debug.Log("Pregunta 8");
            gameWindowController.OcultarVentanaC_Preguntas();
        }
        if (collision.gameObject.name == "Pillar Preg 9")
        {
            Debug.Log("Pregunta 9");
            gameWindowController.OcultarVentanaC_Preguntas();
        }
        if (collision.gameObject.name == "Pillar Preg 10 - G")
        {
            Debug.Log("Pregunta 10");
            gameWindowController.OcultarVentanaC_Preguntas();
        }
        if (collision.gameObject.name == "Pillar Preg 11 - M")
        {
            Debug.Log("Pregunta 11");
            gameWindowController.OcultarVentanaC_Preguntas();
        }
        if (collision.gameObject.name == "Pillar Preg 12")
        {
            Debug.Log("Pregunta 12");
            gameWindowController.OcultarVentanaC_Preguntas();
        }
        if (collision.gameObject.name == "Pillar Preg 13")
        {
            Debug.Log("Pregunta 13");
            gameWindowController.OcultarVentanaC_Preguntas();
        }
        if (collision.gameObject.name == "Pillar Preg 14")
        {
            Debug.Log("Pregunta 14");
            gameWindowController.OcultarVentanaC_Preguntas();
        }
        if (collision.gameObject.name == "Altar Preg 15")
        {
            Debug.Log("Pregunta 15");
            gameWindowController.OcultarVentanaC_Preguntas();
        }
        if (collision.gameObject.name == "Pillar Preg 16")
        {
            Debug.Log("Pregunta 16");
            gameWindowController.OcultarVentanaC_Preguntas();
        }
        if (collision.gameObject.name == "Pillar Preg 17")
        {
            Debug.Log("Pregunta 17");
            gameWindowController.OcultarVentanaC_Preguntas();
        }
        if (collision.gameObject.name == "Pillar Preg 18")
        {
            Debug.Log("Pregunta 18");
            gameWindowController.OcultarVentanaC_Preguntas();
        }
        if (collision.gameObject.name == "Pillar Preg 19")
        {
            Debug.Log("Pregunta 19");
            gameWindowController.OcultarVentanaC_Preguntas();
        }
        if (collision.gameObject.name == "Altar Preg 20")
        {
            Debug.Log("Pregunta 20");
            gameWindowController.OcultarVentanaC_Preguntas();
        }
    }

}
