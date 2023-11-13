using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrunoLVL1 : Bruno
{
    private Vector3 fixedTarget;

    private void Update()
    {
        if (move)
        {
            fixedTarget = new Vector3(targetNumber.transform.position.x,
                                      transform.position.y,
                                      transform.position.z);
            transform.position = Vector3.MoveTowards(transform.position, fixedTarget, speed * Time.deltaTime);
            if (Vector3.Distance(transform.position, fixedTarget) <= stopDistance)
            {
                // detengo el movimiento
                // informo al manager que estoy en la posicion deseada
                move = false;
                levelManager.BrunoInPosition(lastNumberPos);
            }
        }
    }
}
