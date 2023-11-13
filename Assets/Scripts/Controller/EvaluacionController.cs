using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using TMPro;
using UnityEngine;

public class EvaluacionController : MonoBehaviour
{
    List<DocenteData> listaDocentes = new List<DocenteData>();
    List<EstudianteData> listaEstudiante = new List<EstudianteData>();
    List<PreguntaData> listaPreguntas = new List<PreguntaData>();
    List<AlternativasData> listaAlterntivas = new List<AlternativasData>();
    List<EvaluacionData> listaEvaluaciones = new List<EvaluacionData>();
    LoginData loginData = new LoginData();
    AsignarData asignarData = new AsignarData();

    List<string> listaGuardaEvDocente = new List<string>();
    List<string> listaGuardaEvEstudiante =  new List<string>();


    public DocenteRepository docenteRepository;
    public EstudianteRepository estudianteRepository;
    public PreguntaRepository preguntaRepository;
    public AltenativaRepository altenativaRepository;
    public EvaluacionRepository evaluacionRepository;
    public LoginRepository loginRepository;
    public AsignarRepository asignarRepository;
    
    WindowsController windowsController;

    //RegistrarEvaluacion
    public TMP_InputField inputFNombre;
    public TMP_InputField inputFGrado;
    public TMP_InputField inputFSeccion;
    public TMP_Text txNoficacionREva;

    //VerEvaluacion
    public TMP_Dropdown ddEvaluacion;

    public TMP_Text txEvaluacion;
    public TMP_Text contenidoIDEst;
    public TMP_Text contenidoNombres;
    public TMP_Text contenidoPuntaja;


    int idEvaluacion  = 0;
    int idAsignarEval = 0;
    // Start is called before the first frame update
    void Start()
    {
        windowsController = GetComponent<WindowsController>();
        listaDocentes = docenteRepository.LoadingDataDocente();
        listaEstudiante = estudianteRepository.LoadingDataEstudiante();
        listaPreguntas =  preguntaRepository.LoadingDataPregunta();
        listaAlterntivas = altenativaRepository.LoadingDataAltenativa();
        listaEvaluaciones = evaluacionRepository.LoadingDataEvaluacion();
        loginData = loginRepository.LoadDataLogin();
        asignarData = asignarRepository.LoadDataAsignarData();

    }

    // Update is called once per frame
    void Update()
    {
        LlenarTablaPuntuacionEval();
    }

    public void Registrar_Evaluacion()
    {
        loginData = loginRepository.LoadDataLogin();

        if (inputFNombre.text == "" || inputFGrado.text == "" 
                                    || inputFSeccion.text == "")
        {
            txNoficacionREva.text = "Llenar espacios en blanco";
        }
        else
        {
            idEvaluacion = listaEvaluaciones.Count;
            EvaluacionData evaluacionData = new EvaluacionData(idEvaluacion,
                                                       loginData.Id_Usuario,
                                                          inputFNombre.text,
                                                           inputFGrado.text,
                                                         inputFSeccion.text,
                                                            "Desconectado");
            listaEvaluaciones.Add(evaluacionData);
            evaluacionRepository.SaveDataEvaluacion(listaEvaluaciones);
            evaluacionRepository.LoadingDataEvaluacion();
            MostrarEvaluacionEnLog();
        }
        
    }

    
    public void LlenarDropdown()
    {
        listaDocentes = docenteRepository.LoadingDataDocente();
        listaEstudiante = estudianteRepository.LoadingDataEstudiante();
        listaEvaluaciones = evaluacionRepository.LoadingDataEvaluacion();
        loginData = loginRepository.LoadDataLogin();
        if (loginData.Tipo_Usuario == "Docente")
        {
            ddEvaluacion.ClearOptions();

            foreach (var evaluacion in listaEvaluaciones)
            {
                if (evaluacion.Id_Docente == loginData.Id_Usuario)
                {
                    //string ddEva1 = evaluacion.Nombre;
                    //listaGuardaEvDocente.Add(ddEva1);
                    //ddEvaluacion.ClearOptions();
                    //ddEvaluacion.AddOptions(listaGuardaEvDocente);
                    //MostrarEvaluacionEnLog();
                    ddEvaluacion.options.Add(new TMP_Dropdown.OptionData(evaluacion.Nombre));
                }
            }
        }
        if (loginData.Tipo_Usuario == "Estudiante")
        {
            ddEvaluacion.ClearOptions();

            foreach (var evaluacion in listaEvaluaciones)
            {
               // foreach (var estudiante in listaEstudiante)
               // {
                    //if (estudiante.id_Estudiante == loginData.Id_Usuario) {
                        ddEvaluacion.options.Add(new TMP_Dropdown.OptionData(evaluacion.Nombre));
                    //}
               // }
            }
        }
    }
    
