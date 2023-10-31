using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextoPosicion : MonoBehaviour
{
    public GameObject objetoDondeMostar;
    public TextMeshProUGUI puntosCanvas;
    public int sumaX, sumaY;
    public bool activo;
    public string textoAMostrar;


    // Start is called before the first frame update
    void Start()
    {
        puntosCanvas.text = "";
        activo = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (activo)
        {
            puntosCanvas.text = textoAMostrar;
            Vector3 posicionObjeto;
            posicionObjeto = Camera.main.WorldToScreenPoint(objetoDondeMostar.transform.position);
            puntosCanvas.transform.position = new Vector3(
                posicionObjeto.x+sumaX,
                posicionObjeto.y+sumaY,
                posicionObjeto.z);
        }
    }
    private void OnDestroy()
    {
        puntosCanvas.text = "";
    }
}
