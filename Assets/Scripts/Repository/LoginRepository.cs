using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
public class LoginRepository : MonoBehaviour
{
    public void SaveDataLogin(LoginData data) {
        string destination = Application.persistentDataPath + "/saveLogin.dat";
        FileStream file;

        if (File.Exists(destination))
        {
            file = File.Create(destination);
            Debug.Log("Save file saveLogin.dat");
        }
        else
        {
            file = File.Create(destination);
            Debug.Log("Create file saveLogin.dat");
        }
        BinaryFormatter bf = new BinaryFormatter();
        bf.Serialize(file, data);
        file.Close();

    }
    public LoginData LoadDataLogin()
    {
        Debug.Log("Loading file saveLogin.dat");
        string destination = Application.persistentDataPath + "/saveLogin.dat";
        FileStream file;

        if (File.Exists(destination))
        {
            file = File.OpenRead(destination);
        }
        else
        {
            return new LoginData();
        }
        BinaryFormatter bf = new BinaryFormatter();
        LoginData data = (LoginData)bf.Deserialize(file);
        file.Close();

        return data;
    }
    public void DeleteDataLogin()
    {
        string destination = Application.persistentDataPath + "/saveLogin.dat";
        if (File.Exists(destination))
        {
            File.Delete(destination);
        }
    }

}
