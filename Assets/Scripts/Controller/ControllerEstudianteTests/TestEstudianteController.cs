using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class TestEstudianteController
{
    [Test]
    public void TestRegistrarEstudiante()
    {
        //EstudianteController estudianteController = new EstudianteController();

        //// Configura los campos necesarios para el registro
        //estudianteController.inputFGrado.text = "Grado1";
        //estudianteController.inputFSeccion.text = "A";
        //estudianteController.inputFNombre.text = "John";
        //estudianteController.inputFApellido.text = "Doe";
        //estudianteController.inputFCodigo.text = "john@example.com";
        //estudianteController.inputFContrase�a.text = "password";

        //// Llama al m�todo Registrar_Est
        //estudianteController.Registrar_Est();

        //// Verifica que la lista de estudiantes tenga al menos un estudiante
        //Assert.IsTrue(estudianteController.listaEstudiantes.Count > 0);
    }

    [Test]
    public void TestBuscarEstudiante()
    {
        //EstudianteController estudianteController = new EstudianteController();
        //// Agregar algunos estudiantes de prueba a la lista de estudiantes
        //// ...

        //// Configura el campo de b�squeda
        //estudianteController.inputFBuscar.text = "John";

        //// Llama al m�todo BuscarEstudiante
        //estudianteController.BuscarEstudiante();

        //// Verifica que los resultados sean correctos
        //Assert.AreEqual("John", estudianteController.ContNombre.text.Trim());
        //// Aseg�rate de que los dem�s campos tambi�n sean correctos
    }

    [Test]
    public void TestEditarEstudiante()
    {
        //EstudianteController estudianteController = new EstudianteController();
        //// Agregar un estudiante de prueba a la lista de estudiantes
        //// ...

        //// Configura los campos de edici�n
        //estudianteController.inputFEditar.text = "1";
        //estudianteController.inputFEditNombre.text = "UpdatedName";

        //// Llama al m�todo EditarEstudiante
        //estudianteController.EditarEstudiante();

        //// Obt�n el estudiante editado de la lista
        //var estudianteEditado = estudianteController.listaEstudiantes.First(e => e.id_Estudiante == 1);

        //// Verifica que el nombre se haya actualizado correctamente
        //Assert.AreEqual("UpdatedName", estudianteEditado.Nombre);
        //// Aseg�rate de que los dem�s campos tambi�n se actualicen correctamente
    }




}
