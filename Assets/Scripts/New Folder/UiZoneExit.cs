using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

//This script activates a behaviour if a certian condition is met.

public class UiZoneExit : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision) 
    {
        if(PlayStats.lanceIsCradled == true) //if the bool lanceIsCradled from PlayStats.cs is set true
        {
            PlayStats.currentStamina -= 1; //Decrease the currentStamina variable from PlayStats.cs
        }
    }
}
