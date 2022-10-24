using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float movementSpeed;
    private float move;
    public float jump;
    private Rigidbody2D body;
    public float health = 1;
    public float aura = 0;
    public Animator animate;
    private SpriteRenderer sprite;
    public GameObject transformerSound;
    public bool isJumping;

    public Sprite aura_one;
    public Sprite aura_two;
    public GameObject levelFailed;

    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (health <= 0) {
            levelFailed.SetActive(true);
            Destroy(gameObject);
        }

        Debug.Log(aura);

        move = Input.GetAxis("Horizontal");
        body.velocity = new Vector2(movementSpeed * move, body.velocity.y);

        if (Input.GetKeyDown(KeyCode.Space) && isJumping == false) {
            body.AddForce(new Vector2(body.velocity.x, jump));
        }

        AnimationUpdate();
    }

    void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("Transformer_green")) {
            this.gameObject.GetComponent<SpriteRenderer>().sprite = aura_one;
            aura = 1;
            animate.SetBool("Green", true);
            animate.SetBool("Purple", false);
        }
        
        if (other.CompareTag("Transformer_purple")) {
            this.gameObject.GetComponent<SpriteRenderer>().sprite = aura_two;
            aura = 2;
            animate.SetBool("Purple", true);
            animate.SetBool("Green", false);
        }

        if (other.CompareTag("Door")) {
            Destroy(gameObject);
        }
    }

    void AnimationUpdate()  {
        if (move > 0f) {
            animate.SetFloat("movementSpeed", Mathf.Abs(move));
            sprite.flipX = false;
        }
        else if (move < 0f) {
            animate.SetFloat("movementSpeed", Mathf.Abs(move));
            sprite.flipX = true;
        }
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.CompareTag("Ground")) {
            isJumping = false;
        }
    }

    private void OnCollisionExit2D(Collision2D other) {
        if(other.gameObject.CompareTag("Ground")) {
            isJumping = true;
        }
    }
}
