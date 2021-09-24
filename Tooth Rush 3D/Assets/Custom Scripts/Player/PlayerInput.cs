using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerInput : MonoBehaviour
{
    //----------------------------------------------Variables-----------------------------------------------
    //Input Varialbes //Joysick 
    [SerializeField] private Joystick m_Joystick;
   

    bool m_InputStarted = false;

    float m_SwipeInpvalue = 0f;
    float m_CurrentValue = 0f;
    float m_LastValue;
    //----------------------------------------------Delegate--------------------------------------------------

    public delegate void JoystickInput(float horizontal);
    public static event JoystickInput s_OnJoystickInp_event;

    public delegate void HoldingInput(bool IsHolding);
    public static event HoldingInput s_OnHoldingInp_event;

    //----------------------------------------------Methods--------------------------------------------------
    private void Update()
    {       
        if (m_SwipeInpvalue != 0 && !m_InputStarted)
        {
            Player.ChangeState(PlayerState.Playing);

            m_InputStarted = true;
        }


        if (Input.GetMouseButton(0))
        {
            //event
            s_OnHoldingInp_event?.Invoke(true);
        }
        else if(Input.GetMouseButtonUp(0))
        {
            //event
            s_OnHoldingInp_event?.Invoke(false);
        }


        //event
        s_OnJoystickInp_event?.Invoke(m_SwipeInpvalue);

        JoyStickInput();
    }
    private void JoyStickInput()
    {
        float horizontalInput = m_Joystick.Horizontal;
    

        m_CurrentValue = horizontalInput;
        if (m_CurrentValue != m_LastValue)
        {
            m_SwipeInpvalue = m_CurrentValue;
            m_LastValue = m_CurrentValue;

        }

        else
        {
            m_CurrentValue = 0f;
            m_SwipeInpvalue = m_CurrentValue;

        }


        m_SwipeInpvalue = horizontalInput;
    }

}
