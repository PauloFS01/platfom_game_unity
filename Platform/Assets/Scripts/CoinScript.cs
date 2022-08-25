using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CoinScript : MonoBehaviour
{

    public Object ScriptTarget;

    private void Awake()
    {
        GameObject.Find("ScriptObject").GetComponent<ScriptObjectScript>().CoinsNeededToWin += 1;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            ScriptTarget = GameObject.Find("ScriptObject");
            this.transform.position = new Vector3(0, -30, 0);
            this.GetComponent<AudioSource>().Play();
            ScriptTarget.GetComponent<ScriptObjectScript>().Coins += 1;
            Destroy(this.gameObject, 0.5f);
        }
    }

}
