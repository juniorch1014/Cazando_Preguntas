using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public GameWindowController gameWindowController;

    List<DocenteData> listaDocente = new List<DocenteData>();
    List<EstudianteData> listaEstudiante = new List<EstudianteData>();
    List<PreguntaData> listaPregunta = new List<PreguntaData>();
    List<AlternativasData> listaAlternativa = new List<AlternativasData>();
    List<AsignarPreguntaData> listaAsignarPregunta = new List<AsignarPreguntaData>();
    LoginData loginData = new LoginData();


    public DocenteRepository docenteRepository;
    public EstudianteRepository estudianteRepository;
    public PreguntaRepository preguntaRepository;
    public AltenativaRepository altenativaRepository;
    public AsignarPreguntaRepository asignarpreguntaRepository;
    public LoginRepository loginRepository;

    public TMP_Text idAP;

    public TMP_Text contenidoEnunciado;
    public Toggle AlternA;
    public Toggle AlternB;
    public Toggle AlternC;
    public Toggle AlternD;

    public ToggleGroup AlternGroup; 


    // Start is called before the first frame update
    void Start()
    {
        listaDocente     = docenteRepository.LoadingDataDocente();
        listaEstudiante  = estudianteRepository.LoadingDataEstudiante();
        listaPregunta    = preguntaRepository.LoadingDataPregunta();
        listaAlternativa = altenativaRepository.LoadingDataAltenativa();
        listaAsignarPregunta = asignarpreguntaRepository.LoadingDataAsignarPregunta();
        loginData = loginRepository.LoadDataLogin();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LlenarDatos_CazandoPreguntas(int indiceAsig)
    {
        foreach (var asignarPregunta in listaAsignarPregunta)
        {
            if (asignarPregunta.ID_AsigPregunta == indiceAsig && asignarPregunta.ID_Estudiante == loginData.Id_Usuario)
            {
                foreach (var pregunta in listaPregunta)
                {
                    if (asignarPregunta.ID_Pregunta == pregunta.Id_Pregunta)
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
            }
        }
        gameWindowController.MostrarVentanaC_Preguntas();
    }
    public void ResponderPregunta()
    {
        foreach (var asignarPregunta in listaAsignarPregunta)
        {
            if (asignarPregunta.ID_AsigPregunta.ToString() == idAP.text && asignarPregunta.ID_Estudiante == loginData.Id_Usuario)
            {
                foreach (var pregunta in listaPregunta)
                {
                    if (asignarPregunta.ID_Pregunta == pregunta.Id_Pregunta)
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
                                    asignarPregunta.Estado = "Resuelta";
                                    asignarpreguntaRepository.SaveDataAsignarPregunta(listaAsignarPregunta);
                                }
                            }
                            
                        }
                    }
                }
            }
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
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
