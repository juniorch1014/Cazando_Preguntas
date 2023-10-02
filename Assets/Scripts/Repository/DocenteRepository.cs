using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class DocenteRepository : MonoBehaviour
{
   public void SaveDataDocente(List<DocenteData> data) {
        string destination = Application.persistentDataPath + "/saveDocente.dat";
        FileStream file;

        if (File.Exists(destination)) {
            file = File.OpenWrite(destination);
            Debug.Log("Save file saveDocente.dat");

        }
        else {
            file = File.Create(destination);
            Debug.Log("Create file saveDocente.dat");

        }
        BinaryFormatter bf = new BinaryFormatter();
        bf.Serialize(file,data);
        file.Close();
   }
   public List<DocenteData> LoadingDataDocente() {
        Debug.Log("Loading file saveDocente.dat");
        string destination = Application.persistentDataPath + "/saveDocente.dat";
        FileStream file;

        if (File.Exists(destination)) {
            file = File.OpenRead(destination);
        }else {
            return new List<DocenteData>();
        }
        BinaryFormatter bf = new BinaryFormatter();
        List<DocenteData> data = (List<DocenteData>) bf.Deserialize(file);
        file.Close();

        return data;
   }
   public void DeleteDataDocente() {
        string destination = Application.persistentDataPath + "/saveDocente.dat";
        if (File.Exists(destination)) {
            File.Delete(destination);
        }
   }
}
