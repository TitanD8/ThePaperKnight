using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreObject : MonoBehaviour
{
    public GameObject[] flagArray;
    public bool isPlayer = true;

    // Start is called before the first frame update
    void Awake()
    {
        foreach(GameObject flag in flagArray)
        {
            flag.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(isPlayer == true && PlayStats.playerScore > 0)
        {
            for (int i = 0; i < PlayStats.playerScore; i++)
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