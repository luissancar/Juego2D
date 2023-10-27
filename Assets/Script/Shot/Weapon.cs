using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{

    public Transform firePoint;
    public GameObject bulletPrefab;
    public PlayerController player;
    public AudioSource audio;
    public AudioClip clipDisparo;
    // Start is called before the first frame update


    private void Awake()
    {
        audio = GetComponent<AudioSource>();
    }
    private void Start()
    {
        player = GetComponent<PlayerController>();
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }

    private void Shoot()
    {
        if (gameObject.GetComponent<PlayerController>().TocandoSuelo())
        {

            if (player.disparos > 0)
            {
                audio.PlayOneShot(clipDisparo);
                player.disparos--;
                player.dispara = true;
                GameObject instanciaPrefab = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
                Invoke("playerNoDispara", .5f);
                Destroy(instanciaPrefab, 1f);
            }
        }
    }


    void playerNoDispara()
    {
        player.dispara = false;
    }
}
