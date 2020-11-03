using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


/// <summary>
/// Waits for the sorting layer of the parent to be assigned, asigns the same value to the object's <see cref="SpriteRenderer"/>
/// and the adds <see cref="add"/> to it 
/// <para>
/// Use it with a <see cref="PositionRendererSorter"/> in the parent object,
/// optionally can be set <see cref="oneTime"/> to true to update the sorting layer every frame.
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
