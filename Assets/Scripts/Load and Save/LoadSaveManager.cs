using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class LoadSaveManager : MonoBehaviour
{
    private static string saveRute = Application.dataPath + "/gameSave.json";

    public static PlayerStats LoadGame()
    {
        PlayerStats playerStats = new PlayerStats(true, 0, 0);
        if (File.Exists(saveRute))
        {
            string content = File.ReadAllText(saveRute);
            playerStats = JsonUtility.FromJson<PlayerStats>(content);
        }
        else
        {
            Debug.Log("File does not exist");
        }
        return playerStats;
    }

    public static void SaveGame(PlayerStats playerStats)
    {
        string content = JsonUtility.ToJson(playerStats);
        File.WriteAllText(saveRute, content);
        Debug.Log("File save");
    }
}
