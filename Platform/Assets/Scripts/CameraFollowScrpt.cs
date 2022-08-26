using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowScrpt : MonoBehaviour
{
    [SerializeField] private GameObject TargetPlayer;
    [SerializeField] private float yMinimum;
    [SerializeField] private float yMaximum;

    // Update is called once per frame
    void Update()
    {
        // Move Y camera
        if (TargetPlayer.transform.position.y > yMinimum && TargetPlayer.transform.position.y < yMaximum)
        {
            this.transform.position = new Vector3(TargetPlayer.transform.position.x, TargetPlayer.transform.position.y, this.transform.position.z);
        }

        // Move only x camera
        else
        {
            this.transform.position = new Vector3(TargetPlayer.transform.position.x, this.transform.position.y, this.transform.position.z);
        }
    }
}
