using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatternSpawner : MonoBehaviour
{

    [SerializeField] private GameObject[] patterns;
    [SerializeField] private GameObject errorDetectionBall;
    [SerializeField] private GameObject endPoint;
    
    public void SpawnPattern(int patternIndex)
    {
        GameObject patternPrefab = patterns[patternIndex];
        SpawnPositionSaver spawnPositionSaver = patternPrefab.GetComponent<SpawnPositionSaver>();
        Instantiate(patternPrefab, spawnPositionSaver.spawnPosition, Quaternion.identity);
        Instantiate(errorDetectionBall, spawnPositionSaver.errorDetectionBallStartPosition, Quaternion.identity);
        Instantiate(endPoint, spawnPositionSaver.endPointPosition, Quaternion.identity);
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
