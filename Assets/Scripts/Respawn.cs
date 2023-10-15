using UnityEngine;

public class Respawn : MonoBehaviour
{
    private static Respawn instance;
    public static Respawn Instance { get { return instance; } }

    private Vector3 respawnPosition; // Stores the respawn position
    private AutoMove movement;

    private void Awake()
    {
        // Ensure there is only one instance of PlayerController
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    private void Start()
    {
       movement = GetComponent<AutoMove>();
    }

    // Method to set the respawn position
    public void SetRespawnPosition(Vector3 position)
    {
        respawnPosition = position;
    }

    // Method to respawn the player at the stored respawn position
    public void Respawner()
    {
        // Set the player's position to the respawn position
        transform.position = respawnPosition;
        // Let it move again
        gameObject.SetActive(true);
        movement.enabled = true;
    }
}
