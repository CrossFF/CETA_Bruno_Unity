using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Level1 : LevelManager
{
    [SerializeField] private List<int> numbers;

    [Header("GUI")]
    [SerializeField] private TMP_Text textPoints;

    private int pointsToWin;

    private void Start()
    {
        pointsToWin = numbers.Count;
    }

    private void Update()
    {
        // actualizacion de puntos
        string tPoints = LocalPoints + "/" + pointsToWin;
        textPoints.text = tPoints;

        // win condition
        if (LocalPoints == pointsToWin)
        {
            EndLevel();
        }

        // instanciado de tuerca (A mejorar)
        if (Screw == null)
        {
            if (numbers.Count != 0)
            {
                GenerateScrew(numbers[0]);
                numbers.Remove(numbers[0]);
            }
        }
    }
}
