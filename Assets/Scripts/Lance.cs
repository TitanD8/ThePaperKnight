using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lance : MonoBehaviour
{
    //Lance Variables
    public float rotationSpeed;
    public bool lanceIsAcending = true;
    public bool lanceIsMoving = false;

    private Quaternion[] lancePosition = new Quaternion[]
    {
        Quaternion.Euler(0f,0f,-15f),
        Quaternion.Euler(0f,0f,-7f),
        Quaternion.Euler(0f,0f,4f),
        Quaternion.Euler(0f,0f,12f),
        Quaternion.Euler(0f,0f,25f)
    };
    private Quaternion targetAngle;
    private Quaternion currentAngle;

    public int currentLancePosition = -1;

    private void Start()
    {
        //shield = GameObject.Find("Shield");
    }

    private void Update()
    {
        if (lanceIsMoving)
        {
            this.transform.rotation = Quaternion.Slerp(this.transform.rotation, targetAngle, rotationSpeed * Time.deltaTime);
            currentAngle = this.transform.rotation;
            if (currentAngle == targetAngle)
            {
                lanceIsMoving = false;
            }
        }
    }

    public void UpdateCurrentLancePosition()
    {
        Debug.Log("Update");

        if(currentLancePosition == 4)
        {
            lanceIsAcending = false;
        }
        if (currentLancePosition == 0)
        {
            lanceIsAcending = true;
        }

       if(lanceIsAcending) //if acending
        {
            /*check if Current Lance Position is = 4, Assign Current Lance Position to the Previous Lance Position,
             *then decease the current value by 1 and make isAcending false.
             *
             *else Assign Current Lance Position to the Previous Lance Position, then increase the current value by 1
             */
            currentLancePosition += 1;
        }
        else if(!lanceIsAcending)// if not acending
        {
            /*check if Current Lance Position is equal to 0, Assign Current Lance Position to the Previous Lance Position,
             *then increase the current value by 1 and make isAcending true.
             *
             *else Assign Current Lance Position to the Previous Lance Position, then decrease the current value by 1
             */
            currentLancePosition -= 1;
        }
        ChangeLancePosition(currentLancePosition); //Update lance position using the newly set Current Lance Position.
    }

    /*private void ChangeShieldPosition(int currentShieldPosition)
    {
        currentHeight = shield.transform.position;
        targetHeight = shieldPositions[currentShieldPosition];
        shieldIsMoving = true;
    }*/

    private void ChangeLancePosition(int currentLancePosition)
    {
        currentAngle = this.transform.rotation;
        targetAngle = lancePosition[currentLancePosition];
        lanceIsMoving = true;
    }
}
