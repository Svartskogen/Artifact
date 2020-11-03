using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// Setea el OrderInLayer del <see cref="SpriteRenderer"/> del objeto acorde a su coordenada Y.
/// </summary>
public class PositionRendererSorter : MonoBehaviour
{
    [SerializeField] private int sortingOrderBase = 5000; // This number should be higher than what any of your sprites will be on the position.y
    [SerializeField] private float offset = 0f;
    [SerializeField] private bool runOnlyOnce = false;


    private float timer;
    private float timerMax = .1f;
    private Renderer myRenderer;
    int sortingOrder;

    private void Awake() {
        myRenderer = gameObject.GetComponent<Renderer>();
    }

    private void LateUpdate() {
        timer -= Time.deltaTime;
        if (timer <= 0f) {
            timer = timerMax;
            sortingOrder = (int)(sortingOrderBase - (transform.position.y - offset) * 50);
            myRenderer.sortingOrder = sortingOrder;
            //OnSortingOrderChanged?.Invoke(sortingOrder);
            if (runOnlyOnce) {
                Destroy(this);
            }
        }
    }

    public void SetOffset(int offset) {
        this.offset = offset;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawLine(transform.position + new Vector3(-1, offset, 0),transform.position + new Vector3(1, offset, 0));
    }
}
