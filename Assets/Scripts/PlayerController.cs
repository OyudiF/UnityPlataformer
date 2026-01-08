using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed;
    public Rigidbody2D rig;
    public float jumpForce;
    public SpriteRenderer sr;
    public TextMeshProUGUI scoreText;

    public int score;

    private bool isGrounded;
    // Runs on 60 frames per second always
    void FixedUpdate()
    {
        float moveInput = Input.GetAxisRaw("Horizontal");
        rig.linearVelocity = new Vector2(moveInput * moveSpeed, rig.linearVelocity.y);

        // Sprite flip > 0 right < 0 Left
        if(rig.linearVelocity.x > 0)
        {
            sr.flipX = true;
        }
        else if(rig.linearVelocity.x < 0)
        {
            sr.flipX = false;
        }
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.UpArrow) && isGrounded == true)
        {
            isGrounded = false;
            rig.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }

        if(transform.position.y < -4)
        {
            GameOver();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(Vector2.Dot(collision.GetContact(0).normal, Vector2.up) > 0.8f)
        {
            isGrounded = true;
        }
    }

    public void GameOver()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void AddScore(int amount)
    {
        score += amount;
        scoreText.text = "Score: " + score;

    }
}
