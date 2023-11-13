using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public class AsignarRepository : MonoBehaviour
{
    public void SaveDataAsignarData(AsignarData data)
    {
        string destination = Application.persistentDataPath + "/saveAsignarData.dat";
        FileStream file;

        if (File.Exists(destination))
        {
            file = File.Create(destination);
            Debug.Log("Save file saveAsignarData.dat");
        }
        else
        {
            file = File.Create(destination);
            Debug.Log("Create file saveAsignarData.dat");
        }
        BinaryFormatter bf = new BinaryFormatter();
        bf.Serialize(file, data);
        file.Close();

    }
    public AsignarData LoadDataAsignarData()
    {
        Debug.Log("Loading file saveAsignarData.dat");
        string destination = Application.persistentDataPath + "/saveAsignarData.dat";
        FileStream file;

        if (File.Exists(destination))
        {
            file = File.OpenRead(destination);
        }
        else
        {
            return new AsignarData();
        }
        BinaryFormatter bf = new BinaryFormatter();
        AsignarData data = (AsignarData)bf.Deserialize(file);
        file.Close();

        return data;
    }
    public void DeleteDataLogin()
    {
        string destination = Application.persistentDataPath + "/saveAsignarData.dat";
        if (File.Exists(destination))
        {
            File.Delete(destination);
        }
    }
}
