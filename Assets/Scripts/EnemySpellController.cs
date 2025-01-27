using UnityEngine;

public class EnemySpellController : MonoBehaviour
{
    public GameObject[] spellPrefabs;
    public DuelManager duelManager; 
    public float spellSpeed = 1f;
    public GameObject spellSelectionMenu;
    private GameObject activeSpell = null;
    private bool roundOver = false;
    
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
        if (duelManager.hasPatternArchivedOrTimeout && activeSpell == null)
        {
            roundOver = true;
        }
        
        if (activeSpell != null && duelManager.hasPatternArchivedOrTimeout && duelManager.enemySpell != "ShieldAnimation")
        {
            activeSpell.transform.position += Vector3.right * spellSpeed * Time.deltaTime;
            if (activeSpell.transform.position.x > 640)
            {
                Destroy(activeSpell);
                activeSpell = null;
            }
        }

        if (roundOver)
        {
            roundOver = false;
            int randomIndex = Random.Range(0, spellPrefabs.Length);
            SpawnSpell(randomIndex);
            duelManager.SetHasPatternArchivedOrTimeout(false);
        }
    }
}