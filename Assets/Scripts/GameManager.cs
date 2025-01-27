using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance; // Singleton-Pattern
    public string selectedDifficulty = "Mittel"; // Ausgewählte Schwierigkeit
    public List<string> selectedSpells = new List<string>(); // Ausgewählte Zauber

    void Awake()
    {
        // Singleton-Logik
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // Erhalte das Objekt zwischen Szenen
        }
        else
        {
            Destroy(gameObject);
        }
    }
}