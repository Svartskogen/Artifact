using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
//using CodeMonkey.MonoBehaviours;
//using CodeMonkey.Utils;

/// <summary>
/// Invoca la actualizacion de la sorting layer heredada del padre y le suma order;
/// <para>
/// Usar con un PositionRenderSorter en el padre
/// </para>
/// </summary>
public class ChildSortingInvoker : MonoBehaviour
{
    public bool oneTime;
    public Renderer spriteRenderer;
    public int add;

    SpriteRenderer parent;
    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        if (oneTime)
        {
            StartCoroutine(setOrderingLayer(0.1f));
        }
        else
        {
            parent = transform.parent.GetComponent<SpriteRenderer>();
        }
        
    }

    private void Update()
    {
        if (!oneTime)
        {
            int order = parent.sortingOrder;
            spriteRenderer.sortingOrder = order + add;
        }
    }

    int GetParentSortingLayer() {
        return transform.parent.GetComponent<SpriteRenderer>().sortingOrder;
    }
    IEnumerator setOrderingLayer(float timer)
    {
        yield return new WaitForSeconds(timer);
        int order = GetParentSortingLayer();
        spriteRenderer.sortingOrder = order + add;
    }
}
