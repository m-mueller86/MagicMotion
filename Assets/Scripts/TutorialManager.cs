using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class TutorialManager : MonoBehaviour
{
    public Button tutorialButton; // Button für das Tutorial
    public GameObject[] infoBoxes; // Array für die Infoboxen
    public Button[] otherButtons; // Alle anderen Buttons, die deaktiviert werden sollen

    private int currentBoxIndex = 0; // Aktuelle Infobox

    void Start()
    {
        // Verknüpfe den Tutorial-Button mit der Start-Tutorial-Methode
        tutorialButton.onClick.AddListener(StartTutorial);

        // Stelle sicher, dass die Infoboxen am Anfang deaktiviert sind
        foreach (GameObject box in infoBoxes)
        {
            box.SetActive(false);
        }
    }

    void StartTutorial()
    {
        // Deaktiviere alle anderen Buttons
        foreach (Button button in otherButtons)
        {
            button.interactable = false;
        }

        // Starte das Anzeigen der Infoboxen
        currentBoxIndex = 0;
        ShowNextBox();
    }

    public void ShowNextBox()
    {
        // Falls es noch Infoboxen gibt, zeige die nächste
        if (currentBoxIndex < infoBoxes.Length)
        {
            // Aktivere die aktuelle Infobox
            infoBoxes[currentBoxIndex].SetActive(true);

            // Füge einen Listener für den Weiter-Button in der aktuellen Box hinzu
            Button continueButton = infoBoxes[currentBoxIndex].GetComponentInChildren<Button>();
            continueButton.onClick.RemoveAllListeners(); // Entferne alte Listener
            continueButton.onClick.AddListener(() =>
            {
                // Schließe die aktuelle Box und zeige die nächste
                infoBoxes[currentBoxIndex].SetActive(false);
                currentBoxIndex++;
                ShowNextBox();
            });
        }
        else
        {
            // Wenn alle Infoboxen angezeigt wurden, reaktiviere die Buttons
            foreach (Button button in otherButtons)
            {
                button.interactable = true;
            }

            // Tutorial abgeschlossen, Infoboxen bleiben deaktiviert
        }
    }
}
