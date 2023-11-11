using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class AsignarPreguntaRepository : MonoBehaviour
{
    public void SaveDataAsignarPregunta(List<AsignarPreguntaData> data) {
        string destination = Application.persistentDataPath + "/saveAsignarPreguntas.dat";
        FileStream file;

        if (File.Exists(destination))
        {
            file = File.OpenWrite(destination);
            Debug.Log("Save file saveAsignarPreguntas.dat");

        }
        else
        {
            file = File.Create(destination);
            Debug.Log("Create file saveAsignarPreguntas.dat");

        }
        BinaryFormatter bf = new BinaryFormatter();
        bf.Serialize(file, data);
        file.Close();
    }
    public List<AsignarPreguntaData> LoadingDataAsignarPregunta()
    {
        Debug.Log("Loading file saveAsignarPreguntas.dat");
        string destination = Application.persistentDataPath + "/saveAsignarPreguntas.dat";
        FileStream file;

        if (File.Exists(destination))
        {
            file = File.OpenRead(destination);
        }
        else
        {
            return new List<AsignarPreguntaData>();
        }
        BinaryFormatter bf = new BinaryFormatter();
        List<AsignarPreguntaData> data = (List<AsignarPreguntaData>)bf.Deserialize(file);
        file.Close();

        return data;
    }
    public void DeleteDataAsignarPregunta() {
        string destination = Application.persistentDataPath + "/saveAsignarPreguntas.dat";
        if (File.Exists(destination)) {
            File.Delete(destination);
        }
   }
}   
