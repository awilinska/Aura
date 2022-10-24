using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Restart : MonoBehaviour
{

    public void ReturnToMenu() {
        SceneManager.LoadScene("Menu");
    }

    public void NewGame() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
