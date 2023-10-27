using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class TestPreguntaController
{
    [Test]
    public void TestRegistrarPregunta()
    {
        //PreguntaController preguntaController = new PreguntaController();

        //// Configura los campos necesarios para el registro
        //preguntaController.inputFEnunciado.text = "¿Cuál es la capital de Francia?";
        //preguntaController.inputFRespuesta.text = "París";
        //preguntaController.inputFaltA.text = "Londres";
        //preguntaController.inputFaltB.text = "Madrid";
        //preguntaController.inputFaltC.text = "Berlín";
        //preguntaController.inputFaltD.text = "París";

        //// Llama al método Registrar_Preguntas
        //preguntaController.Registrar_Preguntas();

        //// Verifica que la lista de preguntas y alternativas tenga al menos un elemento
        //Assert.IsTrue(preguntaController.listPreguntas.Count > 0);
        //Assert.IsTrue(preguntaController.listAlternativas.Count > 0);
    }
    [Test]
    public void TestEditarPregunta()
    {
        //PreguntaController preguntaController = new PreguntaController();
        //// Agregar una pregunta de prueba a la lista de preguntas y sus alternativas
        //// ...

        //// Configura los campos de edición
        //preguntaController.InputF_IDEditar.text = "1";
        //preguntaController.inputFEditEnun.text = "Nueva pregunta";
        //preguntaController.inputFEditResp.text = "Nueva respuesta";

        //// Llama al método EditarPregunta
        //preguntaController.EditarPregunta();

        //// Obtén la pregunta editada de la lista
        //var preguntaEditada = preguntaController.listPreguntas.First(p => p.Id_Pregunta == 1);

        //// Verifica que la pregunta se haya actualizado correctamente
        //Assert.AreEqual("Nueva pregunta", preguntaEditada.Enunciado);
        //// Asegúrate de que los campos de alternativas también se actualicen correctamente
    }
    [Test]
    public void TestEliminarPregunta()
    {
        //PreguntaController preguntaController = new PreguntaController();
        //// Agregar una pregunta de prueba a la lista de preguntas y sus alternativas
        //// ...

        //// Configura el campo de ID de pregunta para eliminar
        //preguntaController.InputF_IDEditar.text = "1";

        //// Llama al método EliminarPregunta
        //preguntaController.EliminarPregunta();

        //// Verifica que la pregunta y sus alternativas se hayan eliminado correctamente
        //var preguntaEliminada = preguntaController.listPreguntas.FirstOrDefault(p => p.Id_Pregunta == 1);
        //Assert.IsNull(preguntaEliminada);

        //// Asegúrate de que las alternativas también se hayan eliminado
        //var alternativasEliminadas = preguntaController.listAlternativas
        //    .Where(a => a.Id_Pregunta == 1)
        //    .ToList();
        //Assert.AreEqual(0, alternativasEliminadas.Count);
    }
    [Test]
    public void TestLlenarDatosEditar()
    {
        //PreguntaController preguntaController = new PreguntaController();
        //// Agregar algunas preguntas de prueba a la lista de preguntas y sus alternativas
        //// ...

        //// Configura el campo de ID de pregunta a editar
        //preguntaController.InputF_IDEditar.text = "1";

        //// Llama al método LlenarDatosEditar
        //preguntaController.LlenarDatosEditar();

        //// Verifica que los campos de edición se llenen correctamente con la pregunta 1
        //Assert.AreEqual("Pregunta 1", preguntaController.inputFEditEnun.text);
        //Assert.AreEqual("Respuesta 1", preguntaController.inputFEditResp.text);
        //// Asegúrate de que los campos de alternativas también se llenen correctamente
    }




}
