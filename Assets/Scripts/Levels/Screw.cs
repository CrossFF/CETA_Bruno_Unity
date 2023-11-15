using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Screw : MonoBehaviour
{
    private Animator animator;
    private Vector3 target;
    private float speed = 2f;
    private bool move = false;
    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (move)
        {
            transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);
            if (Vector3.Distance(transform.position, target) <= 0.05)
            {
                Destroy(gameObject);
            }
        }
    }

    public void Interact(Vector3 brunoPosition)
    {
        target = brunoPosition;
        move = true;
        animator.SetTrigger("Interact");
    }
}
