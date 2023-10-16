using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    private int current_checkpoint = 1;
    private float cp_x = 0;

    private void Start()
    {
        cp_x = transform.position.x;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<PlayerCollisions>() != null)
        {
            current_checkpoint++;
            if (this.GetComponent<EndLevel>() != null)
            {
                cp_x = -8.71f;
            }
            EventBus.Publish<CheckpointEvent>(new CheckpointEvent(current_checkpoint, cp_x));
            Vector3 checkpointVec = new Vector3(cp_x, 1.5f, -1.26f);
            GameManager.Instance.SetLastCheckpointPosition(checkpointVec);
            gameObject.SetActive(false);
        }
        
    }
}

public class CheckpointEvent
{
    public int checkpoint_num = 1;
    public float checkpoint_x = 0;
    public CheckpointEvent(int current_checkpoint, float cp_x)
    {
        this.checkpoint_num = current_checkpoint;
        this.checkpoint_x = cp_x;
    }
}
