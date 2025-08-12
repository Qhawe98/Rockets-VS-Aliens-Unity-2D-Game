using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public float jumpForce = 5f;
    public float topLimit = 4.5f;
    public float bottomLimit = -4.5f;
    private Rigidbody2D rb;
    private int score = 0;
    private Text scoreText;
    [SerializeField] private AudioSource jumpSoundEffect;
    [SerializeField] private AudioSource coinSoundEffect;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        GameObject canvas = GameObject.Find("Canvas"); // Replace "Canvas" with the name of your Canvas GameObject
        if (canvas != null)
        {
            scoreText = canvas.transform.Find("Score Text").GetComponent<Text>(); // Replace "Score Text" with the name of your score text UI GameObject
            if (scoreText == null)
            {
                Debug.LogError("ScoreText object or Text component not found!");
            }
        }
        else
        {
            Debug.LogError("Canvas object not found!");
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.velocity = Vector2.up * jumpForce;
        }
        else if (Input.GetKeyUp(KeyCode.Space))
        {
            jumpSoundEffect.Play();
            rb.velocity = Vector2.zero;
        }

        // Clamp the y-axis position to prevent going above the top limit
        float clampedY = Mathf.Clamp(transform.position.y, bottomLimit, topLimit);
        transform.position = new Vector3(transform.position.x, clampedY, transform.position.z);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Coin"))
        {
            coinSoundEffect.Play();
            Destroy(collision.gameObject);
            IncreaseScore();
        }
    }

    private void IncreaseScore()
    {
        score++;
        scoreText.text = score.ToString() + " Coins";
    }
}
