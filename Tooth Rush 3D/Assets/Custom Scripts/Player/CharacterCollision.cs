using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MoreMountains.Feedbacks;


public class CharacterCollision : MonoBehaviour
{
    //----------------------------------------------Variables-----------------------------------------------


    //----------------------------------------------Delegate--------------------------------------------------

    public delegate void HealthyItemTriggered(int health);
    public static event HealthyItemTriggered s_OnHealthyItem_Triggered_event;


    public delegate void UnHealthyItemTriggered(int damage);
    public static event UnHealthyItemTriggered s_OnUnHealthyItem_Triggered_event;


    //----------------------------------------------MMFeedbacks--------------------------------------------------

    [SerializeField] MMFeedbacks m_Mouthwash_Collect_FB;

    //----------------------------------------------Methods--------------------------------------------------
    private void OnTriggerEnter(Collider other)
    {
        //Healthy Items
        if (other.gameObject.layer == LayerMask.NameToLayer("Healthy"))
        {
            GiveHealth give = other.gameObject.GetComponent<GiveHealth>();
            Healthy healthy = other.gameObject.GetComponent<Healthy>();

            //Mouthwash
            if (healthy.ItemType == HealthyItemType.Mouthwash)
            {

              //  MMFeedbackParticlesInstantiation particlesInstantiation = m_Mouthwash_Collect_FB.GetComponent<MMFeedbackParticlesInstantiation>();
             //   particlesInstantiation.Offset = other.gameObject.transform.position + new Vector3(0f,0.75f,0.5f);
                m_Mouthwash_Collect_FB.PlayFeedbacks();
            }
           




            Destroy(other.gameObject);

            //event
            s_OnHealthyItem_Triggered_event?.Invoke(give.HealthValue);

        }

        //Un_Healthy Items
        else if (other.gameObject.layer == LayerMask.NameToLayer("UnHealthy"))
        {
            GiveDamage give = other.gameObject.GetComponent<GiveDamage>();


            Destroy(other.gameObject);

            //event
            s_OnUnHealthyItem_Triggered_event?.Invoke(give.DamageValue);
        }


        //Gem

        else if (other.gameObject.CompareTag("Gem"))
        {
            Destroy(other.gameObject);
        }
    }
}
