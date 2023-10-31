using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Ganadoo : MonoBehaviour
{
    public Canvas canvas;
    private Ganadoo hud;
    private ControlDatosJuego datosJuego;
    public TextMeshProUGUI puntosTxt;


    private void Start()
    {
       
        datosJuego = GameObject.Find("DatosJuego").GetComponent<ControlDatosJuego>();
        hud = canvas.GetComponent<Ganadoo>();
        hud.puntosTxt.text=datosJuego.Puntuacion.ToString();
    }
    public void Menu()
    {
        SceneManager.LoadScene("Menu");
    }
}
