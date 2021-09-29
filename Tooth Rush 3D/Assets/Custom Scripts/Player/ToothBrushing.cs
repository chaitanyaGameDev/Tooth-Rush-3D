using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ToothBrushing : MonoBehaviour
{
    //----------------------------------------------Variables-----------------------------------------------
    private float m_BrushingTime = 1.75f;

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
    }

}
