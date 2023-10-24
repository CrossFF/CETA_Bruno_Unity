using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    private SceneControl sceneControl = new();

    public void ButtonPlay()
    {
        
    }

    public void ButtonReset()
    {
        
    }

    public void ButtonTutorial()
    {

    }

    public void ButtonExit()
    {
        sceneControl.ExitGame();
    }
}
