using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeController : MonoBehaviour
{

    public float speed;
    public float changeTime;

    Rigidbody2D rb;
    float timer;
    int direction = 1;

    Animator anim;

    bool alive = true;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        timer = changeTime;
        anim = GetComponent<Animator>();
    }

    void Update() 
    {

        timer -= Time.deltaTime;

        if (timer < 0)
        {
            direction = -direction;
            timer = changeTime;
        }

        anim.SetFloat("Direction", direction);
    }

    void FixedUpdate()
    {
        Vector2 pos = rb.position;

        pos.x = pos.x + Time.deltaTime * speed * direction;

        rb.MovePosition(pos);
    }

    void OnCollisionEnter2D(Collision2D other) 
    {
        PlayerController player = other.gameObject.GetComponent<PlayerController>();
        if (player != null)
        {
            player.ChangeHealth(-1);
        }
    }

    public void Die()
    {
        StateController.currentSnakes--;

        Destroy(gameObject);
    }
}
