using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class EstudianteRepository : MonoBehaviour
{
    public void SaveDataEstudiante(List<EstudianteData> data) {
        string destination = Application.persistentDataPath + "/saveEstudiante.dat";
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
   public List<EstudianteData> LoadingDataEstudiante() {
        Debug.Log("Loading file saveDocente.dat");
        string destination = Application.persistentDataPath + "/saveEstudiante.dat";
        FileStream file;

        if (File.Exists(destination)) {
            file = File.OpenRead(destination);
        }else {
            return new List<EstudianteData>();
        }
        BinaryFormatter bf = new BinaryFormatter();
        List<EstudianteData> data = (List<EstudianteData>) bf.Deserialize(file);
        file.Close();

        return data;
   }
   public void DeleteDataEstudiante() {
        string destination = Application.persistentDataPath + "/saveEstudiante.dat";
        if (File.Exists(destination)) {
            File.Delete(destination);
        }
   }
}
