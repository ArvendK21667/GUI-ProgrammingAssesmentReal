using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine.SceneManagement;

public class SaveSystem : MonoBehaviour
{
    public void SaveCurrentBird()
    {
        SavePlayer(FindObjectOfType<BirdBoiScript>());
    }
    //Saves Game
   public static void SavePlayer (BirdBoiScript player)
    {
        BinaryFormatter formatter = new BinaryFormatter(); //Grabbing Formatter
        string path = Application.dataPath + "/player.fun"; //Creating a data path 
        FileStream stream = new FileStream(path, FileMode.Create); // opening file stream
        PlayerData data = new PlayerData(player); // Storing player data inside of a variable called data
        formatter.Serialize(stream, data); // Serializing the stream and the data
        stream.Close(); //close data stream
    }
    //Loads Game
    public static PlayerData LoadPlayer()
    {
        string path = Application.dataPath + "/player.fun";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter(); //Grabbing Formatter
            FileStream stream = new FileStream(path, FileMode.Open); //opening the stream

            PlayerData data = formatter.Deserialize(stream) as PlayerData; // Deserializing the stream and the data

            stream.Close(); //closes data stream

            return data; //returning data
        }
        else
        {
            Debug.LogError("Save file not found in" + path); //If path does not exist give an error
            return null; //return nothing
        }
    }
    public static void LoadBird()
    {
        var data = LoadPlayer();
        UnityEngine.SceneManagement.SceneManager.LoadScene(data.level);
    }
}
