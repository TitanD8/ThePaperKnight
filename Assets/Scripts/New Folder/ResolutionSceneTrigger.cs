using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ResolutionSceneTrigger : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player") // if the player collides with the Host Object's collider.
        {
            SceneManager.LoadScene(2); //Load the Resolution Scene.
        }
    }
    
}
