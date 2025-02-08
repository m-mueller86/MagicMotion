using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TrainingSpellSelection : MonoBehaviour
{
    public Button[] spellButtons; // Referenz auf die Zauber-Buttons
    public List<string> selectedSpells = new List<string>(); // Liste der ausgewählten Zauber
    public DuelManager duelManager;

    void Start()
    {
        // Buttons für Zauber initialisieren
        foreach (Button button in spellButtons)
        {
            button.onClick.AddListener(() => OnSpellButtonClick(button));
        }
    }
    
    void OnSpellButtonClick(Button button)
    {
        string spellName = button.GetComponentInChildren<TextMeshProUGUI>().text; // Name des Zaubers aus dem Button-Text
        selectedSpells.Add(spellName);
        duelManager.trainingSpell = spellName;
        duelManager.SetHasPatternArchivedOrTimeout(false);
        GameManager.Instance.selectedSpells = selectedSpells;
        SceneManager.LoadSceneAsync("Training");
    }
}
