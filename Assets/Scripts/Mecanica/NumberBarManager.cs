using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class NumberBarManager : MonoBehaviour
{
    [SerializeField] private Color highlightColor;
    [SerializeField] private List<GameObject> uiNumbers;
    [SerializeField] private List<AudioClip> numbers_audio;
    [SerializeField] private List<WorldNumber> worldNumbers;

    private AudioSource audioSource;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void Start()
    {
        // setting pos of world numbers
        int index = 0;
        foreach (var number in uiNumbers)
        {
            RectTransform uiNumber = number.GetComponent<RectTransform>();
            Vector3 pos = Camera.main.ScreenToWorldPoint(uiNumber.position);
            pos = new Vector3(pos.x, pos.y, 0);
            worldNumbers[index].SetPosition(pos);
            index++;
        }
    }

    public void HighlightNumber(int num)
    {
        int index = 0;
        foreach (var number in uiNumbers)
        {
            TMP_Text numText = number.GetComponent<TMP_Text>();
            if (number.name == num.ToString())
            {
                // Resalto numero de la barra
                numText.color = highlightColor;
                audioSource.clip = numbers_audio[index];
                audioSource.Play();
                // higligth world number
                worldNumbers[index].lineColor = highlightColor;
            }
            else
            {
                numText.color = Color.white;
                worldNumbers[index].lineColor = Color.black;
            }
            index++;
        }
    }

    public void HighlightNumberNoSound(int num)
    {
        int index = 0;
        foreach (var number in uiNumbers)
        {
            TMP_Text numText = number.GetComponent<TMP_Text>();
            if (number.name == num.ToString())
            {
                numText.color = highlightColor;
                // higligth world number
                worldNumbers[index].lineColor = highlightColor;
            }
            else
            {
                numText.color = Color.white;
                worldNumbers[index].lineColor = Color.black;
            }
            index++;
        }
    }
}
