using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoucyBoxScript : MonoBehaviour
{
    [SerializeField] Vector3 BounceHeight;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            this.GetComponent<AudioSource>().Play();
            this.GetComponent<Animator>().Play("bouncy_box_bounce");
            collision.gameObject.GetComponent<Rigidbody2D>().AddForce(BounceHeight, ForceMode2D.Impulse);
        }
    }
}
