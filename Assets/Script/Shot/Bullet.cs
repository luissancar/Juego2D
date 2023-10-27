using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    public float speed = 20f;
    public Rigidbody2D rb;
    public AudioSource audioSource;
    public AudioClip clipMuerto;
    private Renderer rend;


    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void Start()
    {
        rend = GetComponent<Renderer>();
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = transform.right * speed;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemigo"))
        {
            Debug.Log("Muerto");
           // audioSource.PlayOneShot(clipMuerto);
           audioSource.Play();
            collision.GetComponent<EnemigoController>().EnemigoMuerto();
            rend.enabled = false;  // para que suene y después se elimine el gameobjet
            Destroy(gameObject,4);
        }
    }
}
