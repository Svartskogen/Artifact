using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponLookAtMouse : MonoBehaviour
{
    Vector3 mousePos;
    private SpriteRenderer sprite;
    // Start is called before the first frame update
    void Start()
    {
        sprite = GetComponentInChildren<SpriteRenderer>();
    }

    // Update is called once per frame
    private void Update()
    {
        var dir = Input.mousePosition - Camera.main.WorldToScreenPoint(transform.position);
        var angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg - 90;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

        if(transform.rotation.eulerAngles.z > 0 && transform.rotation.eulerAngles.z < 180)
        {
            sprite.flipY = true;
        }
        else
        {
            sprite.flipY = false;
        }
    }
}
