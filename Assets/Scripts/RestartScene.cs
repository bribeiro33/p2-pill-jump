using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartScene : MonoBehaviour
{
    Subscription<PassLevelEvent> passLevelSubscription;
    Subscription<DeathEvent> deathSubscription;
    
    private bool restartNow = false;
    void Start()
    {
        passLevelSubscription = EventBus.Subscribe<PassLevelEvent>(_OnLevelCompletion);
        deathSubscription = EventBus.Subscribe<DeathEvent>(_OnDeath);
    }

    void _OnLevelCompletion(PassLevelEvent e)
    {
        restartNow = true;
    }

    void _OnDeath(DeathEvent e)
    {
        restartNow = true;
    }

    private void Update()
    {
        if (restartNow && Input.anyKeyDown)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            restartNow = false;
        }
    }

    private void OnDestroy()
    {
        EventBus.Unsubscribe(passLevelSubscription);
    }
}
