using System.Collections;
using System.Collections.Generic;
using TreeEditor;
using UnityEngine;
using UnityEngine.UI;

public class BrunoLVL9 : Bruno
{
    [Header("References")]
    [SerializeField] private RectTransform spawnTubePoint;
    [SerializeField] private List<GameObject> prefabsBrunoFriend;

    private List<BrunoFriend> brunos;
    private Vector3 spawnPos;
    private Vector3 fixedTarget;
    private bool speedCalculated = false;

    private void Start()
    {
        brunos = new List<BrunoFriend>();
        // posicion de Spawn
        Vector3 pos = Camera.main.ScreenToWorldPoint(spawnTubePoint.position);
        spawnPos = new Vector3(pos.x, pos.y, 0);
        transform.position = spawnPos;
    }

    private void Update()
    {
        if (PrepareMovement)
        {
            SetBrunoSprites();
            StopPrepareMovement();
        }
        if (Move)
        {
            fixedTarget = new Vector3(transform.position.x,
                                      TargetNumber.transform.position.y,
                                      transform.position.z);
            // movimiento
            if (!speedCalculated)
            {
                CalculateSpeed(fixedTarget);
                speedCalculated = true;
            }
            transform.position = Vector3.MoveTowards(transform.position, fixedTarget, Speed * Time.deltaTime);
            if (Vector3.Distance(transform.position, fixedTarget) <= StopDistance)
            {
                // detengo el movimiento
                // informo al manager que estoy en la posicion deseada
                StopMovement();
                LevelManager.BrunoInPosition(lastNumberPos);
            }
        }
        if (Interacting)
        {
            brunos[0].Interact();
            StopInteract();
        }
    }

    private void SetBrunoSprites()
    {
        // muevo a bruno a su pocision inicial
        // Consigo la lista de tokens que hay en juego
        // si existen instancias
        //// elimino a las instancias actuales
        // creo nuevas instancias segun la lista
        // posiciono las instacias
        transform.position = spawnPos;
        speedCalculated = false;
        List<int> numbers = GameObject.FindObjectOfType<NumberHolder>().GetTokensInPlay();
        if (brunos.Count > 0)
        {
            foreach (var item in brunos.ToArray())
            {
                Destroy(item.gameObject);
            }
            brunos.Clear();
        }
        foreach (var item in numbers)
        {
            GameObject temp = Instantiate(prefabsBrunoFriend[item - 1], transform);
            brunos.Add(temp.GetComponent<BrunoFriend>());
        }
        for (int i = 0; i < brunos.Count; i++)
        {
            if (i == 0)
            {
                brunos[i].transform.localPosition = Vector3.zero;
            }
            else
            {
                brunos[i].transform.position = brunos[i - 1].BottomPoint;
            }
        }
    }
}
