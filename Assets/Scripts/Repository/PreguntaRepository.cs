using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class PreguntaRepository : MonoBehaviour
{
    public void SaveDataPregunta(List<PreguntaData> data) {
        string destination = Application.persistentDataPath + "/savePregunta.dat";
        FileStream file;

        if (File.Exists(destination)) {
            file = File.OpenWrite(destination);
            Debug.Log("Save file savePregunta.dat");

        }
        else {
            file = File.Create(destination);
            Debug.Log("Create file savePregunta.dat");

        }
        BinaryFormatter bf = new BinaryFormatter();
        bf.Serialize(file,data);
        file.Close();
   }
   public List<PreguntaData> LoadingDataPregunta() {
        Debug.Log("Loading file savePregunta.dat");
        string destination = Application.persistentDataPath + "/savePregunta.dat";
        FileStream file;

        if (File.Exists(destination)) {
            file = File.OpenRead(destination);
        }else {
            return new List<PreguntaData>();
        }
        BinaryFormatter bf = new BinaryFormatter();
        List<PreguntaData> data = (List<PreguntaData>) bf.Deserialize(file);
        file.Close();

        return data;
   }
   public void DeleteDataPregunta() {
        string destination = Application.persistentDataPath + "/savePregunta.dat";
        if (File.Exists(destination)) {
            File.Delete(destination);
        }
   }
}
