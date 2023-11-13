using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bruno : MonoBehaviour
{
    public LevelManager levelManager;
    public WorldNumber targetNumber;
    public float stopDistance = 0.05f; // rango en el que el personaje deja de moverse al objetivo
    public bool move = false;
    public float speed = 5f;
    public int lastNumberPos;

    public void SetTarget(WorldNumber target)
    {
        targetNumber = target;
        move = true;
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
