using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsignarPreguntaController : MonoBehaviour
{   

    List<DocenteData> listaDocentes         = new List<DocenteData>();
    List<EstudianteData> listaEstudiantes   = new List<EstudianteData>();
    List<PreguntaData> listaPreguntas       = new List<PreguntaData>();
    List<AlternativasData> listaAlternativa = new List<AlternativasData>();
    List<AsignarPreguntaData> listaAsignarPregunta = new List<AsignarPreguntaData>();
    LoginData loginData = new LoginData();

    public DocenteRepository docenteRepository;
    public EstudianteRepository estudianteRepository;
    public PreguntaRepository preguntaRepository;
    public AltenativaRepository altenativaRepository;
    public AsignarPreguntaRepository asignarpreguntaRepository;
    public LoginRepository loginRepository;

    WindowsController windowsController;

    int idAsignar = 0;
    // Start is called before the first frame update
    void Start()
    {
        windowsController = GetComponent<WindowsController>();
        listaDocentes     = docenteRepository.LoadingDataDocente();
        listaEstudiantes  = estudianteRepository.LoadingDataEstudiante();
        listaPreguntas    = preguntaRepository.LoadingDataPregunta();
        listaAlternativa  = altenativaRepository.LoadingDataAltenativa();
        listaAsignarPregunta = asignarpreguntaRepository.LoadingDataAsignarPregunta();
        loginData         = loginRepository.LoadDataLogin();

        foreach (var item in listaAsignarPregunta)
        {
            Debug.Log($"AsigPreg: {item.ID_AsigPregunta}, Eval: {item.ID_Evaluacion}, Est: {item.ID_Estudiante}, Preg: {item.ID_Pregunta}, Estado: {item.Estado}");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AsignarPreguntasAleatorias(int cantidad)
    {
        if (cantidad > listaPreguntas.Count)
        {
            Debug.LogError("No hay suficientes preguntas únicas para seleccionar la cantidad deseada.");
            return;
        }

        List<PreguntaData> copiaPreguntas = new List<PreguntaData>(listaPreguntas);

        System.Random rand = new System.Random();

        foreach (var item in copiaPreguntas)
        {
            Debug.Log($"IDPreg: {item.Id_Pregunta},Enun: {item.Enunciado}, Respuesta: {item.Respuesta}");
        }

        for (int i = 0; i < cantidad; i++)
        {
            idAsignar = listaAsignarPregunta.Count;
            int indiceRandom = rand.Next(copiaPreguntas.Count);
            AsignarPreguntaData asignarPreguntaData = new AsignarPreguntaData(idAsignar,0,
                      loginData.Id_Usuario,
                      copiaPreguntas[indiceRandom].Id_Pregunta,
                             "NoResuelta");
            listaAsignarPregunta.Add(asignarPreguntaData);
            copiaPreguntas.RemoveAt(indiceRandom);
        }
        
        foreach (var item in listaAsignarPregunta)
        {
            Debug.Log($"AsignarIDPregunta: {item.ID_Pregunta}, Estado: {item.Estado}");
        }
        asignarpreguntaRepository.SaveDataAsignarPregunta(listaAsignarPregunta);    


    }
}
