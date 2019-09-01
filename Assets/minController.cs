using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class minController : MonoBehaviour {

    //PLAYER
    bool canJump;
    public AudioClip groundSound;
    public float velocidadHorizontal;

    private AudioSource elaudio;

    private void Awake()
    {
        elaudio = GetComponent<AudioSource>();
    }

    // Use this for initialization
    void Start()
    {

    }


    // Update is called once per frame
    void Update()
    {

        if (Input.GetKey("left"))
        {

            gameObject.transform.Translate(-velocidadHorizontal * Time.deltaTime, 0, 0);
            gameObject.GetComponent<Animator>().SetBool("moving", true);
            gameObject.GetComponent<SpriteRenderer>().flipX = false;
        }


        if (!Input.GetKey("left") && !Input.GetKey("right"))
        {
            gameObject.GetComponent<Animator>().SetBool("moving", false);
        }


        if (Input.GetKey("right"))
        {

            gameObject.transform.Translate(velocidadHorizontal * Time.deltaTime, 0, 0);
            gameObject.GetComponent<Animator>().SetBool("moving", true);
            gameObject.GetComponent<SpriteRenderer>().flipX = true;
        }


    } // END UPDATE


} 