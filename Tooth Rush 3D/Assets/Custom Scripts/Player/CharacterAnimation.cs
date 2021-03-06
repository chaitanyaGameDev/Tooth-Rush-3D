using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CharacterAnimation : MonoBehaviour
{
    //----------------------------------------------Variables-----------------------------------------------


    private Character m_MyCharacter;

    private Animator m_Animator;

    //----------------------------------------------Methods--------------------------------------------------
   
    private void Start()
    {
        m_Animator = GetComponentInChildren<Animator>();
       


        //events
        Character.s_OnStateChanged_event += CheckCharacterState;
    }
    private void OnDisable()
    {
        //events
        Character.s_OnStateChanged_event -= CheckCharacterState;
    }
    private void CheckCharacterState(CharacterState state) 
    {
        switch (state)
        {
            case CharacterState.Idle:
                m_Animator.SetBool("Moving", false);

                break;

            case CharacterState.Moving:
                m_Animator.SetBool("Moving", true);
                m_Animator.SetBool("Brushing", false);
                break;
           
            case CharacterState.Brushing:
                m_Animator.SetBool("Brushing", true);   
                break;

            case CharacterState.Death:
                m_Animator.SetTrigger("Death");
                break;

            case CharacterState.Victory:
                m_Animator.SetTrigger("Victory");
                break;
        }
    }
}