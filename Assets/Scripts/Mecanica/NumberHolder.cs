using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class NumberHolder : MonoBehaviour, IDropHandler
{
    private Transform tParent;
    private NumberBarManager numberBar;
    [SerializeField] private Animator loadingAnim;

    private List<NumberToken> tokens;
    private int totalValue = 0;

    private void Awake()
    {
        tParent = GameObject.Find("Panel_Drag and Drop").transform;
        numberBar = FindObjectOfType<NumberBarManager>();
        tokens = new List<NumberToken>();
    }

    private void Start()
    {
        numberBar.HighlightNumberNoSound(totalValue);
    }

    public void OnDrop(PointerEventData eventData)
    {
        //eventData.pointerDrag, objeto dropeado
        if (eventData.pointerDrag != null)
        {
            NumberToken drop = eventData.pointerDrag.GetComponent<NumberToken>();
            NumberToken temp = Instantiate(drop.gameObject, tParent).GetComponent<NumberToken>();
            temp.IsACopy();
            AddNumberToken(temp);
            if (drop.IsCopy)
            {
                RemoveNumberToken(drop);
                Destroy(drop.gameObject);
            }
        }
        else
        {
            Debug.Log("No item");
        }
    }

    public void AddNumberToken(NumberToken token)
    {
        tokens.Add(token);
        CheckTokensValue();
    }

    public void RemoveNumberToken(NumberToken token)
    {
        tokens.Remove(token);
        CheckTokensValue();
    }

    private void CheckTokensValue()
    {
        StopAllCoroutines();
        StartCoroutine(CalculateTotalValue());
    }

    IEnumerator CalculateTotalValue()
    {
        // animation and sound
        loadingAnim.transform.SetAsLastSibling();
        loadingAnim.SetTrigger("StartLoading");
        // logic
        totalValue = 0;
        if (tokens.Count != 0)
        {
            foreach (var token in tokens)
            {
                totalValue += token.value;
            }
        }

        yield return new WaitForSeconds(0.5f);

        // animation and sound
        loadingAnim.SetTrigger("EndLoading");
        numberBar.HighlightNumber(totalValue);
    }
}
