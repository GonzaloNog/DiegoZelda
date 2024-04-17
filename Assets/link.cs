using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class link : MonoBehaviour
{
    public float moveSpeed = 5f;
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = 0f; // Desactivar la gravedad
    }
    // Update is called once per frame
    void Update()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movimiento = new Vector3(moveHorizontal, moveVertical,0f) *moveSpeed *Time.deltaTime;;

        transform.Translate(movimiento);
    }
}
