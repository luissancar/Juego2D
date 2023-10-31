using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpController : MonoBehaviour
{
    public int cantidad;
    private bool entrado;
    public int disparosAdicionales;
    public AudioSource sonido;
    // Start is called before the first frame update
    void Start()
    {
        entrado = false;
        sonido = GetComponent<AudioSource>();
        disparosAdicionales = 2;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && !entrado)
        {
            entrado=true;
            sonido.Play();
            collision.gameObject.GetComponent<PlayerController>().PowerUpsMenos();
            collision.gameObject.GetComponent<PlayerController>().IncrepentarPuntos(3);
            collision.gameObject.GetComponent<PlayerController>().disparos += disparosAdicionales;
            GetComponent<TextoPosicion>().activo = true;
            Destroy(gameObject, 1);
        }
    }
}
