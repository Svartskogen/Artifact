using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Rotates the object to the mouse position, used with <see cref="PlayerSlash"/> for melee attacks
/// </summary>
public class WeaponLookAtMouse : MonoBehaviour
{
    Vector3 mousePos;
    private SpriteRenderer sprite;

    void Start()
    {
        sprite = GetComponentInChildren<SpriteRenderer>();
    }

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
