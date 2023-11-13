using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public List<WorldNumber> numberPosition;
    public GameObject prefabScrew;
    [SerializeField] private Bruno bruno;
    public int screwNumberPosition;
    public GameObject screw;
    private int localPoints; // puntos conseguidos en el nivel
    private int totalPoints; // puntos totales del jugador

    public int LocalPoints { get { return localPoints; } }

    public void GenerateScrew()
    {
        // random
        int num = Random.Range(0, numberPosition.Count);
        Vector3 pos = new Vector3(numberPosition[num].transform.position.x, 1f, 0f);
        screwNumberPosition = numberPosition[num].numberValue;
        screw = Instantiate(prefabScrew, pos, Quaternion.identity);
    }

    public void GenerateScrew(int num)
    {
        // en posicion especifica
        // busco el numero en la lista de posciones
        // si ese numero existe
        //// instancio el tornillo en la posicion de ese numero
        // sino
        //// muestro error de numero incorrecto
        WorldNumber position = null;
        foreach (var item in numberPosition)
        {
            if (num == item.numberValue)
            {
                position = item;
            }
        }
        if (position != null)
        {
            Vector3 pos = new Vector3(position.transform.position.x, 1f, 0f);
            screwNumberPosition = position.numberValue;
            screw = Instantiate(prefabScrew, pos, Quaternion.identity);
        }
        else
        {
            Debug.Log("No existe ese numero en este nivel");
        }
    }

    public void MoveBruno(int numPos)
    {
        WorldNumber target = null;
        foreach (var item in numberPosition)
        {
            if (item.numberValue == numPos)
                target = item;
        }
        if (target != null)
        {
            bruno.SetTarget(target);
        }
        else
        {
            Debug.Log("Posicion no Existe");
        }
    }

    public void BrunoInPosition(int numberPositionBruno)
    {
        // si bruno esta en la posicion de un tornillo
        //// activa animacion de conseguir tornillo
        //// suma puntos
        //// Destruccion de Tornillo para crear nuevo segun nivel
        if (numberPositionBruno == screwNumberPosition)
        {
            // animacion de bruno
            // animacion de tornillo
            localPoints++;
            Destroy(screw);
        }
    }

    public void EndLevel()
    {
        Debug.Log("Fin del Nivel");
    }
}
