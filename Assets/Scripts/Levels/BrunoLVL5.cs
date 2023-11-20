using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrunoLVL5 : Bruno
{
    private Vector3 fixedTarget;
    private Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (PrepareMovement)
        {
            animator.SetTrigger("Prepare");
            StopPrepareMovement();
        }
        if (Move)
        {
            fixedTarget = new Vector3(transform.position.x,
                                      TargetNumber.transform.position.y,
                                      transform.position.z);
            if (animator.GetFloat("Speed") != 1f)
            {
                animator.SetFloat("Speed", 1);
                CalculateSpeed(fixedTarget);
            }
            // movimiento
            transform.position = Vector3.MoveTowards(transform.position, fixedTarget, Speed * Time.deltaTime);
            if (Vector3.Distance(transform.position, fixedTarget) <= StopDistance)
            {
                // detengo el movimiento
                // informo al manager que estoy en la posicion deseada
                StopMovement();
                animator.SetFloat("Speed", 0);
                LevelManager.BrunoInPosition(lastNumberPos);
            }
        }
        if (Interacting)
        {
            animator.SetTrigger("Interact");
            StopInteract();
        }
    }
}
