using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CoinScript : MonoBehaviour
{

    public GameObject ScriptTarget;
    private bool Collected;

    private void Awake()
    {
        GameObject.Find("ScriptObject").GetComponent<ScriptObjectScript>().CoinsNeededToWin += 1;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player") && !Collected)
        {
            Collected = true;
            ScriptTarget = GameObject.Find("ScriptObject");
            this.transform.position = new Vector3(0, -30, 0);
            this.GetComponent<AudioSource>().Play();
            ScriptTarget.GetComponent<ScriptObjectScript>().Coins += 1;
            GameObject.Find("Coin_Text").GetComponent<TextMesh>().text = "X" + ScriptTarget.GetComponent<ScriptObjectScript>().Coins; // concatenate x is equals to convert a variable to string
            Destroy(this.gameObject, 0.5f);
        }
    }

}
