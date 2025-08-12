using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelSuccess : MonoBehaviour
{
    private Text scoreText;
    public GameObject levelSuccessPanel;
    public GameObject levelSuccessPanel1;
    public GameObject levelSuccessPanel2;
    [SerializeField] private AudioSource levelSuccessEffect;
    [SerializeField] private AudioSource gameSoundEffect;
    private GameObject playerObject; // Reference to the player object
    private bool isLevelSuccess = false; // Track if the level is successfully completed
    private bool isGameplayEnabled = true; // Track if gameplay is enabled
    private GameOver gameOverScript;
    
    void Start()
    {
        GameObject gameManager = GameObject.Find("GameManager"); // Replace "GameManager" with the name of your GameManager GameObject
        if (gameManager != null)
        {
            playerObject = gameManager.transform.Find("Player").gameObject; // Replace "Player" with the name of your player GameObject
            if (playerObject == null)
            {
                Debug.LogError("Player object not found!");
            }
        }
        else
        {
            Debug.LogError("GameManager object not found!");
        }

        GameObject canvas = GameObject.Find("Canvas"); // Replace "Canvas" with the name of your Canvas GameObject
        if (canvas != null)
        {
            scoreText = canvas.transform.Find("Score Text").GetComponent<Text>(); // Replace "Score Text" with the name of your score text UI GameObject
            if (scoreText == null)
            {
                Debug.LogError("Score Text object or Text component not found!");
            }
        }
        else
        {
            Debug.LogError("Canvas object not found!");
        }

        gameOverScript = GetComponent<GameOver>();
    }

    void Update()
    {
        if (isGameplayEnabled && !isLevelSuccess && scoreText != null)
        {
            int score = ParseScore(scoreText.text);

            string currentScene = SceneManager.GetActiveScene().name;

            if (currentScene == "Level 1" && score >= 5)
            {
                LevelCompleted();
                if (levelSuccessPanel != null)
                    levelSuccessPanel.SetActive(true);
            }
            else if (currentScene == "Level 2" && score >= 10)
            {
                LevelCompleted();
                if (levelSuccessPanel1 != null)
                    levelSuccessPanel1.SetActive(true);
            }
            else if (currentScene == "Level 3" && score >= 15)
            {
                LevelCompleted();
                if (levelSuccessPanel2 != null)
                    levelSuccessPanel2.SetActive(true);
            }
        }
    }

    int ParseScore(string scoreText)
    {
        int score = 0;
        if (scoreText.Contains(" Coins"))
        {
            scoreText = scoreText.Replace(" Coins", "");
            int.TryParse(scoreText, out score);
        }
        return score;
    }

    private void LevelCompleted()
    {
        isLevelSuccess = true;
        isGameplayEnabled = false; // Disable gameplay
        gameSoundEffect.Stop();
        DisablePlayer(); // Disable the player object and stop the game over sound effect
        StartCoroutine(PlayLevelSuccessSound());
        if (gameOverScript != null)
        {
            gameOverScript.enabled = false;
        }
    }

    private System.Collections.IEnumerator PlayLevelSuccessSound()
    {
        yield return new WaitForSeconds(0.1f); // Add a small delay here
        levelSuccessEffect.Play();
    }

    public void Restart()
    {
        levelSuccessEffect.Stop();
        gameSoundEffect.Play();
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    private void DisablePlayer()
    {
        Rigidbody2D playerRigidbody = playerObject.GetComponent<Rigidbody2D>();
        if (playerRigidbody != null)
        {
            playerRigidbody.velocity = Vector2.zero; // Stop the player's velocity
            playerRigidbody.gravityScale = 0f; // Set the gravity scale to 0
        }
        else
        {
            Debug.LogError("Rigidbody2D component not found on the player object!");
        }

        playerObject.SetActive(false);
    }
}
