using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class AltenativaRepository : MonoBehaviour
{
    public void SaveDataAltenativa(List<AlternativasData> data) {
        string destination = Application.persistentDataPath + "/saveAltenativa.dat";
        FileStream file;

        if (File.Exists(destination)) {
            file = File.OpenWrite(destination);
            Debug.Log("Save file saveAltenativa.dat");

        }
        else {
            file = File.Create(destination);
            Debug.Log("Create file saveAltenativa.dat");

        }
        BinaryFormatter bf = new BinaryFormatter();
        bf.Serialize(file,data);
        file.Close();
   }
   public List<AlternativasData> LoadingDataAltenativa() {
        Debug.Log("Loading file saveAltenativa.dat");
        string destination = Application.persistentDataPath + "/saveAltenativa.dat";
        FileStream file;

        if (File.Exists(destination)) {
            file = File.OpenRead(destination);
        }else {
            return new List<AlternativasData>();
        }
        BinaryFormatter bf = new BinaryFormatter();
        List<AlternativasData> data = (List<AlternativasData>) bf.Deserialize(file);
        file.Close();

        return data;
   }
   public void DeleteDataAltenativa() {
        string destination = Application.persistentDataPath + "/saveAltenativa.dat";
        if (File.Exists(destination)) {
            File.Delete(destination);
        }
   }
}
