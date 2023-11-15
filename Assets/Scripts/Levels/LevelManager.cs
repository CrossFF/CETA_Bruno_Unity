using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private SoundManager soundManager;
    [SerializeField] private GameObject prefabScrew;
    [SerializeField] private Bruno bruno;
    [SerializeField] private List<WorldNumber> numberPosition;

    private int screwNumberPosition;
    private GameObject screw;
    private int localPoints; // puntos conseguidos en el nivel
    private int totalPoints; // puntos totales del jugador

    public GameObject Screw { get { return screw; } }
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

    public void PrepareBrunoToMove()
    {
        bruno.PrepareToMove();
        soundManager.PlayNeutralBruno();
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
        //// sonido de "buen trabajo"
        //// Destruccion de Tornillo para crear nuevo segun nivel
        /// sino
        //// sonido de error de bruno
        //// ayuda para el jugador
        if (numberPositionBruno == screwNumberPosition)
        {
            bruno.Interact();
            screw.GetComponent<Screw>().Interact(bruno.transform.position);
            soundManager.PlayPositiveClip();
            localPoints++;
        }
        else
        {
            soundManager.PlayNegativeBruno();
        }
    }

    public void EndLevel()
    {
        Debug.Log("Fin del Nivel");
    }
}
