using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartScene : MonoBehaviour
{
    [SerializeField] private AudioSource voiceLine;

    void Start()
    {
        StartCoroutine(SceneControl());
    }

    private IEnumerator SceneControl()
    {
        SceneControl sceneControl = new();
        yield return new WaitForSeconds(1f);
        voiceLine.Play();
        yield return new WaitForSeconds(5f);
        PlayerStats player = LoadSaveManager.LoadGame();
        if (player.neverPlay)
        {
            // cinematica inicial

            sceneControl.ChangeScene("StartCinematic");
        }
        else
        {
            // al menu principal
            sceneControl.ChangeScene("MainMenu");
        }
    }
}
