using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    //----------------------------------------------Delegate--------------------------------------------------

    public delegate void GroundEntryTriggered(List<Transform> pathPoints);
    public static event GroundEntryTriggered s_OnGroundEntry_Triggered_event;


    //----------------------------------------------Methods--------------------------------------------------
    private void OnTriggerEnter(Collider other)
    {
       
        if (other.gameObject.layer == LayerMask.NameToLayer("Ground"))
        {
            Ground ground = other.gameObject.GetComponent<Ground>();

            //event
            s_OnGroundEntry_Triggered_event?.Invoke(ground.PathCreator.PathPoints);
        }
    }
}
