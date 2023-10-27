using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ControlHub : MonoBehaviour
{
    public TextMeshProUGUI vidasTxt;
    public TextMeshProUGUI puntosTxt;

    public void SetVidasTxt(int vidas)
    {
        vidasTxt.text = "Vidas: " + vidas;
    }

    public void SetPuntosTxt(int puntos)
    {
        puntosTxt.text ="Puntos: " + puntos;

    }

}
