using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser_purple : MonoBehaviour
{

    public float laserDamage = 1;


    void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("Player")) {
            if (other.GetComponent<Player>().aura != 2) {
                other.GetComponent<Player>().health -= laserDamage;
                Debug.Log("Btoom");
            }
        }
    }
}
