using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSideRotation : MonoBehaviour
{

    [Header("TurnRotation")]
    [SerializeField] float m_RotationValue;
    [SerializeField] float m_RotationLerp;

    private float m_SwipeValue;


    //----------------------------------------------Methods--------------------------------------------------

    private void OnEnable()
    {
        PlayerInput.s_OnJoystickInp_event += SetSwipeValue;
    }
    private void OnDisable()
    {
        PlayerInput.s_OnJoystickInp_event -= SetSwipeValue;
    }

    private void Update()
    {
        if (Character.s_State == CharacterState.Idle || Character.s_State == CharacterState.Moving)
        {
            SideTurnRotation();
        }    
    }

    private void SideTurnRotation()
    {
        if (m_SwipeValue > 0f)
        {
            Quaternion rotationVec = Quaternion.Euler(0f, m_RotationValue, 0f);
            transform.localRotation = Quaternion.Lerp(transform.localRotation, rotationVec, m_RotationLerp * Time.deltaTime);
        }
        if (m_SwipeValue < 0f)
        {
            Quaternion rotationVec = Quaternion.Euler(0f, -m_RotationValue, 0f);
            transform.localRotation = Quaternion.Lerp(transform.localRotation, rotationVec, m_RotationLerp * Time.deltaTime);
        }
        if (m_SwipeValue == 0f)
        {
            Quaternion rotationVec = Quaternion.Euler(0f, m_RotationValue, 0f);
            transform.localRotation = Quaternion.Lerp(transform.localRotation, Quaternion.identity, m_RotationLerp * Time.deltaTime);
        }
    }

    private void SetSwipeValue(float value)
    {
        m_SwipeValue = value;
    }
}
