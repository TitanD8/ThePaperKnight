using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class UiZoneExit : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(PlayStats.lanceIsCradled == true)
        {
            PlayStats.currentStamina -= 1;
        }
    }
}
