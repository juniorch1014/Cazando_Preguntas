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
        //docenteController.inputFContrase�a.text = "password";

        //// Llama al m�todo Registrar_DocEst
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

        //// Configura los campos de b�squeda
        //docenteController.inputFNombre.text = "John";

        //// Llama al m�todo Update (o simula su llamada) para que actualice la b�squeda
        //docenteController.Update();

        //// Verifica que los resultados sean correctos
        //Assert.AreEqual("John", docenteController.txNotificacionError.text.Trim());
        //// Aseg�rate de que los dem�s campos tambi�n sean correctos
    }
    [Test]
    public void TestMayusConversion()
    {
        //DocenteController docenteController = new DocenteController();
        //TMP_InputField inputField = new TMP_InputField();
        //inputField.text = "junior";

        //// Llama al m�todo Mayus para convertir a may�sculas
        //docenteController.Mayus(inputField);

        //// Verifica que el texto se haya convertido a may�sculas correctamente
        //Assert.AreEqual("JUNIOR", inputField.text);
    }

    [Test]
    public void TestMinusConversion()
    {
        //DocenteController docenteController = new DocenteController();
        //TMP_InputField inputField = new TMP_InputField();
        //inputField.text = "JUNIOR";

        //// Llama al m�todo Minus para convertir a min�sculas
        //docenteController.Minus(inputField);

        //// Verifica que el texto se haya convertido a min�sculas correctamente
        //Assert.AreEqual("JUNIOR", inputField.text);
    }



}
