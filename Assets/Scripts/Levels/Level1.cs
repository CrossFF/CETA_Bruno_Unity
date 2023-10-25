using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level1 : MonoBehaviour
{
    [SerializeField] private NumberHolder numberHolder;
    [SerializeField] private List<Transform> numberPosition;
    [SerializeField] private GameObject prefabScrew;

    private void Update()
    {
        // Test Imput
        if (Input.GetKeyDown(KeyCode.Space)) GenerateScrew();
    }

    private void GenerateScrew()
    {
        // random
        int num = Random.Range(0, numberPosition.Count);
        Vector3 pos = new Vector3(numberPosition[num].position.x, 1f, 0f);
        Instantiate(prefabScrew, pos, Quaternion.identity);
    }
}
