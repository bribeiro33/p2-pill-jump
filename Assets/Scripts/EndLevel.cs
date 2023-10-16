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
            Vector3 startingLocation = new Vector3(-8.71f, 1.76f, -1.26f);
            Respawn.Instance.SetRespawnPosition(startingLocation);

        }
    }


}
public class PassLevelEvent
{
    public PassLevelEvent()
    {

    }
}