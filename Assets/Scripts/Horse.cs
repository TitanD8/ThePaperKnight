using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Horse : MonoBehaviour
{
    // Start is called before the first frame update
    void Awake()
    {
        SetRhythmTrack();
    }

    private void SetRhythmTrack()
    {
        GameObject.Find("NoteHolder").transform.SetParent(GameObject.Find("RhythmGame").transform);
    }
}
