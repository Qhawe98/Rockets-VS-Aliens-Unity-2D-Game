using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    [SerializeField] private AudioSource gameOverSoundEffect;
    [SerializeField] private AudioSource gameSoundEffect;
    public GameObject gameOverPanel;

    private bool isGameOver = false; // Track if the game is over
   
    void Update()
    {
        if (!isGameOver && GameObject.FindGameObjectWithTag("Player") == null)
        {
            isGameOver = true;
            StartCoroutine(PlayGameOverSound());
            gameSoundEffect.Stop();
            gameOverPanel.SetActive(true);
        }
    }

    private System.Collections.IEnumerator PlayGameOverSound()
    {
        yield return new WaitForSeconds(0.1f); // Add a small delay here
        gameOverSoundEffect.Play();
    }

    public void Restart()
    {
        gameOverSoundEffect.Stop();
        gameSoundEffect.Play();
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
