using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class TestDocenteController
{
    [Test]
    public void TestRegistrarDocente()
    {
        //DocenteController docenteController = new DocenteController();

        //// Configura los campos necesarios para el registro
        //docenteController.inputFNombre.text = "John";
        //docenteController.inputFApellido.text = "Doe";
        //docenteController.inputFCodigo.text = "john@example.com";
        //docenteController.inputFContraseña.text = "password";

        //// Llama al método Registrar_DocEst
        //docenteController.Registrar_DocEst();

        //// Verifica que la lista de docentes tenga al menos un docente
        //Assert.IsTrue(docenteController.listaDocentes.Count > 0);
    }

    [Test]
    public void TestBuscarDocente()
    {
        //DocenteController docenteController = new DocenteController();
        //// Agregar algunos docentes de prueba a la lista de docentes
        //// ...

        //// Configura los campos de búsqueda
        //docenteController.inputFNombre.text = "John";

        //// Llama al método Update (o simula su llamada) para que actualice la búsqueda
        //docenteController.Update();

        //// Verifica que los resultados sean correctos
        //Assert.AreEqual("John", docenteController.txNotificacionError.text.Trim());
        //// Asegúrate de que los demás campos también sean correctos
    }
    [Test]
    public void TestMayusConversion()
    {
        //DocenteController docenteController = new DocenteController();
        //TMP_InputField inputField = new TMP_InputField();
        //inputField.text = "junior";

        //// Llama al método Mayus para convertir a mayúsculas
        //docenteController.Mayus(inputField);

        //// Verifica que el texto se haya convertido a mayúsculas correctamente
        //Assert.AreEqual("JUNIOR", inputField.text);
    }

    [Test]
    public void TestMinusConversion()
    {
        //DocenteController docenteController = new DocenteController();
        //TMP_InputField inputField = new TMP_InputField();
        //inputField.text = "JUNIOR";

        //// Llama al método Minus para convertir a minúsculas
        //docenteController.Minus(inputField);

        //// Verifica que el texto se haya convertido a minúsculas correctamente
        //Assert.AreEqual("JUNIOR", inputField.text);
    }



}
