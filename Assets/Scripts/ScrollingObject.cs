using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingObject : MonoBehaviour
{
    public float scrollSpeed = 1.0f;
    private Rigidbody rb;
    private bool shouldScroll = true;

    Subscription<DeathEvent> death_event_sub;

    // Start is called before the first frame update
    void Start()
    {
        /*rb = GetComponent<Rigidbody>();
        rb.velocity = new Vector3(scrollSpeed, 0, 0);*/

        death_event_sub = EventBus.Subscribe<DeathEvent>(_OnDeath);
    }

    private void Update()
    {
        if (shouldScroll)
            transform.position += Vector3.right * scrollSpeed * Time.deltaTime;
    }

    void _OnDeath(DeathEvent e){
        //rb.velocity = Vector3.zero;
        shouldScroll = false;
    }

    private void OnDestroy()
    {
        EventBus.Unsubscribe(death_event_sub);
    }
}
