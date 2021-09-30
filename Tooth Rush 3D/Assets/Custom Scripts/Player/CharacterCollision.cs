using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MoreMountains.Feedbacks;
using System;

public class CharacterCollision : MonoBehaviour
{
    //----------------------------------------------Variables-----------------------------------------------


    //----------------------------------------------Delegate--------------------------------------------------

    public delegate void HealthyItemTriggered(GiveHealth giveHealth);
    public static event HealthyItemTriggered s_OnToothBrush_Triggered_event;
    public static event Action s_OnToothPaste_Triggered_event;

    public delegate void UnHealthyItemTriggered(int damage);
    public static event UnHealthyItemTriggered s_OnUnHealthyItem_Triggered_event;
    public static event Action s_OnUnHealth_Triggered_event;


    //----------------------------------------------MMFeedbacks--------------------------------------------------


    [SerializeField] MMFeedbacks m_CoinCollect_FB;
    [SerializeField] MMFeedbacks m_FoodCollect_FB;
    [SerializeField] MMFeedbacks m_ToothPasteCollect_FB;   
    [SerializeField] MMFeedbacks m_LevelCompleted_FB;

    //----------------------------------------------Methods--------------------------------------------------
    private void OnTriggerEnter(Collider other)
    {
        //Healthy Items
        if (other.gameObject.layer == LayerMask.NameToLayer("Healthy"))
        {
            GiveHealth giveHealth = other.gameObject.GetComponent<GiveHealth>();
            Healthy healthy = other.gameObject.GetComponent<Healthy>();


            switch (healthy.ItemType)
            {
                case HealthyItemType.ToothPaste:

                    Destroy(other.gameObject);

                    //event
                    s_OnToothPaste_Triggered_event?.Invoke();


                    //Manager Updates
                    ScoreManager.Instance.UpdateScore(ScoreManager.ToothPaste_Score);


                    m_ToothPasteCollect_FB.PlayFeedbacks();

                    break;



                case HealthyItemType.ToothBrushing:

                    if (ToothBody.s_HasToothPasteGel)
                    {
                        ItemToothBrush toothBrush = other.gameObject.GetComponent<ItemToothBrush>();
                        toothBrush.EnableFoamParticles();
                    }

                    Destroy(other.GetComponent<Collider>());
                    //event
                    s_OnToothBrush_Triggered_event?.Invoke(giveHealth);

                    break;
            }


        }
        //Un_Healthy Items
        else if (other.gameObject.layer == LayerMask.NameToLayer("UnHealthy"))
        {
            GiveDamage give = other.gameObject.GetComponent<GiveDamage>();


            //Feedback
            m_FoodCollect_FB.PlayFeedbacks();


            Destroy(other.gameObject);

            //event
            s_OnUnHealthyItem_Triggered_event?.Invoke(give.DamageValue);
            s_OnUnHealth_Triggered_event?.Invoke();
        }


        //Coin
        else if (other.gameObject.CompareTag("Coin"))
        {

            MMFeedbackParticlesInstantiation particlesInstantiation = m_CoinCollect_FB.gameObject.GetComponent<MMFeedbackParticlesInstantiation>();
            particlesInstantiation.TargetWorldPosition = other.gameObject.transform.position;

            //Feedback
            m_CoinCollect_FB.PlayFeedbacks();

            Destroy(other.gameObject);



            //Manager Update
            ScoreManager.Instance.UpdateScore(ScoreManager.Coin_Score);
            CoinManager.Instance.UpdateCoins(CoinManager.PerPiece_Coin);
        }


        //Finish
        else if (other.gameObject.CompareTag("Finish"))
        {
            Player.ChangeState(PlayerState.LevelCompleted);
            Character.ChangeState(CharacterState.Victory);

            //Feedback
            m_LevelCompleted_FB.PlayFeedbacks();
        }
    }
}