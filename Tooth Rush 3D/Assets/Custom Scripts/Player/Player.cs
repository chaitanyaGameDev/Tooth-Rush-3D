using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Player : MonoBehaviour
{
    //----------------------------------------------Variables-----------------------------------------------

    public static PlayerState s_State { private set; get;}

    //----------------------------------------------Delegate--------------------------------------------------

    public static event Action<PlayerState> s_OnStateChanged_event;

    //----------------------------------------------Methods--------------------------------------------------
    
    private void Start()
    {
        ChangeState(PlayerState.WaitingForInput);
    }
    public static void ChangeState(PlayerState state)
    {
        s_State = state;

        //Event
        s_OnStateChanged_event?.Invoke(s_State);
    }
}

public enum PlayerState
{
    WaitingForInput,
    Playing,
    LevelCompleted,
    LevelFailed
}
