using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ToothAgeing : MonoBehaviour
{
    //----------------------------------------------Variables-----------------------------------------------

    [SerializeField] ToothAgeState m_Start_State;

    public static ToothAgeState s_CurrentState { private set; get; }
    public static ToothAgeState s_PreviousState { private set; get;}

    [HideInInspector]
    public ToothAgeingConstraints m_ageConstraints;


    public static bool s_HasGerms;

    //----------------------------------------------Delegate--------------------------------------------------

    public static event Action<ToothAgeState> s_OnStateChanged_event;

    //----------------------------------------------Methods--------------------------------------------------
    private void Start()
    {

        if (m_Start_State == ToothAgeState.Shiny || m_Start_State == ToothAgeState.Healthy)
        {
            s_HasGerms = false;
        }
        else
        {
            s_HasGerms = true ;
        }

        ChangeState(m_Start_State);
   
    }
    private void OnEnable()
    {
        ToothHealth.s_OnHealthIncremented_event += CheckAndChangeState_OnHealthIncremented;
        ToothHealth.s_OnHealthDecremented_event += CheckAndChangeState_OnHealthDecremented;
    }
    private void OnDisable()
    {
        ToothHealth.s_OnHealthIncremented_event -= CheckAndChangeState_OnHealthIncremented;
        ToothHealth.s_OnHealthDecremented_event -= CheckAndChangeState_OnHealthDecremented;
    }


    private void CheckAndChangeState_OnHealthIncremented()
    {

        if (s_HasGerms)
        {
            s_HasGerms = false;
        }


        if (ToothHealth.s_Health <= m_ageConstraints.ShinyTooth_Start && ToothHealth.s_Health >= m_ageConstraints.ShinyTooth_End)
        {
            ChangeState(ToothAgeState.Shiny);
        }

        else if (ToothHealth.s_Health <= m_ageConstraints.HealthyTooth_Start && ToothHealth.s_Health >= m_ageConstraints.HealthyTooth_End)
        {
            ChangeState(ToothAgeState.Healthy);
        }

        else if (ToothHealth.s_Health <= m_ageConstraints.Germs_Start && ToothHealth.s_Health >= m_ageConstraints.Germs_End)
        {
            ChangeState(ToothAgeState.Germs);

        }

        else if (ToothHealth.s_Health <= m_ageConstraints.Plague1_Start && ToothHealth.s_Health >= m_ageConstraints.Plague1_End)
        {
            ChangeState(ToothAgeState.Plague1);
        }

        else if (ToothHealth.s_Health <= m_ageConstraints.Plague2_Start && ToothHealth.s_Health >= m_ageConstraints.Plague2_End)
        {
            ChangeState(ToothAgeState.Plague2);
        }

        else if (ToothHealth.s_Health <= m_ageConstraints.Plague3_Start && ToothHealth.s_Health >= m_ageConstraints.Plague3_End)
        {
            ChangeState(ToothAgeState.Plague3);
        }

        else if (ToothHealth.s_Health <= m_ageConstraints.Cavity1_Start && ToothHealth.s_Health >= m_ageConstraints.Cavity1_End)
        {
            ChangeState(ToothAgeState.Cavity1);
        }

        else if (ToothHealth.s_Health <= m_ageConstraints.Cavity2_Start && ToothHealth.s_Health >= m_ageConstraints.Cavity2_End)
        {
            ChangeState(ToothAgeState.Cavity2);
        }

        else if (ToothHealth.s_Health <= m_ageConstraints.Rotten_Start && ToothHealth.s_Health >= m_ageConstraints.Rotten_End)
        {
            ChangeState(ToothAgeState.Rotten);
        }

        

    }
    private void CheckAndChangeState_OnHealthDecremented()
    {

        if (s_PreviousState != ToothAgeState.Shiny)
        {
            s_HasGerms = true;
        }


        if (ToothHealth.s_Health <= m_ageConstraints.ShinyTooth_Start && ToothHealth.s_Health >= m_ageConstraints.ShinyTooth_End)
        {
            ChangeState(ToothAgeState.Shiny);
        }

        else if (ToothHealth.s_Health <= m_ageConstraints.HealthyTooth_Start && ToothHealth.s_Health >= m_ageConstraints.HealthyTooth_End)
        {
            ChangeState(ToothAgeState.Healthy);
        }

        else if (ToothHealth.s_Health <= m_ageConstraints.Germs_Start && ToothHealth.s_Health >= m_ageConstraints.Germs_End)
        {

            s_HasGerms = true;
            ChangeState(ToothAgeState.Germs);
            
        }

       
        if (ToothHealth.s_Health <= m_ageConstraints.Plague1_Start && ToothHealth.s_Health >= m_ageConstraints.Plague1_End)
        {
            ChangeState(ToothAgeState.Plague1);
        }

        else if (ToothHealth.s_Health <= m_ageConstraints.Plague2_Start && ToothHealth.s_Health >= m_ageConstraints.Plague2_End)
        {
            ChangeState(ToothAgeState.Plague2);
        }

        else if (ToothHealth.s_Health <= m_ageConstraints.Plague3_Start && ToothHealth.s_Health >= m_ageConstraints.Plague3_End)
        {
            ChangeState(ToothAgeState.Plague3);
        }

        else if (ToothHealth.s_Health <= m_ageConstraints.Cavity1_Start && ToothHealth.s_Health >= m_ageConstraints.Cavity1_End)
        {
            ChangeState(ToothAgeState.Cavity1);
        }

        else if (ToothHealth.s_Health <= m_ageConstraints.Cavity2_Start && ToothHealth.s_Health >= m_ageConstraints.Cavity2_End)
        {
            ChangeState(ToothAgeState.Cavity2);
        }

        else if (ToothHealth.s_Health <= m_ageConstraints.Rotten_Start && ToothHealth.s_Health >= m_ageConstraints.Rotten_End)
        {
            ChangeState(ToothAgeState.Rotten);
        }
 
    }

    public void ChangeState(ToothAgeState state)
    {
        s_PreviousState = s_CurrentState;

        s_CurrentState = state;


       
        //event
        s_OnStateChanged_event?.Invoke(s_CurrentState);     

    }

}
public enum ToothAgeState
{
    none,
    Shiny,
    Healthy,
    Germs,
    Plague1,
    Plague2,
    Plague3,
    Cavity1,
    Cavity2,
    Rotten
}
[System.Serializable]
public class ToothAgeingConstraints
{
    public readonly int ShinyTooth_Start = 100;
    public readonly int ShinyTooth_End = 90;

    public readonly int HealthyTooth_Start = 89;
    public readonly int HealthyTooth_End = 80;

    public readonly int Germs_Start = 79;
    public readonly int Germs_End = 70;

    public readonly int Plague1_Start = 69;
    public readonly int Plague1_End= 60;

    public readonly int Plague2_Start = 59;
    public readonly int Plague2_End= 50;

    public readonly int Plague3_Start = 49;
    public readonly int Plague3_End = 40;

    public readonly int Cavity1_Start = 39;
    public readonly int Cavity1_End = 30;

    public readonly int Cavity2_Start = 29;
    public readonly int Cavity2_End = 15;

    public readonly int Rotten_Start = 14;
    public readonly int Rotten_End = 0;

}