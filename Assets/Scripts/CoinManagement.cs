using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinManagement : MonoBehaviour
{
    public Text coinText;
    public int score = 0;
    private Text scoreText;

    private void Start()
    {
        GameObject canvas = GameObject.Find("Canvas"); // Replace "Canvas" with the name of your Canvas GameObject
        if (canvas != null)
        {
            coinText = canvas.transform.Find("Coin Text").GetComponent<Text>(); // Replace "Coin Text" with the name of your coin text UI GameObject
            if (coinText == null)
            {
                Debug.LogError("CoinText object or Text component not found!");
            }
        }
        else
        {
            Debug.LogError("Canvas object not found!");
        }

        // Load the score from PlayerPrefs
        score = PlayerPrefs.GetInt("CoinScore", 0);
        coinText.text = score.ToString() + " Coins";
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            // Increase the score by one
            score+=1;
            scoreText.text = score.ToString()+ " Coins";
            // Save the score to PlayerPrefs
            PlayerPrefs.SetInt("CoinScore", score);
            PlayerPrefs.Save();
        }
    }
}
