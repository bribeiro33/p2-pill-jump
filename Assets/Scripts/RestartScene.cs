using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartScene : MonoBehaviour
{
    public Transform player_position;
    public static RestartScene Instance;

    private Vector3 player_restart_location = Vector3.zero;

    Subscription<PassLevelEvent> passLevelSubscription;
    Subscription<DeathEvent> deathSubscription;
    Subscription<CheckpointEvent> checkpointSubscription;
    
    private bool restartNow = false;

    private void Awake()
    {
        // Ensure only one instance of the GameManager exists
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        passLevelSubscription = EventBus.Subscribe<PassLevelEvent>(_OnLevelCompletion);
        deathSubscription = EventBus.Subscribe<DeathEvent>(_OnDeath);
        checkpointSubscription = EventBus.Subscribe<CheckpointEvent>(_OnCheckpointReached);
    }

    void _OnCheckpointReached(CheckpointEvent e)
    {
        player_restart_location = new Vector3(e.checkpoint_x, player_position.position.y,  player_position.position.z);
        Debug.Log("new checkpoint: " +  player_restart_location);
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
            //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            Vector3 respawnPosition = GameManager.Instance.GetLastCheckpointPosition();
            Respawn.Instance.SetRespawnPosition(respawnPosition);
            //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            Respawn.Instance.Respawner();
            EventBus.Publish<RestartEvent>(new RestartEvent());
            //player_position.position = player_restart_location;
            restartNow = false;
        }
    }

    private void OnDestroy()
    {
        EventBus.Unsubscribe(passLevelSubscription);
    }
}

public class RestartEvent
{
    public RestartEvent() { }
}