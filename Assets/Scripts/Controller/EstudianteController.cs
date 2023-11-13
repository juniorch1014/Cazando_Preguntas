using System.ComponentModel;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Linq;

namespace Controller {
    public class EstudianteController : MonoBehaviour
    {

        public IniciarSesionController iniciarSesionController;
        int idLoginUser;

        List<DocenteData> listaDocentes = new List<DocenteData>();
        List<EstudianteData> listaEstudiantes = new List<EstudianteData>();
        LoginData loginData = new LoginData();

        public DocenteRepository docenteRepository;
        public EstudianteRepository estudianteRepository;
        public LoginRepository loginRepository;

        WindowsController windowsController;
        //Registrar Estudiante
        public TMP_Dropdown DropdUsuario;
        public TMP_Text txNotificacionError;
        public TMP_Text txNotifiID;
        public TMP_InputField inputFGrado;
        public TMP_InputField inputFSeccion;
        public TMP_InputField inputFNombre;
        public TMP_InputField inputFApellido;
        public TMP_InputField inputFCodigo;
        public TMP_InputField inputFContraseña;
        //Editar Estudiante
        public TMP_InputField InputF_IDEditarE;
        public TMP_Dropdown DropdEditUsuario;
        public TMP_Text txEditNotificacionError;
        public TMP_Text txEditNotifiID;
        public TMP_Text txEditNotifiUREdit;
        public TMP_InputField inputFEditGrado;
        public TMP_InputField inputFEditSeccion;
        public TMP_InputField inputFEditNombre;
        public TMP_InputField inputFEditApellido;
        public TMP_InputField inputFEditCodigo;
        public TMP_InputField inputFEditContraseña;


        public TMP_InputField inputFBuscar;
        public TMP_InputField inputFEditar;

        int idEstudiante = 0;

        string selectedValue = "Estudiante";

        //Mostrar Estudiante
        public TMP_Text ContID;
        public TMP_Text ContGrado;
        public TMP_Text ContSeccion;
        public TMP_Text ContNombre;
        public TMP_Text ContApellido;
        public TMP_Text ContUsuario;
        public TMP_Text ContContraseña;
        bool estudianteYaRegistrado = false; // Variable para seguir el estado de la notificación


        // Start is called before the first frame update
        void Start()
        {
            windowsController = GetComponent<WindowsController>();
            listaDocentes = docenteRepository.LoadingDataDocente();
            listaEstudiantes = estudianteRepository.LoadingDataEstudiante();
            loginData = loginRepository.LoadDataLogin();
            MostrarListaEnLog();
        }

        // Update is called once per frame
        void Update()
        {
            estudianteYaRegistrado = false; // Restablece la notificación en cada actualización

            foreach (var estudiante in listaEstudiantes)
            {
                if (inputFNombre.text == estudiante.Nombre && inputFApellido.text == estudiante.Apellido)
                {
                    estudianteYaRegistrado = true;
                    txNotificacionError.text = "Estudiante ya Registrado";
                }
                if (inputFCodigo.text == estudiante.Email)
                {
                    estudianteYaRegistrado = true;
                    txNotifiID.text = inputFCodigo.text + " : ya esta registrado";
                }
            }

            // Borra la notificación si no se cumplen las condiciones
            if (!estudianteYaRegistrado)
            {
                txNotificacionError.text = ""; // Borra la notificación de error
                txNotifiID.text = ""; // Borra la notificación de ID
            }
        }

