using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class link : MonoBehaviour
{
    public float moveSpeed = 5f;
    private Rigidbody2D rb;
    private Animator anim;
    private AudioSource audioSource;
    private bool moveWater = false;
    private bool inWater = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = 0f; // Desactivar la gravedad
        anim = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
    }
    // Update is called once per frame
    void Update()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movimiento = new Vector3(moveHorizontal, moveVertical,0f) *moveSpeed *Time.deltaTime;;

        transform.Translate(movimiento);
        anim.SetFloat("vertical", moveVertical);
        anim.SetFloat("horizontal", moveHorizontal);
        if(moveVertical != 0 || moveHorizontal != 0)
        {
            if (inWater && !audioSource.isPlaying)
            {
                moveWater = true;
                audioSource.Play();
            }
        }
        else
        {
            if (inWater)
            {
                moveWater = false;
                audioSource.Pause();
            }
            else
            {
                moveWater = false;
                audioSource.Stop();
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.name == "Trampa")
        {
            inWater = true;
            Debug.Log("EntroCharco");
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Trampa")
        {
            inWater = false;
            Debug.Log("SalioCharco");
            audioSource.Stop();
        }
    }
}
