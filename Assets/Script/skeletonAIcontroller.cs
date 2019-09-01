using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class skeletonAIcontroller : MonoBehaviour {

    public float speedskelleton;

    void Update () {

        gameObject.transform.Translate(-speedskelleton * Time.deltaTime, 0, 0);

    }


    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("bump"))
        {
            gameObject.GetComponent<SpriteRenderer>().flipX = true;
            gameObject.transform.Translate(speedskelleton * Time.deltaTime, 0, 0);
        }
    }


}
