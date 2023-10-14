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

    void Start()
    {
        passLevelSubscription = EventBus.Subscribe<PassLevelEvent>(_OnLevelCompletion);
        deathSubscription = EventBus.Subscribe<DeathEvent>(_OnDeath);
    }

    void _OnLevelCompletion(PassLevelEvent e)
    {
        GetComponent<Text>().text = passText;
    }

    void _OnDeath(DeathEvent e)
    {
        GetComponent<Text>().text = deathText;
    }

    private void OnDestroy()
    {
        EventBus.Unsubscribe(passLevelSubscription);
    }
}
