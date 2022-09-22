using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : MonoBehaviour
{
    public int shieldPositionID = -1;
    public float[] shieldPositionY = new float[]
    {
        0.0f,
        0.0f,
        0.29f,
        0.52f
    };

    public float currentPosition;
    public float targetPosition;

    public float movementSpeed;

    public bool shieldIsAcending = true;
    public bool shieldIsMoving = false;
    public bool shieldIsTurned = true;

    public SpriteRenderer turnedShield;
    public SpriteRenderer squaredShield;

    public void UpdateCurrentShieldPosition()
    {
        shieldIsTurned = false;
        //This function is called from BeatObject.cx; it updates the current shield position,
        //and sets the new target position for the shield to move to.

        //First Check if the Shield has reached either its max or min values and change direction
        if (shieldPositionID == 3)
        {
            //if shield is at max, move shield down;
            shieldIsAcending = false;
        }
        if(shieldPositionID == 1)
        {
            //if shield is a min, move shield up;
            shieldIsAcending = true;
        }

        if(shieldIsAcending) //If shield is rising...
        {
            shieldPositionID = shieldPositionID + 1; //increase shield position id by 1
        }
        if(!shieldIsAcending) //if shield is falling...
        {
            shieldPositionID = shieldPositionID - 1;
        }
        ChangeShieldPosition();
    }

    public void ChangeShieldPosition()
    {
        currentPosition = this.transform.localPosition.y;
        targetPosition = shieldPositionY[shieldPositionID];
        shieldIsMoving = true;
    }

    private void Update()
    {
        if(!shieldIsTurned)
        {
            turnedShield.enabled = false;
            squaredShield.enabled = true;
        }
        if(shieldIsMoving)
        {
            this.transform.localPosition = Vector2.MoveTowards(new Vector2(0.0f, currentPosition), new Vector2(0.0f, targetPosition), movementSpeed * Time.deltaTime);
            currentPosition = this.transform.localPosition.y;
            if(currentPosition == targetPosition)
            {
                shieldIsMoving = false;
            }
        }
    }
}
