using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Tilemaps;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public int velocidad;
    private Rigidbody2D fisica;
    float entradaX = 0f;
    public int fuerzaSalto;
    private SpriteRenderer sprite;
    public Animator animator;
    public int puntos;
    public int vidas;
    public bool vulnerable;
    public bool muerto;

    public AudioSource sonido;
    public bool dispara;
    public Transform puntoDisparo;
    public Transform playerTransform;

    public int disparos;
    public Canvas canvas;
    private ControlHub hud;


    public int tiempoNivel;
    public float tiempoInicio;
    public float tiempoEmpleado;

    public int powersUps;

    private ControlDatosJuego datosJuego;




    // Start is called before the first frame update
    void Start()
    {
        velocidad = 10;
        fuerzaSalto = 10;
        fisica = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        puntos = 0;
        sonido = GetComponent<AudioSource>();
        vidas = 3;
        vulnerable = true;
        muerto = false;
        dispara = false;
        playerTransform=GetComponent<Transform>();
        disparos = 5;
        hud = canvas.GetComponent<ControlHub>();
        hud.SetVidasTxt(vidas);
        hud.SetPuntosTxt(puntos);

        tiempoNivel = 50;
        tiempoInicio = Time.time;

        powersUps = 1;

        datosJuego=GameObject.Find("DatosJuego").GetComponent<ControlDatosJuego>();
    }

    // Update is called once per frame
    void Update()
    {
        entradaX = Input.GetAxis("Horizontal");
        Salto();
        Flip();
        AnimarJugador();
        TiempoEmpleado();
    }

    public void PowerUpsMenos()
    {
        powersUps--;
        if ( powersUps < 1 )
        {
            Ganado();
        }
    }
    private void TiempoEmpleado()
    {
        tiempoEmpleado = Time.time - tiempoInicio;
        hud.SetTiempoTxt((int)(tiempoNivel - tiempoEmpleado));
        if (tiempoNivel - tiempoEmpleado < 0)
        {
            Perder();
        }
    }

    public void Ganado()
    {
        puntos = (vidas * 100) + ((int)tiempoNivel - (int)tiempoEmpleado);
        datosJuego.Ganado = true;
        datosJuego.Puntuacion = puntos;
        Debug.Log(puntos.ToString());
        SceneManager.LoadScene("Ganado");
    }

    public void IncrepentarPuntos(int cantidad)
    {
        puntos += cantidad;
        hud.SetPuntosTxt(puntos);
    }
    private void Flip()
    {
        if (fisica.velocity.x > 0f)
        {
            Quaternion nuevaRotacion = Quaternion.Euler(0, 0, 0);
            puntoDisparo.rotation = nuevaRotacion;
            puntoDisparo.transform.position = new Vector3(
                playerTransform.position.x + 1, playerTransform.position.y, 0);

            sprite.flipX = false;
        }
        else if (fisica.velocity.x < 0f)
        {
            Quaternion nuevaRotacion = Quaternion.Euler(0, 180, 0);
            puntoDisparo.rotation = nuevaRotacion;
            puntoDisparo.transform.position = new Vector3(
                playerTransform.position.x - 1, playerTransform.position.y, 0);

            sprite.flipX = true;
        }
    }
    private void Salto()
    {
        if (muerto)
        {
            return;
        }
        if (Input.GetKeyDown(KeyCode.Space) && TocandoSuelo())
        {
            fisica.AddForce(Vector2.up * fuerzaSalto, ForceMode2D.Impulse);
            sonido.Play();
        }
    }
    private void AnimarJugador()
    {
        if (muerto)
        {
            animator.Play("Idle");
            return;
        }
        if (!TocandoSuelo())
            animator.Play("Jump");
        else
            if ((fisica.velocity.x > 1 || fisica.velocity.x < -1) && fisica.velocity.y == 0)
            animator.Play("Run");
        else
                if ((fisica.velocity.x < 1 || fisica.velocity.x > -1) && fisica.velocity.y == 0)
            if (dispara)
                animator.Play("AnimationShot");
            else
                animator.Play("Idle");

    }

    private void FixedUpdate()
    {
        if (muerto)
            return;
        fisica.velocity = new Vector2(entradaX * velocidad, fisica.velocity.y);
    }

    public bool TocandoSuelo()
    {
        RaycastHit2D toca = Physics2D.Raycast(
            transform.position + new Vector3(0, -2f, 0), Vector2.down, 0.2f);
        return toca.collider != null;
    }

    public void Perder()
    {
        datosJuego.Ganado = false;
        SceneManager.LoadScene("Menu");
    }
}
