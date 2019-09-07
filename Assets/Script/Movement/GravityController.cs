using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityController : MonoBehaviour
{
    [SerializeField]
    SO_ObjectRef playerRef;
    public float fallMultiplier = 2.5f;
    public float jumpMultiplier = 2.0f;
    private Rigidbody2D rb;
    // Use this for initialization
    void Start()
    {
        rb = playerRef.getGameObject().GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (rb.velocity.y < 0)
        {
            rb.velocity += Vector2.up * Physics2D.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
        }
        else if (rb.velocity.y > 0 && !Input.GetButton("Jump"))
        {
            rb.velocity += Vector2.up * Physics2D.gravity.y * (jumpMultiplier - 1) * Time.deltaTime;
        }
    }
}
