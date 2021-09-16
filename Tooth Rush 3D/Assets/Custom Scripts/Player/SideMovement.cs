using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SideMovement : MonoBehaviour
{
    //----------------------------------------------Variables-----------------------------------------------
    private float m_SwipeValue;

    [Header("Movement")]
    [SerializeField] float m_Xclamp;
    [SerializeField] float m_SideMoveSpeed;
    [Header("TurnRotation")]
    [SerializeField] float m_RotationValue;
    [SerializeField] float m_RotationLerp;

    public static bool s_IsForwardBlocking;

   

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
        MoveSides();
    }

    private void MoveSides()
    {

        Vector3 sideVec = new Vector3(m_SwipeValue,0f,0f);

        // transform.localPosition += new Vector3(m_SwipeValue * m_SideMoveSpeed * Time.deltaTime,0f, 0f);
        transform.localPosition += sideVec * m_SideMoveSpeed * Time.deltaTime;


        if (this.transform.localPosition.x > m_Xclamp)
        {
            transform.localPosition = new Vector3(m_Xclamp,transform.localPosition.y, 0f);
        }
        if (this.transform.localPosition.x < -m_Xclamp)
        {
            transform.localPosition = new Vector3(-m_Xclamp,transform.localPosition.y, 0f);
        } 
    }
    private void CenterCharacter()
    {
        transform.localPosition = Vector3.Lerp(transform.localPosition,Vector3.zero,5f * Time.deltaTime);
        transform.localRotation = Quaternion.Lerp(transform.localRotation, Quaternion.identity, m_RotationLerp * Time.deltaTime);
    }

    private void SideTurnRotation()
    {
        if (m_SwipeValue > 0f)
        {
            Quaternion rotationVec = Quaternion.Euler(0f, m_RotationValue, 0f);
            transform.localRotation = Quaternion.Lerp(transform.localRotation,rotationVec, m_RotationLerp * Time.deltaTime);
        }
        if (m_SwipeValue < 0f)
        {
            Quaternion rotationVec = Quaternion.Euler(0f,-m_RotationValue, 0f);
            transform.localRotation = Quaternion.Lerp(transform.localRotation,rotationVec,m_RotationLerp * Time.deltaTime);
        }
        if (m_SwipeValue == 0f)
        {
            Quaternion rotationVec = Quaternion.Euler(0f, m_RotationValue, 0f);
            transform.localRotation = Quaternion.Lerp(transform.localRotation,Quaternion.identity,m_RotationLerp * Time.deltaTime);
        }    
    }

    private void SetSwipeValue(float value)
    {
        m_SwipeValue = value;
    }
    private void ResetRotation()
    {
        transform.rotation = Quaternion.Lerp(transform.rotation,Quaternion.identity,5f * Time.deltaTime);
    }




    /// <summary>
    /// Used stop forward movement when blocked by blocker
    /// </summary>


    [Header("Raycasting")]
    [SerializeField] Transform m_RunningRayOrigin;
    [SerializeField] float m_RayDist;

    private Ray m_RunningForwardRay;
    private RaycastHit m_RunningForwardRaycastHit;
    [SerializeField] LayerMask m_BlockerLayermask;

    
    //RayCasting
    private void RaycastCheck()
    {
        m_RunningForwardRay.origin = m_RunningRayOrigin.position;
        m_RunningForwardRay.direction = Vector3.forward;

        //Check Only on Obstacle Layer
        if (Physics.Raycast(m_RunningForwardRay, out m_RunningForwardRaycastHit, m_RayDist, m_BlockerLayermask))
        {

            s_IsForwardBlocking = true;
        }
        else
        {
            s_IsForwardBlocking = false;
        }

    }
    private void OnDrawGizmos()
    {
        if (m_RunningRayOrigin != null)
        {
            Gizmos.color = Color.blue;
            Gizmos.DrawLine(m_RunningRayOrigin.transform.position, m_RunningRayOrigin.position + Vector3.forward * (m_RayDist));
        }
    }
}

