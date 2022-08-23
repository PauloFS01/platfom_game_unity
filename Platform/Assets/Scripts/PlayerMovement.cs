using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // movement variable
    public float speed;
    public Vector3 jumpHeight;
    public int NumberOfJumpsLeft;
    public int MaxNumberOfJumps;

    // Start is called before the first frame update
    void Start()
    {
        NumberOfJumpsLeft = MaxNumberOfJumps;
    }

    // Update is called once per frame
    void Update()
    {
        //Movement Right
        if (Input.GetAxis("Horizontal") > 0)
        {
            transform.position += new Vector3(Input.GetAxis("Horizontal") * speed * Time.deltaTime, 0, 0); // ps: deltaTime converts everything into persecond
            this.GetComponent<SpriteRenderer>().flipX = false; // Invert render position in X axis.
            GetComponent<Animator>().SetBool("isRuning", true);
        }
        //Movement Left
        if (Input.GetAxis("Horizontal") < 0)
        {
            transform.position += new Vector3(Input.GetAxis("Horizontal") * speed * Time.deltaTime, 0, 0); // ps: deltaTime converts everything into persecond
            this.GetComponent<SpriteRenderer>().flipX = true; // Invert render position in X axis.
            GetComponent<Animator>().SetBool("isRuning", true);
        }
        if (Input.GetAxis("Horizontal") == 0)
        {
            GetComponent<Animator>().SetBool("isRuning", false);
        }
            //Jumping
            if (Input.GetButtonDown("Jump") && NumberOfJumpsLeft > 0)
        {
            this.GetComponent<Rigidbody2D>().velocity = Vector3.zero;
            this.GetComponent<Rigidbody2D>().AddForce(new Vector3(0, 6, 0), ForceMode2D.Impulse);// add vertical force
            NumberOfJumpsLeft -= 1;
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("ground"))
        {
            NumberOfJumpsLeft = MaxNumberOfJumps;
        }
    }
}
