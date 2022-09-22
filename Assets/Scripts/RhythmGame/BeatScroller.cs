using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeatScroller : MonoBehaviour
{
    private Vector2 currentPosition = new Vector2(-5f, -3.6f); //This store the initial location of the NoteHolder Object, and is updated every time Fixed Update is called.
    private Vector2 endingPosition = new Vector2(-57f, -3.6f); //This stores the final location of the NoteHolder Object.
    

    public float beatTempo; // This will be used to set the beats per minute tempo in the inspector.

    public float beatsPerSecond; // This will contain the beats per second tempo, which will be used to move arrow markers.
    
    // Start is called before the first frame update
    void Start()
    {
        beatsPerSecond = beatTempo / 60f; // beats per minute divided by sixty seconds equals beats per second (i.e. 120bpm / 60 seconds = 2 bps)
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //If the current possition is not equal to ending possition, the move towards the ending position at the rate of the beats per second.
        //Update current position value.
        if (currentPosition != endingPosition)
        {
            this.transform.position = Vector2.MoveTowards(currentPosition, endingPosition, beatsPerSecond * Time.deltaTime);
            currentPosition = this.transform.position;
        }
    }
}
