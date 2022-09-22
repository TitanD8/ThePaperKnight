using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

/* This script will be attached to each arrow component of the rhythm game, and will detect:
 * 
 * * if the object is within the Activator
 * * if, while the above is true, the player pressed the correct arrow, destory the game object.
 * * if the object leaves the activator without getting pressed correctly, change color.
 */
public class BeatObject : MonoBehaviour
{
    public bool isActivated;

    public UnityEvent LanceSuccess;
    public UnityEvent ShieldSuccess;

    public KeyCode keyToPress;

    public Lance lanceScript;
    public Shield shieldScript;

    // Start is called before the first frame update
    void Start()
    {
        lanceScript = GameObject.Find("Lance").GetComponent<Lance>(); // Find a refence to the Lance.cs script in the scene.
        shieldScript = GameObject.Find("Shield").GetComponent<Shield>(); // Find a refence to the Shield.cs script in the scene.
        LanceSuccess = new UnityEvent(); // create new Unity Event
        LanceSuccess.AddListener(lanceScript.UpdateCurrentLancePosition); // When unity event is call, also call the UpdateCurrentLancePosition function on Lance.cs
        ShieldSuccess = new UnityEvent(); // create new Unity Event
        ShieldSuccess.AddListener(shieldScript.UpdateCurrentShieldPosition); // When unity event is call, also call the UpdateCurrentLancePosition function on Lance.cs
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(keyToPress))
        {
            if(isActivated)
            {
                if (Input.GetKey(KeyCode.LeftShift))
                {
                    ShieldSuccess.Invoke();
                }
                else
                {
                    LanceSuccess.Invoke();
                }
                gameObject.SetActive(false);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Activator")
        isActivated = true;
        Debug.Log("Active");

        if (other.tag == "MissActivator")
        {
            isActivated = false;
            Debug.Log("Not Active");
        }
    }
}
