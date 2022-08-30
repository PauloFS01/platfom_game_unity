using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    public float xPositionLeft;
    public float xPositionRight;
    public int GoToPosition;
    public float Speed;

    void Start()
    {
        xPositionLeft = this.transform.position.x;
        GoToPosition = 1;
    }

    // Update is called once per frame
    void Update()
    {
        // Set GoToPosition for left
        if(this.transform.position.x >= xPositionRight)
        {
            GoToPosition = 1;
        }
        // Set GoToPosition for right
        if(this.transform.position.x <= xPositionLeft)
        {
            GoToPosition = 2;
        }
        // Set Left Movement
        if(GoToPosition == 1)
        {
            this.transform.position -= new Vector3(Speed * Time.deltaTime, 0, 0);
            this.GetComponent<SpriteRenderer>().flipX = true;
        }
        // Set Right Movement
        if (GoToPosition == 2)
        {
            this.transform.position += new Vector3(Speed * Time.deltaTime, 0, 0);
            this.GetComponent<SpriteRenderer>().flipX = true;
        }

    }
}
