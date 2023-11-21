using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Island2 : LevelManager
{
    private void Update()
    {
        UpdateGUI();
        WinCondition();
        ScrewControl();
    }

    private void WinCondition()
    {
        // win condition
        if (LocalPoints == PointsToWin)
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
                    Vector3 fixedPosition = new Vector3(wNumber.transform.position.x - 2f,
                                                        wNumber.transform.position.y,
                                                        wNumber.transform.position.z);
                    GenerateScrew(Numbers[0], fixedPosition);
                }
            }
        }
    }
}
