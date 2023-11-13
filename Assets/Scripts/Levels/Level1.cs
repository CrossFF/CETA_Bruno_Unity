using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level1 : LevelManager
{
    [SerializeField] private List<int> numbers;

    private void Update()
    {
        if (LocalPoints == 11)
        {
            EndLevel();
        }
        if (screw == null)
        {
            if (numbers.Count != 0)
            {
                GenerateScrew(numbers[0]);
                numbers.Remove(numbers[0]);
            }
        }
    }
}
