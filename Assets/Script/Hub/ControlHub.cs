using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ControlHub : MonoBehaviour
{
    public TextMeshProUGUI vidasTxt;
    public TextMeshProUGUI puntosTxt;
    public TextMeshProUGUI tiempoTxt;

    public void SetVidasTxt(int vidas)
    {
        vidasTxt.text = "Vidas: " + vidas;
    }

    public void SetPuntosTxt(int puntos)
    {
        puntosTxt.text ="Puntos: " + puntos;

    }

    public void SetTiempoTxt(int tiempo)
    {
        int minutos, segundos;
        minutos = tiempo / 60;
        segundos= tiempo % 60;
        string formatoMinSeg =string.Format("{0:00}:{1:00}",minutos,segundos);
        tiempoTxt.text = "Tiempo: " + formatoMinSeg;
    }












}
