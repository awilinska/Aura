using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    // // Start is called before the first frame update

    public float laserDamage = 1;
    // void Start()
    // {
        
    // }

    // // Update is called once per frame
    // void Update()
    // {
        
    // }

    void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("Player")) {
            if (other.GetComponent<Player>().aura == 0) {
                other.GetComponent<Player>().health -= laserDamage;
                Debug.Log("Btoom");
            }
        }
    }
}