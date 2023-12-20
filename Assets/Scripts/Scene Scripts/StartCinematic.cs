using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartCinematic : MonoBehaviour
{
    [SerializeField] private AudioSource voice;
    [SerializeField] private List<AudioClip> voiceClips;

    void Start()
    {
        StartCoroutine(SceneControl());
    }

    private IEnumerator SceneControl()
    {
        foreach (var clip in voiceClips)
        {
            voice.clip = clip;
            voice.Play();
            yield return new WaitForSeconds(clip.length + 0.5f);
        }
        SceneControl sceneControl = new SceneControl();
        sceneControl.ChangeScene("Tutorial");
    }
}
