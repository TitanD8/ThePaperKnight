using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class V2_CursorController : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition); // Creates a ray cast from the Main Camera to the player's cursor and sets it to the variable 'Ray'
        RaycastHit2D hit = Physics2D.GetRayIntersection(ray, Mathf.Infinity); //Uding 'Ray' created above, check if the raycast intersects a collider.

        if (Input.GetMouseButtonDown(0)) //when the player clicks the LMB.
        {
            if (hit.collider.name == "Play") //Check if the collider that was hit by the raycast is called "Play"
            {
                PlayStats.gameHasStarted = false; //Set the gameHasStarted variable to true in PlayStats.cs
                SceneManager.LoadScene(1); //Load scene 1 from the scene index.
            }
            
            if (hit.collider.name == "Exit") //Check if the collider that was hit by the raycast is called "Exit" 
            {
                Debug.Log("Exit Program"); //Show "Exit Program" in the console inspector.
            }
        }
    }
}