    public void AsignarPregunta_Evaluacion(int cantidad)
    {
        if (cantidad > listaPreguntas.Count)
        {
            Debug.LogError("No hay suficientes preguntas únicas para seleccionar la cantidad deseada.");
            return; 
        }

        //Variable Alterna
        List<PreguntaData> copiaPreguntas = new List<PreguntaData>(listaPreguntas);
        //Numero Random
        System.Random rand = new System.Random();

        //Mostrar
        foreach (var item in copiaPreguntas)
        {
            Debug.Log($"IDPreg: {item.Id_Pregunta},Enun: {item.Enunciado}, Respuesta: {item.Respuesta}");
        }


        ObtenerNombreDropdown();


        foreach (var evaluacion in listaEvaluaciones)
        {
            if (evaluacion.Nombre == asignarData.NombreEvaluacion)
            {
                for (int i = 0; i < cantidad; i++)
                {
                    idAsignarEval = evaluacion.AsignarPregunta.Count;
                    int indiceRandom = rand.Next(copiaPreguntas.Count);
                    AsignarPreguntaData asignarPreguntaData = new AsignarPreguntaData(
                        idAsignarEval,
                        evaluacion.Id_Evaluacion,
                        loginData.Id_Usuario,
                        copiaPreguntas[indiceRandom].Id_Pregunta,
                        "NoResuelta");
                    evaluacion.AsignarPregunta.Add(asignarPreguntaData);
                    copiaPreguntas.RemoveAt(indiceRandom);

                }
            }
            foreach (var item in evaluacion.AsignarPregunta)
            {
                Debug.Log($"AsignarPreEvaluacionID: {item.ID_AsigPregunta}, " +
                                     $"ID_Pregunta: {item.ID_Pregunta}, " +
                                          $"Estado: {item.Estado}");
            }
        }
        evaluacionRepository.SaveDataEvaluacion(listaEvaluaciones);
        evaluacionRepository.LoadingDataEvaluacion();
        
    }
    public void ObtenerNombreDropdown()
    {
        //Obtener Dato de Dropdown
        int seleccionarIndex = ddEvaluacion.value;
        string dataSelecionada = ddEvaluacion.options[seleccionarIndex].text;
        AsignarData asignar = new AsignarData(dataSelecionada);
        asignarRepository.SaveDataAsignarData(asignar);
        asignarData = asignarRepository.LoadDataAsignarData();
        Debug.Log($"NombreEva_Inicio: {asignarData.NombreEvaluacion}");
    }
    public void LlenarTablaPuntuacionEval()
    {
        listaEvaluaciones = evaluacionRepository.LoadingDataEvaluacion();
        listaEstudiante = estudianteRepository.LoadingDataEstudiante();
        
        string accumulatedIdEst = "";
        string accumulatedNombreEst = "";
        string accumulatedPuntaje = "";

        int selIndex = ddEvaluacion.value;
        string dataSel = ddEvaluacion.options[selIndex].text;

        foreach (var evaluacion in listaEvaluaciones)
        {
            if (evaluacion.Nombre == dataSel)
            {
                txEvaluacion.text = evaluacion.Nombre;

                foreach (var estudiante in listaEstudiante)
                {
                    int puntaje = 0;

                    if (evaluacion.Id_Docente == estudiante.Id_Docente)
                    {
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

    }
    public void MostrarEvaluacionEnLog()
    {
        evaluacionRepository.LoadingDataEvaluacion();
        foreach (var evaluacion in listaEvaluaciones)
        {
            Debug.Log($"ID_Evaluacion: {evaluacion.Id_Evaluacion}, " +
                      $"Nombre: {evaluacion.Nombre}, " +
                      $"Grado: {evaluacion.Grado}, " +
                      $"Seccion:{evaluacion.Seccion} ");
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
    public void LoadingAll()
    {
        docenteRepository.LoadingDataDocente();
        estudianteRepository.LoadingDataEstudiante();
        preguntaRepository.LoadingDataPregunta();
        altenativaRepository.LoadingDataAltenativa();
        evaluacionRepository.LoadingDataEvaluacion();

    }
}
