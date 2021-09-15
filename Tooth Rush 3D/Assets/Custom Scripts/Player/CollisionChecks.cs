using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MoreMountains.Tools;

public class CollisionChecks : MonoBehaviour
{
    //----------------------------------------------Variables-----------------------------------------------


    //----------------------------------------------Delegate--------------------------------------------------

    public delegate void HealthyItemTriggered(int health);
    public static event HealthyItemTriggered s_OnHealthyItem_Triggered_event;


    public delegate void UnHealthyItemTriggered(int damage);
    public static event UnHealthyItemTriggered s_OnUnHealthyItem_Triggered_event;


    public delegate void GroundEntryTriggered();
    public static event GroundEntryTriggered s_OnGroundEntry_Triggered_event;

    //----------------------------------------------Methods--------------------------------------------------
    private void OnTriggerEnter(Collider other)
    {
        //Healthy Items
        if (other.gameObject.layer == LayerMask.NameToLayer("Healthy"))
        {
            GiveHealth give = other.gameObject.GetComponent<GiveHealth>();

            //event
            s_OnHealthyItem_Triggered_event?.Invoke(give.HealthValue);
        }

        //Un_Healthy Items
        else if (other.gameObject.layer == LayerMask.NameToLayer("UnHealthy"))
        {
            GiveDamage give = other.gameObject.GetComponent<GiveDamage>();

            //event
            s_OnUnHealthyItem_Triggered_event?.Invoke(give.DamageValue);
        }

        else if (other.gameObject.layer == LayerMask.NameToLayer("Ground"))
        {
            Ground ground = other.gameObject.GetComponent<Ground>();

            //event
            s_OnGroundEntry_Triggered_event?.Invoke();
        }
    }
}
