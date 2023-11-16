using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Level1 : LevelManager
{
    [Header("Numbers for the Level")]
    [SerializeField] private bool random = false;
    [SerializeField] private List<int> numbers;

    [Header("GUI Level 1")]
    [SerializeField] private TMP_Text textPoints;

    private int pointsToWin;

    private void Start()
    {
        pointsToWin = numbers.Count;
        // si la lista de numeros es random
        //// genero esa cantidad de numeros
        //(A mejorar)
        if(random)
        {
            for (int i = 0; i < numbers.Count; i++)
            {
                numbers[i] = Random.Range(0,11);
            }
        }
    }

    private void Update()
    {
        GUIUpdate();
        WinCondition();
        ScrewControl();
    }

    private void GUIUpdate()
    {
        // actualizacion de puntos
        string tPoints = LocalPoints + "/" + pointsToWin;
        textPoints.text = tPoints;
    }

    private void WinCondition()
    {
        // win condition
        if (LocalPoints == pointsToWin)
        {
            EndLevel(true);
        }
    }

    private void ScrewControl()
    {
        // instanciado de tuerca
        // si no existe una tuerca
        //// si todavia quedan numeros
        ////// solicito poscicion del numero al manager
        ////// remuevo el numero
        ////// le digo al manager que instancie la tuerca en la posicion deseada
        if (Screw == null)
        {
            if (numbers.Count != 0)
            {
                WorldNumber wNumber = GetNumberPosition(numbers[0]);
                if (wNumber != null)
                {
                    Vector3 fixedPosition = new Vector3(wNumber.transform.position.x,
                                                        wNumber.transform.position.y + 2f,
                                                        wNumber.transform.position.z);
                    GenerateScrew(numbers[0], fixedPosition);
                    numbers.Remove(numbers[0]);
                }
            }
        }
    }
}
