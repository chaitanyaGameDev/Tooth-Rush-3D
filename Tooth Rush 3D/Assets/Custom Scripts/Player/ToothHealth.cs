using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ToothHealth : MonoBehaviour
{
    //----------------------------------------------Variables-----------------------------------------------

    private int m_MaxHealth = 100;
    private int m_MinHealth = 0;

    public static int s_Health { private set; get; }

    

    [HideInInspector]
    public ToothAgeingConstraints m_ageConstraints;

    //----------------------------------------------Delegate--------------------------------------------------

    public static event Action s_OnHealthIncremented_event;
    public static event Action s_OnHealthDecremented_event;


    //----------------------------------------------Methods--------------------------------------------------
    private void OnEnable()
    {
        CollisionChecks.s_OnHealthyItem_Triggered_event += IncrementHealth;
        CollisionChecks.s_OnUnHealthyItem_Triggered_event += DecrementHealth;


        ToothAgeing.s_OnStateChanged_event += SetHealthOnStart;
    }
    private void OnDisable()
    {
        CollisionChecks.s_OnHealthyItem_Triggered_event -= IncrementHealth;
        CollisionChecks.s_OnUnHealthyItem_Triggered_event -= DecrementHealth;
    }
   
    //Used on interaction with items
    private void IncrementHealth(int value)
    {
        if (!ToothAgeing.s_HasGerms)
        {
            if (s_Health <= m_MaxHealth)
            {
                s_Health += value;
            }

            if (s_Health > m_MaxHealth)
            {
                s_Health = m_MaxHealth;
            }          
        }

        //event
        s_OnHealthIncremented_event?.Invoke();
    }
    private void DecrementHealth(int value)
    {
       
        if (s_Health >= m_MinHealth)
        {
            s_Health -= value;
        }

        if (s_Health < m_MinHealth)
        {
            s_Health = m_MinHealth;
        }

        //event
        s_OnHealthDecremented_event?.Invoke();
    }


    //Used to set health my on Start based on ToothAgeState by subscribing event and un-subscribing instantly
    //Called Only Once in Lifetime.
    private void SetHealthOnStart(ToothAgeState state)
    {
        switch (state)
        {
            case ToothAgeState.Shiny:
                s_Health = m_ageConstraints.ShinyTooth_Start;
                break;
            case ToothAgeState.Healthy:
                s_Health = m_ageConstraints.HealthyTooth_Start;
                break;
            case ToothAgeState.Germs:
                s_Health = m_ageConstraints.Germs_Start;
                break;
            case ToothAgeState.Plague1:
                s_Health = m_ageConstraints.Plague1_Start;
                break;
            case ToothAgeState.Plague2:
                s_Health = m_ageConstraints.Plague2_Start;
                break;
            case ToothAgeState.Plague3:
                s_Health = m_ageConstraints.Plague3_Start;
                break;
            case ToothAgeState.Cavity1:
                s_Health = m_ageConstraints.Cavity1_Start;
                break;
            case ToothAgeState.Cavity2:
                s_Health = m_ageConstraints.Cavity2_Start;
                break;
            case ToothAgeState.Rotten:
                s_Health = m_ageConstraints.Rotten_Start;
                break;
        }

        //Un-Subscribing
        ToothAgeing.s_OnStateChanged_event -= SetHealthOnStart;

    }








    [SerializeField] int Health;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            IncrementHealth(5);
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            DecrementHealth(5);
        }

        Health = s_Health;
    }
}