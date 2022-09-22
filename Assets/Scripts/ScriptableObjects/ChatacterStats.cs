using UnityEngine;

[CreateAssetMenu(fileName = "CharacterStats", menuName = "Stats", order = 0)]
public class ChatacterStats : ScriptableObject
{
    //Base Stats
    private int baseHealth = 10;

    //variable stats
    public int currentHealth;
    public int lancePosition;

    public void ResetStats()
    {
        currentHealth = baseHealth;
        lancePosition = 1;
    }
    
    public void TakeDamage(int damageAmount)
    {
        currentHealth -= damageAmount;
    }


}
