using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelUI : MonoBehaviour
{
    public string passText;
    public string deathText;
    Subscription<PassLevelEvent> passLevelSubscription;
    Subscription<DeathEvent> deathSubscription;
    Subscription<RestartEvent> restartSubscription;

    void Start()
    {
        passLevelSubscription = EventBus.Subscribe<PassLevelEvent>(_OnLevelCompletion);
        deathSubscription = EventBus.Subscribe<DeathEvent>(_OnDeath);
        restartSubscription = EventBus.Subscribe<RestartEvent>(_OnRestart);
    }

    void _OnLevelCompletion(PassLevelEvent e)
    {
        GetComponent<Text>().text = passText;
    }

    void _OnDeath(DeathEvent e)
    {
        GetComponent<Text>().text = deathText;
    }

    void _OnRestart(RestartEvent e)
    {
        GetComponent<Text>().text = "";
    }

    private void OnDestroy()
    {
        EventBus.Unsubscribe(passLevelSubscription);
    }
}
