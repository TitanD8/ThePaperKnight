using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StaminaMetre : MonoBehaviour
{
    private Slider fill;
    // Start is called before the first frame update
    void Awake()
    {
        fill = GetComponent<Slider>();
    }

    // Update is called once per frame
    void Update()
    {
        fill.value = PlayStats.currentStamina;
    }
}
