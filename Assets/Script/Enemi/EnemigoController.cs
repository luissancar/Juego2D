using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemigoController : MonoBehaviour
{
    public GameObject enemigo;
    public float velocidad;
    public Vector3 posicionFin;
    public Vector3 posicionInicial;
    private bool moviendoAFin;
    public int finX, finY;
    public AudioSource sonido;
    private bool vulnerable;
    public Canvas canvas;
    private ControlHub hud;


   
    // Start is called before the first frame update
    void Start()
    {
        posicionInicial = transform.position;
        posicionFin = new Vector3(posicionInicial.x + finX, posicionInicial.y + finY, posicionInicial.z);
        moviendoAFin = true;
        sonido = GetComponent<AudioSource>();
        vulnerable = true;
        canvas = FindAnyObjectByType<Canvas>().GetComponent<Canvas>();
        hud = canvas.GetComponent<ControlHub>();


    }

    // Update is called once per frame
    void Update()
    {
        MoverEnemigo();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player") &&
            collision.gameObject.GetComponent<PlayerController>().vulnerable)
        {
            collision.gameObject.GetComponent<PlayerController>().vulnerable = false;
            if (collision.gameObject.GetComponent<PlayerController>().vidas-- <=1 )
            {
                sonido.Play();
                StartCoroutine(FinJuego(collision));
            }
            else
            {
                StartCoroutine(QuitaVida(collision));
              //  Invoke("funcion", 2);
            }

            
        }
        hud.SetVidasTxt(collision.gameObject.GetComponent<PlayerController>().vidas);
    }

    IEnumerator QuitaVida(Collision2D collision)
    {
        collision.gameObject.GetComponent<SpriteRenderer>().color =Color.red;
        yield return new WaitForSeconds(6f);
        collision.gameObject.GetComponent<PlayerController>().vulnerable=true;
        collision.gameObject.GetComponent<SpriteRenderer>().color=Color.white;
    }

    IEnumerator FinJuego(Collision2D collision)
    {
        Camera.main.transform.parent = null;
        collision.gameObject.GetComponent<Transform>().Rotate(new Vector3(0, 0, 90));
        collision.gameObject.GetComponent<PlayerController>().muerto = true;
        collision.gameObject.GetComponent<SpriteRenderer>().color = Color.red;
        yield return new WaitForSeconds(6f);
        collision.gameObject.GetComponent<PlayerController>().Perder();
    }

    private void MoverEnemigo()
    {
        Vector3 posicionDestino = (moviendoAFin) ? posicionFin : posicionInicial;
        transform.position = Vector3.MoveTowards(transform.position,posicionDestino,
            velocidad * Time.deltaTime);
        if (transform.position == posicionFin) 
            moviendoAFin = false;
        if (transform.position == posicionInicial)
            moviendoAFin = true;
    }


    public void EnemigoMuerto()
    {
        Destroy(gameObject);
    }
    
}
