using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    private BoxCollider2D col;
    // Start is called before the first frame update
    void Start()
    {
        col = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        bool ig = IsGrounded();
    }

    bool IsGrounded()
    {
        float yOffset = .1f;
        RaycastHit2D raycastHit = Physics2D.Raycast(col.bounds.center, Vector2.down, col.bounds.extents.y + yOffset);
        Color rayColor;
        if (raycastHit.collider != null)
        {
            rayColor = Color.green;
        }
        else
            rayColor = Color.red;
        Debug.DrawRay(col.bounds.center, Vector2.down * (col.bounds.extents.y + yOffset),rayColor);
        return raycastHit.collider != null;
    }

}
