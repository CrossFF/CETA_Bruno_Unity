using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class LoadSaveManager : MonoBehaviour
{
    private string saveRute;
    private PlayerStats playerStats = new();

    private void Awake()
    {
        saveRute = Application.dataPath + "/gameSave.json";
    }

    public void LoadGame()
    {
        if(File.Exists(saveRute))
        {
            string content = File.ReadAllText(saveRute);
            playerStats = JsonUtility.FromJson<PlayerStats>(content);
        }
        else
        {
            Debug.Log("File does not exist");
        }
    }

    public void SaveGame()
    {

    }
}
