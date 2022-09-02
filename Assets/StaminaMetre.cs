using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StaminaMetre : MonoBehaviour
{
    public Slider fill;
    public bool isPlayer;
    public KnightStats playerStats;
    public KnightStats enemyStats;

    // Start is called before the first frame update
    void Start()
    {
        fill = GetComponent<Slider>();
        playerStats = GameObject.FindGameObjectWithTag("Player").GetComponent<KnightStats>();
        //enemyStats = GameObject.FindGameObjectWithTag("Enemy").GetComponent<KnightStats>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isPlayer)
        {
            fill.value = playerStats.currentHealth;
        }
        else
        {
            //fill.value = enemyStats.currentHealth;
        }
    }
}
