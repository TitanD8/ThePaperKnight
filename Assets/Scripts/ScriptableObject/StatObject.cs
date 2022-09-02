using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CharacterStats", menuName = "StatObjects")]

public class StatObject : ScriptableObject
{
    public string CharacterName;
    public int MaxStamina;
    public int Score;
}
