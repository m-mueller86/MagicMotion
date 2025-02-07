using System.IO.Ports;
using UnityEngine;

public class PatternSpawner : MonoBehaviour
{

    [SerializeField] private GameObject[] patterns;
    public DuelManager duelManager;
    private GameObject activePattern;
    
    // Start is called before the first frame update
    void Start()
    {
    }
    
    public void SpawnPattern(int patternIndex)
    {
        GameObject patternPrefab = patterns[patternIndex];
        SpawnPositionSaver spawnPositionSaver = patternPrefab.GetComponent<SpawnPositionSaver>();
        activePattern = Instantiate(patternPrefab, spawnPositionSaver.spawnPosition, spawnPositionSaver.spawnRotation);
    }
    
    // Update is called once per frame
    void Update()
    {
        if (duelManager.hasPlayerChosenCounterSpell)
        {
            if (duelManager.playerSpell == "FireballAnimationPlayer")
            {
                SpawnPattern(2);
            } else if(duelManager.playerSpell == "LightningAnimationPlayer")
            {
                SpawnPattern(3);
            } else if(duelManager.playerSpell == "LeafSwordAnimationPlayer")
            {
                SpawnPattern(1);
            }
            duelManager.SetPlayerChosenCounterSpell(false);
        }
        
        if (duelManager.hasPatternArchivedOrTimeout)
        {
            Destroy(activePattern);
        }
         
    }
}
