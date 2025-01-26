using UnityEngine;

public class EndPointTrigger : MonoBehaviour
{
    public DuelManager duelManager;
    
    private void OnTriggerEnter(Collider other)
    {
        
        if (other.gameObject.CompareTag("ErrorDetectionBall"))
        {
            duelManager.SetHasPatternArchivedOrTimeout(true);
        }
    }
}
