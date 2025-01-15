using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatternSpawner : MonoBehaviour
{

    [SerializeField] private GameObject[] patterns;
   
    
    public void SpawnPattern(int patternIndex)
    {
        GameObject patternPrefab = patterns[patternIndex];
        SpawnPositionSaver spawnPositionSaver = patternPrefab.GetComponent<SpawnPositionSaver>();
        Instantiate(patternPrefab, spawnPositionSaver.spawnPosition, spawnPositionSaver.spawnRotation);
    }
    
    // Start is called before the first frame update
    void Start()
    {
        SpawnPattern(3);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
