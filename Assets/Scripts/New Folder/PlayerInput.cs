using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class PlayerInput : MonoBehaviour
{
    // Detects Player Input
    // Controls Active Target
    // Destroys Active Target on Success


    public GameObject currentNode; // A variable to hold the current node object.
    public ActiveNode node; // A variable to hold a reference to the script ActiveNode.cs

    public UnityEvent Hit; //A public unity event named hit which is defined in the inspector.
    public UnityEvent Miss; //A public unity event named miss which is defined in the inspector.

    [SerializeField] //creates a serialized slider field which contains a float that controls how difficult it is to time your presses correctly.
    [Range(0f, 100f)]
    private float difficultly;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        currentNode = collision.gameObject; //set the current colliding game object to the variable currentNode.
    }

    private void Update()
    {
        if (currentNode != null) //If currentNode is not empty
        {
            if (currentNode.GetComponent<RectTransform>().position.x > this.GetComponent<RectTransform>().position.x - difficultly 
                && currentNode.GetComponent<RectTransform>().position.x < this.GetComponent<RectTransform>().position.x + difficultly) //if the currentNode is within the specified area
            {
                if (PlayStats.lanceIsCradled == false) //If the variable lanceIsCradled from PlayStats.cs is equal to false.
                {
                    if (Input.GetKeyDown(KeyCode.Z)) // If the player presses the Z key on their keyboard.
                    {
                        //if player gets the node,

                        //increase static hit factor is less than 2
                        //invoke Hit event
                        //Destroy currentNode;

                        PlayStats.IncreaseHitFactor(); //call the IncreaseHitFactor function from PlayStats.cs
                        Hit.Invoke(); //Invoke the unity event Hit. (Call StrikeCheck function from PlayStats.cs)
                        Destroy(currentNode); //Destory the gameobject currently in the currentNode variable
                        currentNode = null; // Set the current node variable to empty
                    }
                }
                else
                {
                    // do nothing
                }
            }
            else //Else if the gameObject in currentNode is outside the specific area of interaction.
            {
                if (PlayStats.lanceIsCradled == false) // if the variable lanceIsCradled from PlayStats.cs is equal to false
                {
                    if (Input.GetKeyDown(KeyCode.Z)) // if the player his the Z key on the keyboard
                    {
                        PlayStats.DecreaseHitFactor(); //call the DecreaseHitFactor function from PlayStats.cs
                        Miss.Invoke(); //Invoke unity event Miss (Call StrikeCheck function from playStats.cs
                    }
                }
            }
        }

        if (Input.GetKeyDown(KeyCode.Space)) // if the player presses the Space Key on their keyboard.
        {
            PlayStats.lanceIsCradled = true; // set the variable lanceIsCradled from PlayStats.cs to true.
        }
    }
}
