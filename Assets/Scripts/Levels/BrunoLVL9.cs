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
    [SerializeField] private Animator tubeAnimator;

    private List<BrunoFriend> brunos;
    private Vector3 spawnPos;
    private Vector3 fixedTarget;
    private bool speedCalculated = false;
    private bool moveToSpawn = false;

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
            tubeAnimator.SetTrigger("Prepare");
            StartCoroutine(SetBrunoSprites());
        }
        if (Move)
        {
            tubeAnimator.SetBool("Move", true);
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
            tubeAnimator.SetBool("Move", false);
            brunos[0].Interact();
            StopInteract();
        }
        if (moveToSpawn)
        {
            transform.position = Vector3.MoveTowards(transform.position, spawnPos, 5 * Time.deltaTime);
            if (Vector3.Distance(transform.position, spawnPos) <= StopDistance)
            {
                // detengo el movimiento
                // informo al manager que estoy en la posicion deseada
                moveToSpawn = false;
            }
        }
    }

    private IEnumerator SetBrunoSprites()
    {
        // Muevo a bruno a su pocision inicial
        // Tiempo de Espera
        // Consigo la lista de tokens que hay en juego
        // si existen instancias
        //// elimino a las instancias actuales
        // creo nuevas instancias segun la lista
        // posiciono las instacias
        StopPrepareMovement();
        moveToSpawn = true;
        yield return new WaitForSeconds(0.5f);
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
