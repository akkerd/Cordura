using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class SannaController : MonoBehaviour {

    //PLAYER
    bool canJump;
    public AudioClip groundSound;
    public float velocidadHorizontal;


    //UI
    public Text countText;
    public Text winText;
    public int totalCount = 10;

    public bool levelComplete = false;
    public bool onDoor = false;
    private int count;
    private bool combo = false;
    private AudioSource elaudio;

    private void Awake()
    {
        elaudio = GetComponent<AudioSource>();
    }

    // Use this for initialization
    void Start()
    {
        count = 0;
        SetCountText();
        winText.text = "";
    }


    // Update is called once per frame
    void Update()
    {

        // se mueve el personaje aplicando fuerza

        if (Input.GetKey("left"))
        {
            //gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(-1000f * Time.deltaTime, 0));
            gameObject.transform.Translate(-velocidadHorizontal * Time.deltaTime, 0, 0);
            gameObject.GetComponent<Animator>().SetBool("moving", true);
            gameObject.GetComponent<SpriteRenderer>().flipX = true;
        }


        if (!Input.GetKey("left") && !Input.GetKey("right"))
        {
            gameObject.GetComponent<Animator>().SetBool("moving", false);
        }


        if (Input.GetKey("right"))
        {
            //gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(1000f * Time.deltaTime, 0));
            gameObject.transform.Translate(velocidadHorizontal * Time.deltaTime, 0, 0);
            gameObject.GetComponent<Animator>().SetBool("moving", true);
            gameObject.GetComponent<SpriteRenderer>().flipX = false;
        }

        if (Input.GetKeyDown("up") && canJump)
        {
            canJump = false;
            gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, 25000f * Time.deltaTime));
            gameObject.GetComponent<Animator>().SetBool("jump", true);
            elaudio.PlayOneShot(groundSound);

        }

        if (Input.GetKeyDown("down"))
        {
            gameObject.GetComponent<Animator>().SetTrigger("crouch");
        }

        if (Input.GetButton("Jump") && canJump)
        {
            canJump = false;
            gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, 25000f * Time.deltaTime));
            gameObject.GetComponent<Animator>().SetBool("jump", true);
            elaudio.PlayOneShot(groundSound);
        }


        if (Input.GetButtonDown("Fire1"))
        {
            gameObject.GetComponent<Animator>().SetTrigger("attack");
            openDoor();
        }

        if (Input.GetButtonDown("Fire2"))
        {
            gameObject.GetComponent<Animator>().SetTrigger("attack-2");
        }



    } // END UPDATE


    // COGER ITEMS
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("item"))
        {
            other.gameObject.SetActive(false);
            //gameObject.GetComponent<Animator>().SetTrigger("crouch");
            count = count + 1;
            SetCountText();
        }

        if (other.gameObject.CompareTag("doorlvl3"))
        {
            onDoor = true;
        }

    }

    // GESTOR CONTADOR CORDURA
    void SetCountText()
    {
        countText.text = count.ToString();
        if (count >= totalCount)
        {
            levelComplete = true;
            //Initiate.Fade("IntroScene", Color.black, 1f);
        }
    }


    // DETECTOR DE SUELO
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "ground")
        {
            canJump = true;
            gameObject.GetComponent<Animator>().SetBool("jump", false);
        }
    }

    ///////////////////////////////////////////////////////////////////



    void openDoor()
    {
        if ((levelComplete == true) && (onDoor == true))
        {
            Initiate.Fade("BossScene", Color.black, 1f);
        }
    }
} 