        public void Registrar_Est()
        {
            loginData = loginRepository.LoadDataLogin();
            if (selectedValue == "Estudiante")
            {
                if (inputFNombre.text == "" || inputFApellido.text == "" 
                                            || inputFCodigo.text == "" 
                                            || inputFContraseña.text == "" 
                                            || inputFGrado.text == "" 
                                            || inputFSeccion.text == "")
                {
                    txNotificacionError.text = "Llenar espacios en blanco";
                }
                else if (estudianteYaRegistrado == true)
                {
                    txNotificacionError.text = "Estudiante ya esta Registrado";
                }
                else
                {
                    idEstudiante = listaEstudiantes.Count;
                    EstudianteData estudianteData = new EstudianteData(idEstudiante, 
                                                                   inputFGrado.text, 
                                                                 inputFSeccion.text, 
                                                                  inputFNombre.text, 
                                                                inputFApellido.text, 
                                                                  inputFCodigo.text, 
                                                              inputFContraseña.text,
                                                                      "Desconectado",
                                                               loginData.Id_Usuario);
                    listaEstudiantes.Add(estudianteData);
                    estudianteRepository.SaveDataEstudiante(listaEstudiantes);
                    MostrarListaEnLog();
                    vaciarEspacios();
                    windowsController.OcultarVenRegistrarEst();
                }
            }
        }
        public void MostrarEstudiantes()
        {
            loginData = loginRepository.LoadDataLogin();
            List<EstudianteData> listE = estudianteRepository.LoadingDataEstudiante();
            string accumulatedTextID         = "";
            string accumulatedTextGrado      = "";
            string accumulatedTextSeccion    = "";
            string accumulatedTextNombre     = "";
            string accumulatedTextApellido   = "";
            string accumulatedTextUsuario    = "";
            string accumulatedTextContraseña = "";

            foreach (var estudiante in listE)
            {
                if (estudiante.Id_Docente == loginData.Id_Usuario && loginData.Tipo_Usuario == "Docente")
                {
                    accumulatedTextID += $"{estudiante.id_Estudiante}\n";
                    accumulatedTextGrado += $"{estudiante.Grado}\n";
                    accumulatedTextSeccion += $"{estudiante.Seccion}\n";
                    accumulatedTextNombre += $"{estudiante.Nombre}\n";
                    accumulatedTextApellido += $"{estudiante.Apellido}\n";
                    accumulatedTextUsuario += $"{estudiante.Email}\n";
                    accumulatedTextContraseña += $"{estudiante.Contraseña}\n";
                }
            }
            ContID.text = accumulatedTextID;
            ContGrado.text = accumulatedTextGrado;
            ContSeccion.text = accumulatedTextSeccion;
            ContNombre.text = accumulatedTextNombre;
            ContApellido.text = accumulatedTextApellido;
            ContUsuario.text = accumulatedTextUsuario;
            ContContraseña.text = accumulatedTextContraseña;
        }

        public void BuscarEstudiante()
        {
            loginData = loginRepository.LoadDataLogin();
            List<EstudianteData> listE = estudianteRepository.LoadingDataEstudiante();
            string accumulatedTextID         = "";
            string accumulatedTextGrado      = "";
            string accumulatedTextSeccion    = "";
            string accumulatedTextNombre     = "";
            string accumulatedTextApellido   = "";
            string accumulatedTextUsuario    = "";
            string accumulatedTextContraseña = "";

            foreach (var estudiante in listE)
            {
                if (estudiante.Id_Docente == loginData.Id_Usuario && loginData.Tipo_Usuario == "Docente")
                {
                    if (estudiante.id_Estudiante.ToString() == inputFBuscar.text
                        || estudiante.Grado == inputFBuscar.text
                        || estudiante.Seccion == inputFBuscar.text
                        || estudiante.Nombre == inputFBuscar.text
                        || estudiante.Apellido == inputFBuscar.text
                        || estudiante.Email == inputFBuscar.text
                        || estudiante.Contraseña == inputFBuscar.text)
                    {
                        accumulatedTextID += $"{estudiante.id_Estudiante}\n";
                        accumulatedTextGrado += $"{estudiante.Grado}\n";
                        accumulatedTextSeccion += $"{estudiante.Seccion}\n";
                        accumulatedTextNombre += $"{estudiante.Nombre}\n";
                        accumulatedTextApellido += $"{estudiante.Apellido}\n";
                        accumulatedTextUsuario += $"{estudiante.Email}\n";
                        accumulatedTextContraseña += $"{estudiante.Contraseña}\n";
                    }
                    if (inputFBuscar.text == "")
                    {
                        accumulatedTextID += $"{estudiante.id_Estudiante}\n";
                        accumulatedTextGrado += $"{estudiante.Grado}\n";
                        accumulatedTextSeccion += $"{estudiante.Seccion}\n";
                        accumulatedTextNombre += $"{estudiante.Nombre}\n";
                        accumulatedTextApellido += $"{estudiante.Apellido}\n";
                        accumulatedTextUsuario += $"{estudiante.Email}\n";
                        accumulatedTextContraseña += $"{estudiante.Contraseña}\n";
                    }
                }
            }
            ContID.text = accumulatedTextID;
            ContGrado.text = accumulatedTextGrado;
            ContSeccion.text = accumulatedTextSeccion;
            ContNombre.text = accumulatedTextNombre;
            ContApellido.text = accumulatedTextApellido;
            ContUsuario.text = accumulatedTextUsuario;
            ContContraseña.text = accumulatedTextContraseña;
        }

