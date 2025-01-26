using UnityEngine;

public class DuelManager : MonoBehaviour
{
    public string playerSpell;
    public string enemySpell;
    public float lastAccuracy;
    public int playerHealth = 100;
    public int enemyHealth = 100;
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
        Debug.Log($"Player selected spell: {playerSpell}");
    }

    public void SetEnemySpell(string spell)
    {
        enemySpell = spell;
        Debug.Log($"Enemy casts spell: {enemySpell}");
    }

    public void UpdateAccuracy(float accuracy)
    {
        lastAccuracy = accuracy;
        Debug.Log($"Last accuracy: {lastAccuracy}%");
    }

    public void AdjustPlayerHealth(int amount)
    {
        playerHealth = Mathf.Clamp(playerHealth + amount, 0, 100);
        Debug.Log($"Player health: {playerHealth}");
    }

    public void AdjustEnemyHealth(int amount)
    {
        enemyHealth = Mathf.Clamp(enemyHealth + amount, 0, 100);
        Debug.Log($"Enemy health: {enemyHealth}");
    }
}