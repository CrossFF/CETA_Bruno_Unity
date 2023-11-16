using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEditor.PackageManager;

public class LevelManager : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private SoundManager soundManager;
    [SerializeField] private GameObject prefabScrew;
    [SerializeField] private Bruno bruno;
    [SerializeField] private List<WorldNumber> numberPosition;

    [Header("GUI")]
    [SerializeField] private TMP_Text totalPointText;

    [Header("Level Information")]
    [SerializeField] private int level;

    private int screwNumberPosition;
    private GameObject screw;
    private int localPoints; // puntos conseguidos en el nivel
    private int totalPoints; // puntos totales del jugador

    public GameObject Screw { get { return screw; } }
    public int LocalPoints { get { return localPoints; } }

    private void Awake()
    {
        // cargo informacion guardada
        PlayerStats playerStats = LoadSaveManager.LoadGame();
        totalPoints = playerStats.score;
        totalPointText.text = totalPoints.ToString();
    }

    #region Instantiate Screw
    public WorldNumber GetNumberPosition(int number)
    {
        // verifico que el numero existe en la lista
        // devuelvo el numero
        WorldNumber wPosition = null;
        foreach (var item in numberPosition)
        {
            if (number == item.numberValue)
            {
                wPosition = item;
            }
        }
        return wPosition;
    }

    public void GenerateScrew(int number, Vector3 position)
    {
        screwNumberPosition = number;
        screw = Instantiate(prefabScrew, position, Quaternion.identity);
    }
    #endregion

    #region Bruno Movement
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
    #endregion

    /// <summary>
    /// Perform the end of the level
    /// </summary>
    /// <param name="win"> The player win? true=yes false=no</param>
    public void EndLevel(bool win)
    {
        // guardo la info del jugador
        // si el jugador gano
        //// muestro escena de siguiente nivel
        // sino 
        //// muestro escena de repetir el nivel
        PlayerStats playerStats = new PlayerStats(totalPoints + localPoints, level);
        LoadSaveManager.SaveGame(playerStats);
        SceneControl sceneControl = new();
        if (win)
            sceneControl.ChangeScene("NextLevel");
        else
            sceneControl.ChangeScene("RepeatLevel");
    }
}
