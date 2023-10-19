using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class NumberBarManager : MonoBehaviour
{
    [SerializeField] private Color highlightColor;
    [SerializeField] private List<GameObject> numbers;

    public void HighlightNumber(int num)
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