        public void EditarEstudiante()
        {
            loginData = loginRepository.LoadDataLogin();
            // if (inputFNombre.text == "" || inputFApellido.text == "" || inputFCodigo.text == "" || inputFContraseña.text == "") {
            //         txEditNotificacionError.text = "Llenar espacios en blanco";
            // }else{
            EstudianteData estudianteEditarDatos = listaEstudiantes.FirstOrDefault(
                                                estudiante =>
                                                estudiante.id_Estudiante.
                                                ToString() == inputFEditar.text);
            if (estudianteEditarDatos != null)
            {
                if (estudianteEditarDatos.Id_Docente == loginData.Id_Usuario && loginData.Tipo_Usuario == "Docente")
                {
                    estudianteEditarDatos.Grado = inputFEditGrado.text;
                    estudianteEditarDatos.Seccion = inputFEditSeccion.text;
                    estudianteEditarDatos.Nombre = inputFEditNombre.text;
                    estudianteEditarDatos.Apellido = inputFEditApellido.text;
                    estudianteEditarDatos.Email = inputFEditCodigo.text;
                    estudianteEditarDatos.Contraseña = inputFEditContraseña.text;

                    estudianteRepository.SaveDataEstudiante(listaEstudiantes);
                    estudianteRepository.LoadingDataEstudiante();
                    
                    MostrarEstudiantes();
                }

                else
                {
                    txEditNotifiUREdit.text = "Estudiante no Encontrado";
                }
            }
            else
            {
                txEditNotifiUREdit.text = "Estudiante no Encontrado";
            }
            // }
        }
        public void LlenarDatosEditarEstudiantes()
        {
            loginData = loginRepository.LoadDataLogin();
            //     List<EstudianteData> listLlenarEEstudiante = estudianteRepository.LoadingDataEstudiante();
            //     foreach(var estudiante in listLlenarEEstudiante) {
            //         if(estudiante.Id_Docente == idLoginUser){
            //             if(estudiante.id_Estudiante.ToString == InputF_IDEditarE) {
            //             }
            //         }
            //     }
            // if(inputFEditar.text == "") {
            //     txEditNotifiUREdit.text = "Llenar espacios en blanco";
            // }else{
            EstudianteData estudianteLlenarDatos = listaEstudiantes.FirstOrDefault(
                                                estudiante =>
                                                estudiante.id_Estudiante.
                                                ToString() == inputFEditar.text);
            if (estudianteLlenarDatos != null)
            {
                if (estudianteLlenarDatos.Id_Docente == loginData.Id_Usuario && loginData.Tipo_Usuario == "Docente")
                {
                    inputFEditGrado.text = estudianteLlenarDatos.Grado;
                    inputFEditSeccion.text = estudianteLlenarDatos.Seccion;
                    inputFEditNombre.text = estudianteLlenarDatos.Nombre;
                    inputFEditApellido.text = estudianteLlenarDatos.Apellido;
                    inputFEditCodigo.text = estudianteLlenarDatos.Email;
                    inputFEditContraseña.text = estudianteLlenarDatos.Contraseña;
                    windowsController.MostrarVenActualizarEstudiante();
                    txEditNotifiUREdit.text = "Estudiante Encontrado";

                }
                else
                {
                    txEditNotifiUREdit.text = "Estudiante no Encontrado";
                }
            }
            else
            {
                txEditNotifiUREdit.text = "Estudiante no Encontrado";
            }

            //}
        }
        public void EliminarEstudiante()
        {
            loginData = loginRepository.LoadDataLogin();
            //List<EstudianteData> listAEliminar = estudianteRepository.LoadingDataEstudiante();
            EstudianteData estudianteEliminar = listaEstudiantes.FirstOrDefault(estudiante => estudiante.id_Estudiante.ToString() == inputFEditar.text);
            if (estudianteEliminar != null)
            {
                if (estudianteEliminar.Id_Docente == loginData.Id_Usuario && loginData.Tipo_Usuario == "Docente")
                {
                    listaEstudiantes.Remove(estudianteEliminar);
                    estudianteRepository.DeleteDataEstudiante();
                    estudianteRepository.SaveDataEstudiante(listaEstudiantes);
                    estudianteRepository.LoadingDataEstudiante();
                    MostrarEstudiantes();
                }
                else
                {
                    txEditNotifiUREdit.text = "Estudiante no Encontrado";
                }
            }
            else
            {
                txEditNotifiUREdit.text = "Estudiante no Encontrado";
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
        public void vaciarEspacios()
        {
            inputFNombre.text = "";
            inputFApellido.text = "";
            inputFCodigo.text = "";
            inputFContraseña.text = "";
        }
        public void gIdDocente()
        {
            idLoginUser = iniciarSesionController.loginData.ObtenerLoginID();
            Debug.Log("LoginDataEstudiante: " + idLoginUser);
        }
        public void MostrarListaEnLog()
        {
            foreach (var estudiante in listaEstudiantes)
            {
                Debug.Log(message: $"Estudiante_Registrar - ID: {estudiante.id_Estudiante}, " +
                                                      $"Nombre: {estudiante.Nombre}, " +
                                                    $"Apellido: {estudiante.Apellido}, " +
                                                        $"User: {estudiante.Email}, " +
                                                        $"Pass: {estudiante.Contraseña}, " +
                                                      $"Id_Doc: {estudiante.Id_Docente}, " +
                                                      $"Estado: {estudiante.Estado}");
            }
        }
    }

}
