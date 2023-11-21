using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Island3 : LevelManager
{
    [Header("Screw Managment")]
    [SerializeField] private float screwSpeed;
    [SerializeField] private float xEndPosition;
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

    private void ScrewControl()
    {
        // si no existe una tuerca
        //// si todavia quedan numeros
        ////// si el siguiente numero es 0 genero uno nuevo
        ////// solicito poscicion del numero al manager
        ////// remuevo el numero
        ////// le digo al manager que instancie la tuerca en la posicion deseada
        if (Screw == null)
        {
            if (Numbers.Count != 0)
            {
                int num = Numbers[0] == 0 ? UnityEngine.Random.Range(1, 11) : Numbers[0];
                WorldNumber wNumber = GetNumberPosition(num);
                if (wNumber != null)
                {
                    Vector3 fixedPosition = new Vector3(wNumber.transform.position.x,
                                                        wNumber.transform.position.y,
                                                        wNumber.transform.position.z);
                    GenerateScrew(num, fixedPosition);
                    spawnScrewPosition = fixedPosition;
                }
            }
        }
    }

    private void ScrewMovement()
    {
        if (Screw != null)
        {
            Screw.transform.position += new Vector3(screwSpeed * Time.deltaTime * -1, 0, 0);
            Screw.transform.Rotate(Vector3.forward * (screwSpeed + 20) * Time.deltaTime);
            if (Screw.transform.position.x <= xEndPosition)
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
}
