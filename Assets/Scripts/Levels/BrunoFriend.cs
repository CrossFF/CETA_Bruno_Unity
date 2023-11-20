using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrunoFriend : MonoBehaviour
{
    [SerializeField] private Transform bottomPoint;
    private Animator animator;

    public Vector3 BottomPoint { get { return bottomPoint.position; } }

    private void Start()
    {
        animator = GetComponent<Animator>();
    }
    
    public void Interact()
    {
        animator.SetTrigger("Interact");
    }
}
