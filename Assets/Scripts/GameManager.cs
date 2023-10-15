using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance; // Singleton instance

    private Vector3 lastCheckpointPosition; // Stores the last activated checkpoint's position

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

    // Method to set the last activated checkpoint's position
    public void SetLastCheckpointPosition(Vector3 position)
    {
        //Debug.Log("Set checkpoint: " + lastCheckpointPosition);
        lastCheckpointPosition = position;
    }

    // Method to get the last activated checkpoint's position
    public Vector3 GetLastCheckpointPosition()
    {
        //Debug.Log("Return checkpoint: " +  lastCheckpointPosition);
        return lastCheckpointPosition;
    }
}
