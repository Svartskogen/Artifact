/* 
    ------------------- Code Monkey -------------------
    
    Thank you for downloading the Code Monkey Utilities
    I hope you find them useful in your projects
    If you have any questions use the contact form
    Cheers!

               unitycodemonkey.com
    --------------------------------------------------
 */
 
using UnityEngine;
using UnityEngine.Events;

namespace CodeMonkey.MonoBehaviours {

    /*
     * Automatically sort a Renderer (SpriteRenderer, MeshRenderer) based on his Y position
     * */
    public class PositionRendererSorter : MonoBehaviour {

        [SerializeField] private int sortingOrderBase = 5000; // This number should be higher than what any of your sprites will be on the position.y
        [SerializeField] private float offset = 0f;
        [SerializeField] private bool runOnlyOnce = false;

        //public UnityEvent<int> OnSortingOrderChanged;

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

}