using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Island1 : LevelManager
{
    [Header("GUI Level 1")]
    [SerializeField] private TMP_Text textPoints;

    private int pointsToWin;

    private void Start()
    {
        pointsToWin = Numbers.Count;
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
            if (Numbers.Count != 0)
            {
                WorldNumber wNumber = GetNumberPosition(Numbers[0]);
                if (wNumber != null)
                {
                    Vector3 fixedPosition = new Vector3(wNumber.transform.position.x,
                                                        wNumber.transform.position.y + 2f,
                                                        wNumber.transform.position.z);
                    GenerateScrew(Numbers[0], fixedPosition);
                }
            }
        }
    }
}
