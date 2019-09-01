using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CorduraController : MonoBehaviour {

    public int CorduraCounter;
    public GameObject Jugador;

    private void OnTriggerEnter2D(Collider2D collision)

    {

            Jugador = GameObject.Find("Player");
            Jugador.GetComponent<Animator>().SetTrigger("crouch");
            Destroy(gameObject);

    }


}