using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class SpellSelection : MonoBehaviour
{
    public Button[] spellButtons; // Referenz auf die Zauber-Buttons
    public TextMeshProUGUI selectedSpellsText; // TextMeshPro-UI zur Anzeige der ausgewählten Zauber
    public Button startGameButton; // Button für "Spiel starten"

    // Popup-UI
    public GameObject popupWindow; // Das Popup-Fenster
    public Button[] enemyButtons; // Buttons für die Gegnerauswahl
    public Button cancelButton; // "Abbrechen"-Button im Popup
    public Button[] difficultyButtons; // Buttons für die Schwierigkeitswahl

    public List<string> selectedSpells = new List<string>(); // Liste der ausgewählten Zauber
    private int maxSpells = 3; // Maximale Anzahl der Zauber
    private string selectedEnemy; // Ausgewählter Gegner
   

    void Start()
    {
        // Buttons für Zauber initialisieren
        foreach (Button button in spellButtons)
        {
            button.onClick.AddListener(() => OnSpellButtonClick(button));
        }

        // Popup-Buttons initialisieren
        foreach (Button button in enemyButtons)
        {
            button.onClick.AddListener(() => OnEnemySelected(button));
        }


        // "Abbrechen"-Button initialisieren
        cancelButton.onClick.AddListener(ClosePopup);

        // Popup ausblenden und Start-Button deaktivieren
        popupWindow.SetActive(false);
        startGameButton.interactable = false;

        UpdateSelectedSpellsText();
    }

    void OnSpellButtonClick(Button button)
    {
        string spellName = button.GetComponentInChildren<TextMeshProUGUI>().text; // Name des Zaubers aus dem Button-Text

        if (selectedSpells.Contains(spellName))
        {
            // Entferne den Zauber, wenn er bereits ausgewählt ist
            selectedSpells.Remove(spellName);
        }
        else
        {
            // Füge den Zauber hinzu, solange das Limit nicht erreicht ist
            if (selectedSpells.Count < maxSpells)
            {
                selectedSpells.Add(spellName);
            }
            else
            {
                Debug.Log("Du kannst nur 3 Zauber auswählen!");
            }
        }

        // Aktualisiere Text und Button-Status
        UpdateSelectedSpellsText();
        UpdateStartButtonStatus();
    }

    void UpdateSelectedSpellsText()
    {
        // Aktualisiere das Textfeld mit den ausgewählten Zaubern
        selectedSpellsText.text = string.Join(", ", selectedSpells);
    }

    void UpdateStartButtonStatus()
    {
        // Aktiviere den Start-Button nur, wenn genau 3 Zauber ausgewählt sind
        startGameButton.interactable = selectedSpells.Count == maxSpells;
    }

    public void StartGame()
    {
        if (selectedSpells.Count == maxSpells)
        {
            // Zeige das Popup zur Gegnerauswahl
            popupWindow.SetActive(true);
        }
        else
        {
            Debug.Log("Spiel kann nicht gestartet werden. Bitte wähle 3 Zauber.");
        }
    }

    void OnEnemySelected(Button button)
    {
        // Hole den Namen des Gegners aus dem Button-Text
        selectedEnemy = button.GetComponentInChildren<TextMeshProUGUI>().text;

        Debug.Log("Ausgewählter Gegner: " + selectedEnemy);
        GameManager.Instance.selectedDifficulty = selectedEnemy;
        GameManager.Instance.selectedSpells = selectedSpells;
        // Starte die nächste Szene
        SceneManager.LoadSceneAsync("Duel");
        
        
    }

    void ClosePopup()
    {
        // Popup ausblenden
        popupWindow.SetActive(false);
    }
}
