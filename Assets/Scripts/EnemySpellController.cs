using UnityEngine;

public class EnemySpellController : MonoBehaviour
{
    public GameObject[] spellPrefabs;

    
    public void SpawnSpell(int spellIndex)
    {
        GameObject spellPrefab = spellPrefabs[spellIndex];
        SpellAnimationData spellData = spellPrefab.GetComponent<SpellAnimationData>();
        Vector3 spawnPosition = spellData.spawnPosition;
        Instantiate(spellPrefab, spawnPosition, Quaternion.identity);
    }

    void Start()
    {
        SpawnSpell(3);
    }
}