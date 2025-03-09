using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float moveForce = 10f;
    [SerializeField] private float jumpForce = 11f;
    [SerializeField] private int maxHealth = 5;

    private float movementX;
    private int currentHealth;
    private Rigidbody2D myBody;
    private SpriteRenderer sprite;
    private Animator anim;

    private string WALK_ANIMATION = "Walk";
    private string GROUND_TAG = "Ground";
    private string MONSTER_TAG = "Monster";

    private bool isGrounded = true;

    // Manually assigned heart images
    public GameObject heart1;
    public GameObject heart2;
    public GameObject heart3;
    public GameObject heart4;
    public GameObject heart5;

    private void Awake()
    {
        myBody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();

        currentHealth = maxHealth;
    }

    void Update()
    {
        PlayerMoveKeyboard();
        AnimatePlayer();

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            PlayerJump();
        }
    }

    void PlayerMoveKeyboard()
    {
        movementX = Input.GetAxisRaw("Horizontal");
        transform.position += new Vector3(movementX, 0, 0) * moveForce * Time.deltaTime;
    }

    void AnimatePlayer()
    {
        if (movementX > 0)
        {
            anim.SetBool(WALK_ANIMATION, true);
            sprite.flipX = false;
        }
        else if (movementX < 0)
        {
            anim.SetBool(WALK_ANIMATION, true);
            sprite.flipX = true;
        }
        else
        {
            anim.SetBool(WALK_ANIMATION, false);
        }
    }

    void PlayerJump()
    {
        isGrounded = false;
        myBody.linearVelocity = new Vector2(myBody.linearVelocity.x, jumpForce);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag(GROUND_TAG))
        {
            isGrounded = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag(MONSTER_TAG))
        {
            TakeDamage();
        }
    }

    void TakeDamage()
    {
        if (currentHealth > 0)
        {
            RemoveHeart(currentHealth);
            currentHealth--;
        }

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void RemoveHeart(int health)
    {
        switch (health)
        {
            case 5: Destroy(heart5); break;
            case 4: Destroy(heart4); break;
            case 3: Destroy(heart3); break;
            case 2: Destroy(heart2); break;
            case 1: Destroy(heart1); break;
        }
    }

    void Die()
    {
        Debug.Log("Player Died!");
        gameObject.SetActive(false);
    }
}
