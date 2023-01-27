using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RacketLeftBehaviour : MonoBehaviour
{
    public float speed = 30;
    public string axis = "Vertical";
    private Rigidbody2D rb = null;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    void FixedUpdate()
    {
        float v = Input.GetAxisRaw(axis);
       rb.velocity = new Vector2(0, v) * speed;
    }
}
