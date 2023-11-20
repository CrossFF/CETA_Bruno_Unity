using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Island3 : LevelManager
{

    private void Update()
    {
        ScrewControl();
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
                int num = Numbers[0] == 0 ? UnityEngine.Random.Range(1, 11) : Numbers[0];
                WorldNumber wNumber = GetNumberPosition(num);
                if (wNumber != null)
                {
                    Vector3 fixedPosition = new Vector3(wNumber.transform.position.x - 2f,
                                                        wNumber.transform.position.y,
                                                        wNumber.transform.position.z);
                    GenerateScrew(num, fixedPosition);
                }
            }
        }
    }
}
