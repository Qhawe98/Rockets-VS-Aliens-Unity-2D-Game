using UnityEngine;

public class BorderCollision : MonoBehaviour
{
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Rigidbody2D rb = collision.gameObject.GetComponent<Rigidbody2D>();
            Vector2 clampedPosition = new Vector2(
                Mathf.Clamp(rb.position.x, transform.position.x - transform.localScale.x / 2f, transform.position.x + transform.localScale.x / 2f),
                Mathf.Clamp(rb.position.y, transform.position.y - transform.localScale.y / 2f, transform.position.y + transform.localScale.y / 2f)
            );
            rb.position = clampedPosition;
            rb.velocity = Vector2.zero;
        }
    }
}
