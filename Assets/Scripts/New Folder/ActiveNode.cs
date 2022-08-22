using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveNode : MonoBehaviour
{
    //All this Script seems to do is alternate the node from inactive to active and back again using colliders and triggers.

    //public bool which determines if this node is the current active node, interactable by the player.
    public bool isActive = false;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!isActive)
        {
            isActive = true;
        }
        else if (isActive)
        {
            isActive = false;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
