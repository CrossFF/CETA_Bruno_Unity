using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrunoLVL1 : Bruno
{
    private Vector3 fixedTarget;
    private Animator animator;
    private Transform sprite;
    private bool lookingRight = true;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        sprite = transform.GetChild(0);
    }

    private void Update()
    {
        if (PrepareMovement)
        {
            animator.SetTrigger("Prepare");
            StopPrepareMovement();
        }
        if (Move)
        {
            fixedTarget = new Vector3(TargetNumber.transform.position.x,
                                      transform.position.y,
                                      transform.position.z);
            if (animator.GetFloat("Speed") != 1f)
            {
                animator.SetFloat("Speed", 1);
                CalculateSpeed(fixedTarget);
            }
            // direccion del personaje
            if (fixedTarget.x < transform.position.x && lookingRight)
            {
                RotateSprite();
            }
            else if (fixedTarget.x > transform.position.x && !lookingRight)
            {
                RotateSprite();
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

    private void RotateSprite()
    {
        lookingRight = !lookingRight;
        sprite.transform.localScale = new Vector3(sprite.localScale.x * -1, 1, 1);
    }
}
