using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndLevel : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<PlayerCollisions>() != null)
        {
            EventBus.Publish<PassLevelEvent>(new PassLevelEvent());
            // Disable player
            other.gameObject.SetActive(false);

        }
    }


}
public class PassLevelEvent
{
    public PassLevelEvent()
    {

    }
}