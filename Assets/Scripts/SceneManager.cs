using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneControl
{
    public void ChangeScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void ChangeScene(int sceneIntId)
    {
        SceneManager.LoadScene(sceneIntId);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
