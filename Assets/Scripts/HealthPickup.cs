using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPickup : MonoBehaviour
{


    void OnTriggerEnter2D(Collider2D other) 
    {
        PlayerController cont = other.GetComponent<PlayerController>();

        if (cont != null && cont.currentHealth != cont.maxHealth)
        {
            cont.ChangeHealth(1);
            Destroy(gameObject);
        }
    }
}
