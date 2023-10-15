using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    static int current_checkpoint = 1;
    static float cp_x = 0;

    private void Start()
    {
        cp_x = transform.position.x;
    }

    private void OnTriggerEnter(Collider other)
    {
        current_checkpoint++;
        EventBus.Publish<CheckpointEvent>(new CheckpointEvent(current_checkpoint, cp_x));
        GameManager.Instance.SetLastCheckpointPosition(transform.position);
        gameObject.SetActive(false);
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
