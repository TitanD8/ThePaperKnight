using UnityEngine;
using UnityEngine.UI;

//This script essentially performs the same task as xScroller.cs, except for the UI rhythm element of the game.
public class UIxScroller : MonoBehaviour
{
    /*
     * Notes:
     *       At a movement speed of 400 it takes approx 11:30 seconds to move all 20 nodes across the screen.
     */
    public Vector2 startingLocation;
    public Vector2 endingLocation;
    public Vector2 currentLocation;
    public float movementSpeed = 1;

    private RectTransform objectPosition;

    private void Awake()
    {
        //Test: made the starting location where the object is when play is initiated, made the end location the negative of the start location on
        //      the x-axis.
        objectPosition = this.GetComponent<RectTransform>();
        startingLocation = objectPosition.position;
        currentLocation = startingLocation;
        endingLocation = new Vector2(-startingLocation.x, startingLocation.y);
    }

    private void FixedUpdate()
    {
        if (currentLocation != endingLocation)
        {
            objectPosition.position = Vector2.MoveTowards(currentLocation, endingLocation, movementSpeed * Time.deltaTime);
            currentLocation = objectPosition.position;
        }
    }
}
