using UnityEngine;

public class DuelManager : MonoBehaviour
{
    public string playerSpell;
    public string enemySpell;
    public float accuracy;
    public int playerDamage = 10;
    public int enemyDamage = 10;
    public bool hasPlayerChosenCounterSpell = false;
    public bool hasPatternArchivedOrTimeout = false;
    
    public void SetHasPatternArchivedOrTimeout(bool value)
    {
        hasPatternArchivedOrTimeout = value;
    }
    
    public void SetPlayerChosenCounterSpell(bool value)
    {
        hasPlayerChosenCounterSpell = value;
    }

    public void SetPlayerSpell(string spell)
    {
        playerSpell = spell;
    }

    public void SetEnemySpell(string spell)
    {
        enemySpell = spell;
    }

    public void SetAccuracy(float accuracy)
    {
        this.accuracy = accuracy;
    }

    public void CalculateDamage()
    {
        if (enemySpell == "FireballAnimation" && playerSpell == "LeafSwordAnimationPlayer")
        {
            playerDamage += 5;
        }
        if (enemySpell == "LeafSwordAnimation" && playerSpell == "FireballAnimationPlayer")
        {
            enemyDamage += 5;
        }
        if (enemySpell == "LightningAnimation" && playerSpell == "FireballAnimationPlayer")
        {
            playerDamage += 5;
        }
        if (enemySpell == "FireballAnimation" && playerSpell == "LightningAnimationPlayer")
        {
            enemyDamage += 5;
        }
        if (enemySpell == "LeafSwordAnimation" && playerSpell == "LightningAnimationPlayer")
        {
            playerDamage += 5;
        }
        if (enemySpell == "LightningAnimation" && playerSpell == "LeafSwordAnimationPlayer")
        {
            enemyDamage += 5;
        }
        if (enemySpell == "ShieldAnimation")
        {
            enemyDamage = 0;
        }
        if (playerSpell == "ShieldAnimation")
        {
            playerDamage = 0;
        }
        enemyDamage = (int) (enemyDamage * (accuracy / 100));
        Debug.Log("Damage: " +  enemyDamage);
    }
}