using UnityEngine;

public class EnemySpellController : MonoBehaviour
{
    public GameObject[] spellPrefabs;
    public DuelManager duelManager; 
    public float spellSpeed = 1f;
    public GameObject spellSelectionMenu;
    private GameObject activeSpell = null;
    
    public void SpawnSpell(int spellIndex)
    {
        GameObject spellPrefab = spellPrefabs[spellIndex];
        SpellAnimationData spellData = spellPrefab.GetComponent<SpellAnimationData>();
        Vector3 spawnPosition = spellData.spawnPosition;
        duelManager.SetEnemySpell(spellPrefab.name);
        activeSpell = Instantiate(spellPrefab, spawnPosition, Quaternion.identity);
        SpellSelectionUI spellSelectionUI = spellSelectionMenu.GetComponent<SpellSelectionUI>();
        spellSelectionUI.OpenSpellSelection();
        
    }

    void Start()
    {
            SpawnSpell(1);
    }

    void Update()
    {
        if (activeSpell != null && duelManager.enemySpell != "ShieldAnimation" && duelManager.hasPatternArchivedOrTimeout)
        {
            activeSpell.transform.position += Vector3.right * spellSpeed * Time.deltaTime;
            
            if (activeSpell.transform.position.x > 640f)
            {
                Destroy(activeSpell);
                activeSpell = null;
                duelManager.SetHasPatternArchivedOrTimeout(false);
            }
        }
    }
}