using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bruno : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private LevelManager levelManager;
    [SerializeField] private float stopDistance = 0.01f; // rango en el que el personaje deja de moverse al objetivo
    
    private WorldNumber targetNumber;
    private bool prepareToMove = false;
    private bool move = false;
    private float timeMove = 0.8f;
    private float speed;
    public int lastNumberPos;
    private bool intercat = false;

    public LevelManager LevelManager { get { return levelManager; } }
    public WorldNumber TargetNumber { get { return targetNumber; } }
    public float StopDistance { get { return stopDistance; } }
    public bool PrepareMovement { get { return prepareToMove; } }
    public bool Move { get { return move; } }
    public float Speed { get { return speed; } }
    public bool Interacting { get { return intercat; } }

    #region Movement
    public void PrepareToMove()
    {
        prepareToMove = true;
    }
    public void StopPrepareMovement()
    {
        prepareToMove = false;
    }

    public void SetTarget(WorldNumber target)
    {
        targetNumber = target;
        move = true;
    }

    public void CalculateSpeed(Vector3 target)
    {
        speed = Vector3.Distance(transform.position, target) / timeMove;
    }

    public void StopMovement()
    {
        move = false;
    }
    #endregion

    public void Interact()
    {
        intercat = true;
    }
    public void StopInteract()
    {
        intercat = false;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        WorldNumber worldNumber = other.GetComponent<WorldNumber>();
        if (worldNumber != null)
        {
            lastNumberPos = worldNumber.numberValue;
        }
    }
}
