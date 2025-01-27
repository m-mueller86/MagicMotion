using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int maxHealth = 30;
    public int currentHealth;
    public Healthbar healthbar;
    
    // Start is called before the first frame update
    void Start()
    {
        string difficulty = GameManager.Instance.selectedDifficulty;
        Debug.Log("GameManager diff: " + difficulty);

        
        SetDifficulty(difficulty);
        
        currentHealth = maxHealth;
        healthbar.setMaxHealth(maxHealth);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            TakeDamage(10);
        }
    }

    void TakeDamage(int damage)
    {
        currentHealth -= damage;
        
        healthbar.setHealth(currentHealth);
    }
    public void SetDifficulty(string difficulty)
    {
        switch (difficulty)
        {
            case "Einfach":
                maxHealth = 20; // Weniger Lebenspunkte für einfache Schwierigkeit
                break;
            case "Mittel":
                maxHealth = 30; // Standardwert
                break;
            case "Schwer":
                maxHealth = 50; // Mehr Lebenspunkte für hohe Schwierigkeit
                break;
            default:
                Debug.LogWarning("Unbekannte Schwierigkeit: " + difficulty);
                break;
        }

        // Aktualisiere currentHealth und Healthbar
        currentHealth = maxHealth;
        if (healthbar != null)
        {
            healthbar.setMaxHealth(maxHealth);
        }
    }
}
