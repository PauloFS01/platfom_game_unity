using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Movement Right
        if (Input.GetAxis("Horizontal") > 0)
        {
            transform.position += new Vector3(Input.GetAxis("Horizontal") * 5 * Time.deltaTime, 0, 0); // ps: deltaTime converts everything into persecond
            this.GetComponent<SpriteRenderer>().flipX = false; // Invert render position in X axis.
            GetComponent<Animator>().SetBool("isRuning", true);
        }
        //Movement Left
        if (Input.GetAxis("Horizontal") < 0)
        {
            transform.position += new Vector3(Input.GetAxis("Horizontal") * 5 * Time.deltaTime, 0, 0); // ps: deltaTime converts everything into persecond
            this.GetComponent<SpriteRenderer>().flipX = true; // Invert render position in X axis.
            GetComponent<Animator>().SetBool("isRuning", true);
        }
        if (Input.GetAxis("Horizontal") == 0)
        {
            GetComponent<Animator>().SetBool("isRuning", false);
        }
            //Jumping
            if (Input.GetButtonDown("Jump"))
        {
            this.GetComponent<Rigidbody2D>().AddForce(new Vector3(0, 6, 0), ForceMode2D.Impulse);// add vertical force
        }

    }
}
