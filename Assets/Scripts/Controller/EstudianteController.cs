using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class EstudianteController : MonoBehaviour
{       

        public IniciarSesionController iniciarSesionController;     
        int idLoginUser;

        List<DocenteData> listaDocentes = new List<DocenteData>();
        List<EstudianteData> listaEstudiantes = new List<EstudianteData>();

        public DocenteRepository docenteRepository;
        public EstudianteRepository estudianteRepository;
        WindowsController windowsController;
        public TMP_Dropdown DropdUsuario; 
        public TMP_InputField inputFNombre;
        public TMP_InputField inputFApellido;   
        public TMP_InputField inputFCodigo;
        public TMP_InputField inputFContraseña;

        int idEstudiante = 0;
        
        string selectedValue = "Estudiante";
        // Start is called before the first frame update
        void Start()
        {
             windowsController = GetComponent<WindowsController>();
             listaDocentes     = docenteRepository.LoadingDataDocente();
             listaEstudiantes  = estudianteRepository.LoadingDataEstudiante();
             MostrarListaEnLog();
        }

        // Update is called once per frame
        void Update()
        {
        
        }
        
        public void Registrar_Est () {
             if (selectedValue == "Estudiante") {
                if (inputFNombre.text == "" || inputFApellido.text == "" || inputFCodigo.text == "" || inputFContraseña.text == "") {
                        Debug.Log("Estudiante Llenar espacios en blanco");
                }else {
                        idEstudiante = listaEstudiantes.Count;
                        EstudianteData estudianteData = new EstudianteData(idEstudiante,inputFNombre.text, inputFApellido.text, inputFCodigo.text, inputFContraseña.text, idLoginUser);
                        listaEstudiantes.Add(estudianteData);
                        estudianteRepository.SaveDataEstudiante(listaEstudiantes);
                        MostrarListaEnLog();
                        vaciarEspacios();
                        windowsController.OcultarVenRegistrarEst();
                }
              }
        }
        public void vaciarEspacios(){
                inputFNombre.text       = "";
                inputFApellido.text     = "";
                inputFCodigo.text       = "";
                inputFContraseña.text   = "";
        }
        public void gIdDocente(){
            idLoginUser = iniciarSesionController.loginData.ObtenerLoginID();
            Debug.Log("LoginDataEstudiante: "+ idLoginUser);
        }
        public void MostrarListaEnLog()
        {
             foreach (var estudiante in listaEstudiantes){
                Debug.Log($"ID: {estudiante.id_Estudiante}, Nombre: {estudiante.Nombre}, Apellido: {estudiante.Apellido}, User: {estudiante.Email}, Pass: {estudiante.Contraseña}, Id_Doc: {estudiante.Id_Docente}");
             }
        }
}
