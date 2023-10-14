using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowDown : MonoBehaviour
{
    public float decreaseFactor = 1.0f;
    private void OnTriggerStay(Collider other)
    {
        AutoMove autoMoveComponent = other.gameObject.GetComponent<AutoMove>();
        if (autoMoveComponent != null)
        {
            autoMoveComponent.decreaseSpeed(decreaseFactor);
        }
    }
}
