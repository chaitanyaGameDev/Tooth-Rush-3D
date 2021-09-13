using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    //----------------------------------------------Variables-----------------------------------------------
    //Input Varialbes //Joysick 
   // [SerializeField] private Joystick m_Joystick;
   

    bool m_InputStarted = false;

    //----------------------------------------------Delegate--------------------------------------------------

    public delegate void JoystickInput(float horizontal, float vertical);
    public static event JoystickInput s_OnJoystickInp_event;

    //----------------------------------------------Methods--------------------------------------------------
    private void Update()
    {       
       /* if (m_SwipeInpvalue != 0 && !m_InputStarted)
        {
           
            m_InputStarted = true;
        }*/


        
        JoyStickInput();
    }
    private void JoyStickInput()
    {
      //  float horizontalInput = m_Joystick.Horizontal;
       // float verticalInput = m_Joystick.Vertical;
       

      //  s_OnJoystickInp_event?.Invoke(horizontalInput,verticalInput);
    }

}
