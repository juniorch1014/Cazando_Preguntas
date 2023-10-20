using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DocenteController : MonoBehaviour
{   

    List<DocenteData> listaDocentes = new List<DocenteData>();
    List<EstudianteData> listaEstudiantes = new List<EstudianteData>();

    public DocenteRepository docenteRepository;
    WindowsController windowsController;
    public TMP_Dropdown DropdUsuario;
    public TMP_Text txNotificacionError;
    public TMP_Text txNotifiID; 
    public TMP_InputField inputFNombre;
    public TMP_InputField inputFApellido;
    public TMP_InputField inputFCodigo;
    public TMP_InputField inputFContraseña;

    int idDocente = 0;
    
    string selectedValue = "Docente";

    // Start is called before the first frame update
    void Start()
    {   
       // docenteRepository = GetComponent<DocenteRepository>();
        windowsController = GetComponent<WindowsController>();
        listaDocentes     = docenteRepository.LoadingDataDocente();
        MostrarListaEnLog();
        // Agrega un listener para el evento de cambio en el Dropdown
       // DropdUsuario.onValueChanged.AddListener(OnDropdownValueChanged);
    }

    // Update is called once per frame
    void Update()
    {
        foreach (var docente in listaDocentes) {
            if(inputFNombre.text == docente.Nombre && inputFApellido.text == docente.Apellido){
                txNotificacionError.text = "Docente ya Registrado";
            }
            
            if (inputFCodigo.text == docente.Email){
                txNotifiID.text = inputFCodigo.text + " : ya esta regitrado";
            }
        }

    }
    
    public void Registrar_DocEst() {
        if (selectedValue == "Docente") {
            if (inputFNombre.text == "" || inputFApellido.text == "" || inputFCodigo.text == "" || inputFContraseña.text == "") {
                txNotificacionError.text = "Llenar espacios en blanco";
            }else {
                idDocente = listaDocentes.Count;
                    DocenteData docenteData = new DocenteData(idDocente,inputFNombre.text, inputFApellido.text, inputFCodigo.text, inputFContraseña.text);
                    listaDocentes.Add(docenteData);
                    docenteRepository.SaveDataDocente(listaDocentes);
                    MostrarListaEnLog();
                    vaciarEspacios();
                    windowsController.OcultarVenRegistrarDoc();    
                }
                
            }
    }
    
    public void vaciarEspacios(){
        txNotifiID.text         = "";
        txNotificacionError.text= "";
        inputFNombre.text       = "";
        inputFApellido.text     = "";
        inputFCodigo.text       = "";
        inputFContraseña.text   = "";
    }

    // private void OnDropdownValueChanged(int value)
    // {
    //     // Cuando cambia la selección en el Dropdown, esta función se llama automáticamente
    //     // Puedes obtener el valor seleccionado usando la propiedad value
    //     selectedValue = DropdUsuario.options[value].text;

    //     // Haz lo que desees con el valor seleccionado
    //     Debug.Log("Valor seleccionado: " + selectedValue);
    // }
    public void MostrarListaEnLog()
    {
        foreach (var docente in listaDocentes)
        {
            Debug.Log($"ID: {docente.id_Docente}, Nombre: {docente.Nombre}, Apellido: {docente.Apellido}, User: {docente.Email}, Pass: {docente.Contraseña}");

        }
    }
}
