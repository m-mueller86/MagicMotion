using UnityEngine;
using UnityEngine.UI;

public class SpellSelectionUI : MonoBehaviour
{
    public GameObject selectionPanel;
    public Button[] spellButtons;
    private int selectedIndex = 0; 
    public Color normalColor = Color.white;
    public Color highlightColor = Color.yellow;
    public DuelManager duelManager;

    void Start()
    {
        selectionPanel.SetActive(true);
        ResetButtonColors();
    }

    void Update()
    {
        if (selectionPanel.activeSelf)
        {
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                selectedIndex = (selectedIndex - 1 + spellButtons.Length) % spellButtons.Length;
                HighlightButton();
            }
            
            if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                selectedIndex = (selectedIndex + 1) % spellButtons.Length;
                HighlightButton();
            }
            
            if (Input.GetKeyDown(KeyCode.Return))
            {
                SelectSpell();
            }
        }
    }
    
    public void OpenSpellSelection()
    {
        selectionPanel.SetActive(true);
        selectedIndex = 0;
        HighlightButton();
    }
    
    public void CloseSpellSelection()
    {
        selectionPanel.SetActive(false);
    }
    
    private void HighlightButton()
    {
        ResetButtonColors();
        var colors = spellButtons[selectedIndex].colors;
        colors.normalColor = highlightColor;
        spellButtons[selectedIndex].colors = colors;
    }
    
    private void ResetButtonColors()
    {
        foreach (Button button in spellButtons)
        {
            var colors = button.colors;
            colors.normalColor = normalColor;
            button.colors = colors;
        }
    }

    private void SelectSpell()
    {
        spellButtons[selectedIndex].onClick.Invoke();
        duelManager.hasPlayerChosenCounterSpell = true;
        CloseSpellSelection();
    }
}
