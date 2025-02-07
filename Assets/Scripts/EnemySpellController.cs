using UnityEngine;

public class EnemySpellController : MonoBehaviour
{
    public GameObject[] spellPrefabs;
    public GameObject[] playerSpells; 
    public DuelManager duelManager; 
    public float spellSpeed = 1f;
    public GameObject spellSelectionMenu;
    private GameObject activeSpell = null;
    private GameObject playerActiveSpell = null;
    private bool roundOver = false;
    public Enemy enemy;

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

    public void SpawnPlayerSpell(string spellName)
    {
        for (int i = 0; i < playerSpells.Length; i++)
        {
            if (playerSpells[i].name == spellName)
            {
                GameObject spellPrefab = playerSpells[i];
                SpellAnimationData spellData = spellPrefab.GetComponent<SpellAnimationData>();
                Vector3 spawnPosition = spellData.spawnPosition;
                playerActiveSpell = Instantiate(spellPrefab, spawnPosition, Quaternion.identity);
            }
        }
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

        if (activeSpell != null && duelManager.hasPatternArchivedOrTimeout)
        {
            if (duelManager.enemySpell != "ShieldAnimation")
            {
                activeSpell.transform.position += Vector3.right * spellSpeed * Time.deltaTime;
                if (activeSpell.transform.position.x > 634)
                {
                    SpawnPlayerSpell(duelManager.playerSpell);
                    Destroy(activeSpell);
                    activeSpell = null;
                }
            }
            else 
            {
                Destroy(activeSpell, 0.5f);
                activeSpell = null;
            }
        }
        
        if (playerActiveSpell != null)
        {
            playerActiveSpell.transform.position += Vector3.right * -spellSpeed * Time.deltaTime;
            if (playerActiveSpell.transform.position.x < 629)
            {
                Destroy(playerActiveSpell);
                playerActiveSpell = null;
            }
        }
        
        if (roundOver)
        {
            duelManager.CalculateDamage();
            enemy.TakeDamage(duelManager.enemyDamage);
            duelManager.enemyDamage = 10;
            roundOver = false;
            int randomIndex = Random.Range(0, spellPrefabs.Length);
            SpawnSpell(randomIndex);
            duelManager.SetHasPatternArchivedOrTimeout(false);
        }
    }
}
