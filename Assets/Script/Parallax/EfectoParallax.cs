using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EfectoParallax : MonoBehaviour
{

    public float efectoParalax;
    private Transform camara;
    private Vector3 ultimaPosicionCamara;
    // Start is called before the first frame update
    void Start()
    {
        camara = Camera.main.transform;
        ultimaPosicionCamara = camara.position;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 movimientoFondo = camara.position - ultimaPosicionCamara;
        transform.position += new Vector3(movimientoFondo.x * efectoParalax,
            movimientoFondo.y, 0);
        ultimaPosicionCamara = camara.position;
    }
}
