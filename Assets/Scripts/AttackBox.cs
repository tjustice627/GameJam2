using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackBox : MonoBehaviour
{

    int timeOut;

    Rigidbody2D rb;
    // Start is called before the first frame update
    void Awake() 
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        timeOut++;

        if (timeOut >= 200)
        {
            Destroy(gameObject);
        }
    }

    void OnCollisionEnter2D(Collision2D other) 
    {
        SnakeController s = other.collider.GetComponent<SnakeController>();

        if (s != null)
        {
            s.Die();
        }

        Destroy(gameObject);
    }
}
