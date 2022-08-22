using UnityEngine;

public class LanceController : MonoBehaviour
{
    //These three game objects hold a sprite of a lance at a different fixed rotation.
    public GameObject headStrikeSprite;
    public GameObject bodyStrikeSprite;
    public GameObject missStrikeSprite;

    // This function checks the hitFactor stat from PlayStats to detemine if the player strikes the enemies head, body or misses completely.
    public void StrikeCheck()
    {
        if(PlayStats.hitFactor == 1)
        {
            BodyStrike();
        }
        else if(PlayStats.hitFactor == 2)
        {
            HeadStrike();
        }
        else
        {
            MissStrike();
        }
    }

    // This function checks the enemyHitFactor stat from PlayStats to detemine if the enemy strikes the player's head, body or misses completely.
    public void EnemyStrikeCheck(int eHitFactor)
    {
            
        if (eHitFactor == 1)
        {
            BodyStrike();
        }
        else if (eHitFactor == 2)
        {
            HeadStrike();
        }
        else
        {
            MissStrike();
        }
    }

    //Sets the miss lance as the active sprite.
    public void MissStrike()
    {
        bodyStrikeSprite.SetActive(false);
        headStrikeSprite.SetActive(false);
        missStrikeSprite.SetActive(true);
    }

    //Sets the head strike lance as the active sprite.
    public void HeadStrike()
    {
        bodyStrikeSprite.SetActive(false);
        headStrikeSprite.SetActive(true);
        missStrikeSprite.SetActive(false);
    }

    //Sets the BodyStrike lance as the active sprite
    public void BodyStrike()
    {
        bodyStrikeSprite.SetActive(true);
        headStrikeSprite.SetActive(false);
        missStrikeSprite.SetActive(false);
    }
}
