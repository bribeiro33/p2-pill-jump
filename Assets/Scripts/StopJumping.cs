using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopJumping : MonoBehaviour
{
    public float secondsNoJump = 10f;
    private void OnTriggerStay(Collider other)
    {
        Jump jump = other.GetComponent<Jump>();
        if (jump != null)
        {
            //
        }
    }
}
