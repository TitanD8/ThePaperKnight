using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreObject : MonoBehaviour
{
    public GameObject[] flagArray; //An array to hold flag game objects. Filled in the Inspectior
    public bool isPlayer = true; //a bool which determines if this attached to player. Set in the Inspector.

    // Start is called before the first frame update
    void Awake()
    {
        foreach(GameObject flag in flagArray) //Cycle through each gameObject in the array
        {
            flag.SetActive(false); //set the gameobject as inactive.
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(isPlayer == true && PlayStats.playerScore > 0) //if this script is attached to the player and the player score (PlayStats) is greater than 0
        {
            for (int i = 0; i < PlayStats.playerScore; i++) //f
            {
                if (flagArray[i] != null)
                {
                    flagArray[i].SetActive(true);
                }
                else
                {
                    // Do nothing
                }
            }
            
        }
        else if(isPlayer == false && PlayStats.enemyScore > 0)
        {
            for (int i = 0; i < PlayStats.enemyScore; i++)
            {
                if (flagArray[i] != null)
                {
                    flagArray[i].SetActive(true);
                }
            }
        }
    }
}
