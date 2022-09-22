using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class xScroller : MonoBehaviour
{
    private Vector2 startingLocation;
    private Vector2 endingLocation;
    private Vector2 currentLocation;
    public float movementSpeed = 1;
    public float startDelay;
    public bool isMoving = false;

    private void Awake()
    {
        //Test: made the starting location where the object is when play is initiated, made the end location the negative of the start location on
        //      the x-axis.
        startingLocation = this.transform.position;
        currentLocation = startingLocation;
        endingLocation = new Vector2(-startingLocation.x, startingLocation.y);
    }
    private void Start()
    {
        StartCoroutine(StartMoving());
    }

    public void Stop()
    {
        isMoving = false;
    }

    public IEnumerator StartMoving()
    {
        yield return new WaitForSeconds(startDelay);
        isMoving = true;
    }

    private void FixedUpdate()
    {
        if (isMoving)
        {
            if (currentLocation != endingLocation)
            {
                this.transform.position = Vector2.MoveTowards(currentLocation, endingLocation, movementSpeed * Time.deltaTime);
                currentLocation = this.transform.position;
            }
        }
    }
}
