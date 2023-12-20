using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Island4 : LevelManager
{
    [Header("Screw Managment")]
    [SerializeField] private float screwSpeed;
    [SerializeField] private float yEndPosition;
    [SerializeField] private int repetitions = 3;
    
    private Vector3 spawnScrewPosition;
    private int repetitionsActualScrew = 0;
    private int lostScrews = 0;

    private void Update()
    {
        UpdateGUI();
        ScrewMovement();
        ScrewControl();
        WinCondition();
    }

    private void WinCondition()
    {
        if (LocalPoints + lostScrews == PointsToWin)
        {
            if (lostScrews > 0)
            {
                EndLevel(false);
            }
            else
            {
                EndLevel(true);
            }
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
                                                        wNumber.transform.position.y + 5f,
                                                        wNumber.transform.position.z);
                    GenerateScrew(Numbers[0], fixedPosition);
                    spawnScrewPosition = fixedPosition;
                }
            }
        }
    }

    private void ScrewMovement()
    {
        if (Screw != null)
        {
            Screw.transform.position += new Vector3(0, screwSpeed * Time.deltaTime * -1, 0);
            Screw.transform.Rotate(Vector3.forward * (screwSpeed + 20) * Time.deltaTime);
            if (Screw.transform.position.y <= yEndPosition)
            {
                repetitionsActualScrew++;
                if (repetitionsActualScrew <= repetitions)
                {
                    Screw.transform.position = spawnScrewPosition;
                }
                else
                {
                    Destroy(Screw.gameObject);
                    lostScrews++;
                }
            }
        }
        else
        {
            repetitionsActualScrew = 0;
        }
    }
}
