using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Ganado : MonoBehaviour
{
    public Canvas canvas;
    private Ganado hud;
    private ControlDatosJuego datosJuego;
    public TextMeshProUGUI puntosTxt;


    private void Start()
    {
        hud =canvas.GetComponent<Ganado>();
        //datosJuego
    }
    public void Menu()
    {
        SceneManager.LoadScene("Menu");
    }
}
