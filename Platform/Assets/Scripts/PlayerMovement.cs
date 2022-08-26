using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
            this.GetComponent<Rigidbody2D>().AddForce(jumpHeight, ForceMode2D.Impulse);// add vertical force
            this.GetComponent<AudioSource>().Play();
            this.GetComponent<AudioSource>().pitch = Random.Range(0.8f, 1.3f);
            NumberOfJumpsLeft -= 1;
        }

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("deathmarker"))
        {
            SceneManager.LoadScene("GameOver");
        }
        if (other.gameObject.CompareTag("ground"))
        {
            NumberOfJumpsLeft = MaxNumberOfJumps;
        }
    }
}
