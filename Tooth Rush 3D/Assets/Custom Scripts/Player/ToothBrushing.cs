using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using MoreMountains.Feedbacks;
using Random = UnityEngine.Random;
using TMPro;

public class ToothBrushing : MonoBehaviour
{
    //----------------------------------------------Variables-----------------------------------------------
    private float m_BrushingTime = 1.75f;

    //----------------------------------------------MMFeedbacks--------------------------------------------------

   
    [SerializeField] List<String> m_BrushComplete_Strings;
    private string m_Selected_String;

    [SerializeField] MMFeedbacks m_BrushComplete_FB;

    [SerializeField] Animator m_FloatingTextAnimator;
    [SerializeField] TextMeshProUGUI m_FloatingText;

    //----------------------------------------------Delegate--------------------------------------------------
    public static event Action s_OnBrushingStarted_event;
    public static event Action<int> s_OnBrushingComplete_event;

    //----------------------------------------------Methods--------------------------------------------------

    private void OnEnable()
    {
        CharacterCollision.s_OnToothBrush_Triggered_event += DoBrushing;
    }
    private void OnDisable()
    {
        CharacterCollision.s_OnToothBrush_Triggered_event -= DoBrushing;
    }


    private void DoBrushing(GiveHealth giveHealth)
    {
        int healthToGive = 0;

        if (ToothBody.s_HasToothPasteGel)
        {
            healthToGive = giveHealth.MaxHealth;

            //Manager Update
            ScoreManager.Instance.UpdateScore(ScoreManager.Brushing_Score);
        }
        else
        {
            healthToGive = giveHealth.MinHealth;
        }


        //event
        s_OnBrushingStarted_event?.Invoke();

        Character.ChangeState(CharacterState.Brushing);
        StartCoroutine(Brushing(healthToGive));
    }

    private IEnumerator Brushing(int healthToGive)
    {
        yield return new WaitForSeconds(m_BrushingTime);

        Character.ChangeState(CharacterState.Moving);


        //event
        s_OnBrushingComplete_event?.Invoke(healthToGive);



        //This is Floating text code 
        if (healthToGive > 0)
        {
            //Feedback
            int randomIndex = Random.Range(0, m_BrushComplete_Strings.Count);


            if (m_BrushComplete_Strings[randomIndex] != null)
            {
                m_FloatingText.text = m_BrushComplete_Strings[randomIndex];
                m_FloatingTextAnimator.SetTrigger("Zoom");
            }
        }
       
        //Feedback
        m_BrushComplete_FB.PlayFeedbacks();
    }

}
