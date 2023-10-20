using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class NumberBarManager : MonoBehaviour
{
    [SerializeField] private Color highlightColor;
    [SerializeField] private List<GameObject> numbers;
    [SerializeField] private List<AudioClip> numbers_audio;
    private AudioSource audioSource;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void HighlightNumber(int num)
    {
        int index = 0;
        foreach (var number in numbers)
        {
            TMP_Text numText = number.GetComponent<TMP_Text>();
            if (number.name == num.ToString())
            {
                numText.color = highlightColor;
                audioSource.clip = numbers_audio[index];
                audioSource.Play();
            }
            else
            {
                numText.color = Color.white;
            }
            index++;
        }
    }

    public void HighlightNumberNoSound(int num)
    {
        foreach (var number in numbers)
        {
            TMP_Text numText = number.GetComponent<TMP_Text>();
            if (number.name == num.ToString())
            {
                numText.color = highlightColor;
            }
            else
            {
                numText.color = Color.white;
            }
        }
    }
}
