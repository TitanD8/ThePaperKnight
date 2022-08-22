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


    public GameObject currentNode;
    public ActiveNode node;

    public UnityEvent Hit;
    public UnityEvent Miss;
    [SerializeField]
    [Range(0f, 100f)]
    private float difficultly;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        currentNode = collision.gameObject;
        Debug.Log("Node");
    }

    private void Update()
    {
        if (currentNode != null)
        {
            if (currentNode.GetComponent<RectTransform>().position.x > this.GetComponent<RectTransform>().position.x - difficultly
                && currentNode.GetComponent<RectTransform>().position.x < this.GetComponent<RectTransform>().position.x + difficultly)
            {
                if (PlayStats.lanceIsCradled == false)
                {
                    if (Input.GetKeyDown(KeyCode.Z))
                    {
                        //if player gets the node,

                        //increase static hit factor is less than 2
                        //invoke Hit event
                        //Destroy currentNode;

                        PlayStats.IncreaseHitFactor();
                        Hit.Invoke();
                        Destroy(currentNode);
                        currentNode = null;
                    }
                }
                else
                {
                    // do nothing
                }
            }
            else
            {
                if (PlayStats.lanceIsCradled == false)
                {
                    if (Input.GetKeyDown(KeyCode.Z))
                    {
                        PlayStats.DecreaseHitFactor();
                        Miss.Invoke();
                    }
                }
            }
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            PlayStats.lanceIsCradled = true;
        }
    }

    /*
        void OnTriggerEnter2D(Collider2D other)
        {
            if(other.tag == "Node")
            {
                currentNode = other.gameObject;
            }
        }

        void OnTriggerStay2D(Collider2D other)
        {
            if (currentNode != null && PlayStats.lanceIsCradled == false)
            {
                if (Input.GetKeyDown(KeyCode.Z))
                {
                    //if player gets the node,

                    //increase static hit factor is less than 2
                    //invoke Hit event
                    //Destroy currentNode;

                    PlayStats.IncreaseHitFactor();
                    Hit.Invoke();
                    Destroy(currentNode);
                }
            }
            else { 
                    // do nothing
                 }
        }
    */

}
