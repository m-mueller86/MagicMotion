using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndPointTrigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("ErrorDetectionBall"))
        {
            Debug.Log("Pattern achieved");
        }
    }
}
