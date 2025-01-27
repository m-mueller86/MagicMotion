using UnityEngine;

public class CollisionControl : MonoBehaviour
{
    private int collisionCount = 0;
    private float collisionTime = 0f; 
    private bool isColliding = false; 
    public DuelManager duelManager;

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Border"))
        {
            collisionCount++;
            isColliding = true;
        }
    }

    private void OnCollisionStay(Collision other)
    {
        if (other.gameObject.CompareTag("Border") && isColliding)
        {
            collisionTime += Time.deltaTime;
        }
    }

    private void OnCollisionExit(Collision other)
    {
        if (other.gameObject.CompareTag("Border"))
        {
            isColliding = false;
        }
    }

    private void Update()
    {
        float accuracy = 100f - (collisionCount * 2f + collisionTime * 10f); 
        accuracy = Mathf.Clamp(accuracy, 0f, 100f); 
        duelManager.SetAccuracy(accuracy);
    }
}