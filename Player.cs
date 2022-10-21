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

    public Sprite aura_one;

    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (health <= 0) {
            Destroy(gameObject);
        }

        Debug.Log(aura);

        move = Input.GetAxis("Horizontal");
        body.velocity = new Vector2(movementSpeed * move, body.velocity.y);

        if (Input.GetKeyDown(KeyCode.Space)) {
            body.AddForce(new Vector2(body.velocity.x, jump));
        }

        AnimationUpdate();
    }

        void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("Transformer")) {
            if (aura == 0) {
                Instantiate(transformerSound, transform.position, Quaternion.identity);
            }
            this.gameObject.GetComponent<SpriteRenderer>().sprite = aura_one;
            aura = 1;
            animate.SetBool("Green", true);
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
}
