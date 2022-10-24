using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{

    public GameObject levelClear;
      
    void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("Player")) {
            levelClear.SetActive(true);
        }
    }
}
