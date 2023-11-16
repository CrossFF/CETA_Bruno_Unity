using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextLevel : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Animator animatorScene;
    [SerializeField] private Animator animatorCanvas;
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private List<AudioClip> goodWorkClips;
    [SerializeField] private float time1;
    [SerializeField] private float time2;
    [SerializeField] private float time3;

    private void Start()
    {
        StartCoroutine(Actions());
    }

    private IEnumerator Actions()
    {
        // animaciones de la escena
        // tiempo de espera
        // sonido de bien hecho
        // tiempo de espera
        // fade out
        // tiempo de espera
        // siguiente nivel

        // animaciones
        yield return new WaitForSeconds(time1);
        int num = Random.Range(0, goodWorkClips.Count);
        audioSource.clip = goodWorkClips[num];
        audioSource.Play();
        yield return new WaitForSeconds(time2);
        // fade out
        yield return new WaitForSeconds(time3);
        ToTheNextLevel();
    }

    private void ToTheNextLevel()
    {
        PlayerStats player = LoadSaveManager.LoadGame();
        int num = player.lastLevel + 1;
        string nextLevel = "Level" + num;
        SceneControl sceneControl = new();
        sceneControl.ChangeScene(nextLevel);
    }
}
