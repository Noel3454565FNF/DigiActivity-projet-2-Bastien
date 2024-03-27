using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevel : MonoBehaviour
{
    private int currentSceneId = 0;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        currentSceneId = SceneManager.GetActiveScene().buildIndex;
        if(collision.CompareTag("Player"))
        {
            // change pour le niveau d'apres
            SceneManager.LoadScene(currentSceneId + 1);
        }
    }
}