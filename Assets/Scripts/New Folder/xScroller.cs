using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class xScroller : MonoBehaviour
{
    private Vector2 startingLocation; // A Vector 2 variable to hold an objects starting location.
    private Vector2 endingLocation; // A Vector 2 variable to hold the final location the object will move to.
    private Vector2 currentLocation; // A Vector 2 variable to hold the current location of the object.
    public float movementSpeed; // A float variable to hold a movmement speed the object will be translated by. Can be set in the inspector.
    public float startDelay;  // A float variable to hold a start delay time, can be set in the inspector.
    private bool isMoving = false; // A bool variable that toggle if an object is moving or not.

    private void Awake()
    {
        startingLocation = this.transform.position; // set the Host Object's position to the starting location variable.
        currentLocation = startingLocation; // Set the value of the starting location variable to the current location variable.
        endingLocation = new Vector2(-startingLocation.x, startingLocation.y); // Sets the ending location at the negitive value of the starting location variable's x-axis.
    }
    private void Start()
    {
        StartCoroutine(StartMoving()); //Calls for the start of the coroutine StartMoving, see below.
    }

    public void Stop()
    {
        isMoving = false; // Sets isMoving bool to false. this stops the Host Object's Movement across the screen.
    }

    public IEnumerator StartMoving()
    {
        yield return new WaitForSeconds(startDelay); // wait for the amount of time set in timeDelay before continuing,
        isMoving = true; // Set isMoving bool to true. This stats the Host Object's Movement across the screen.
    }

    private void FixedUpdate()
    {
        if (isMoving) // if isMoving is true
        {
            if (currentLocation != endingLocation) //Check that the Players current location is not equal to the ending location variable.
            {
                this.transform.position = Vector2.MoveTowards(currentLocation, endingLocation, movementSpeed * Time.deltaTime); // determine where the position of the Host Object will be since the last Physic's update.
                currentLocation = this.transform.position; //Set Host Object's new position to the currentLocation variable.
            }
        }
    }
}
