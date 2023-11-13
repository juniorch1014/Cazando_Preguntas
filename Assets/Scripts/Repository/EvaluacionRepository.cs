using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public class EvaluacionRepository : MonoBehaviour
{
    public void SaveDataEvaluacion(List<EvaluacionData> data)
    {
        string destination = Application.persistentDataPath + "/saveEvaluacion.dat";
        FileStream file;

        if (File.Exists(destination))
        {
            file = File.OpenWrite(destination);
            Debug.Log("Save file saveEvaluacion.dat");

        }
        else
        {
            file = File.Create(destination);
            Debug.Log("Create file saveEvaluacion.dat");

        }
        BinaryFormatter bf = new BinaryFormatter();
        bf.Serialize(file, data);
        file.Close();
    }
    public List<EvaluacionData> LoadingDataEvaluacion()
    {
        Debug.Log("Loading file saveEvaluacion.dat");
        string destination = Application.persistentDataPath + "/saveEvaluacion.dat";
        FileStream file;

        if (File.Exists(destination))
        {
            file = File.OpenRead(destination);
        }
        else
        {
            return new List<EvaluacionData>();
        }
        BinaryFormatter bf = new BinaryFormatter();
        List<EvaluacionData> data = (List<EvaluacionData>)bf.Deserialize(file);
        file.Close();

        return data;
    }
    public void DeleteDataEvaluacion()
    {
        string destination = Application.persistentDataPath + "/saveEvaluacion.dat";
        if (File.Exists(destination))
        {
            File.Delete(destination);
        }
    }
}
