using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    private SceneControl sceneControl = new();

    public void ButtonPlay()
    {
        PlayerStats player = LoadSaveManager.LoadGame();
        string level = "Level" + player.lastLevel;
        sceneControl.ChangeScene(level);
    }

    public void ButtonReset()
    {
        PlayerStats player = new PlayerStats(true, 0, 1);
        LoadSaveManager.SaveGame(player);
    }

    public void ButtonTutorial()
    {
        sceneControl.ChangeScene("Tutorial");
    }

    public void ButtonExit()
    {
        sceneControl.ExitGame();
    }
}
