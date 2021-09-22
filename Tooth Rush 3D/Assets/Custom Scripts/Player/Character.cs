using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Character : MonoBehaviour
{
    //----------------------------------------------Variables-----------------------------------------------

    public static CharacterState s_State { private set; get; }


    //----------------------------------------------Delegate--------------------------------------------------

    public static event Action<CharacterState> s_OnStateChanged_event;

    //----------------------------------------------Methods--------------------------------------------------

    private void Start()
    {
        ChangeState(CharacterState.Idle);
    }
    public static void ChangeState(CharacterState state)
    {
        if (state != s_State)
        {
            s_State = state;

            //Event
            s_OnStateChanged_event?.Invoke(s_State);
        }  
    }

}

public enum CharacterState
{
   none,
   Idle,
   Moving
}
