using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinScore : MonoBehaviour
{
    private int score = 0;
    private GameObject player;
   void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }


    // Called when the player collides with the coin
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Border")
        {
            Destroy(this.gameObject);
        }
    }
}
