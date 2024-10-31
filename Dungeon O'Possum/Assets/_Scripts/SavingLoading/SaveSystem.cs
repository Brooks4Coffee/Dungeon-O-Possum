using UnityEngine;
using System.IO; 
using System.Runtime.Serialization.Formatters.Binary;

//Tutorial Used: https://www.youtube.com/watch?v=XOjd_qU2Ido
public static class SaveSystem {

    public static void SavePlayer( Player player ) {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/player.ehe";
        FileStream stream = new FileStream(path, FileMode.Create); 
        PlayerData data = new PlayerData(player);
        formatter.Serialize(stream, data);
        stream.Close();
    }

    public static PlayerData LoadPlayer() {
        string path = Application.persistentDataPath + "/player.ehe";
        if (File.Exists(path)) {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);
            PlayerData data = formatter.Deserialize(stream) as PlayerData; 
            stream.Close();
            return data; 
        } 
        else {
            Debug.LogError("Save File Not Found in " + path);
            return null; 
        }
    }

}
