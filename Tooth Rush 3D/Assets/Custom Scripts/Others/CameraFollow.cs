using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public class CameraFollow : MonoBehaviour
{
    //----------------------------------------------Variables-----------------------------------------------
    [Header("Follow")]    
    [SerializeField] Vector3 m_Offset;
    [Range(0.1f, 1f)] [SerializeField] float m_SmoothSpeed;
    [SerializeField] float m_XClamp;
    private Transform m_Target;
    private Vector3 m_velocity = Vector3.zero;


    [SerializeField] bool m_FollowLocal;
    [SerializeField] bool m_FollowXaxis;
     bool m_StopYFollow;

    //----------------------------------------------Actions--------------------------------------------------

    public static Action<Transform> s_AddCameraTarget;

    //----------------------------------------------Methods--------------------------------------------------

    private void OnEnable()
    {
        s_AddCameraTarget += SetCameraTarget;
        
    }
    private void OnDisable()
    {
        s_AddCameraTarget -= SetCameraTarget;
       
    }

  
    void FixedUpdate()
    {

        if (m_Target != null)
        {
            CameraFollowTarget();
            ClampXMovement();
        }
    }
    private void CameraFollowTarget()
    {
        if (!m_FollowLocal)
        {
            Vector3 desiredPosition = m_Target.position + m_Offset;

            if (!m_FollowXaxis)
            {
                desiredPosition.x = transform.position.x;
            }



           //Stopes Y axis Follow
            if (m_StopYFollow)
            {
                desiredPosition.y = transform.position.y;
            }


            transform.position = Vector3.SmoothDamp(transform.position, desiredPosition, ref m_velocity, m_SmoothSpeed);
        }

        if (m_FollowLocal)
        {
            
            Vector3 desiredPosition = m_Target.localPosition + m_Offset;

            if (!m_FollowXaxis)
            {
                desiredPosition.x = transform.position.x;
            }

            transform.localPosition = Vector3.SmoothDamp(transform.localPosition, desiredPosition, ref m_velocity, m_SmoothSpeed);
        }
       
    }
    private void ClampXMovement()
    {
        if (!m_FollowLocal)
        {
            if (transform.position.x < -m_XClamp)
            {
                transform.position = new Vector3(-m_XClamp, transform.position.y, transform.position.z);
            }

            if (transform.position.x > m_XClamp)
            {
                transform.position = new Vector3(m_XClamp, transform.position.y, transform.position.z);
            }
        }


        if (m_FollowLocal)
        {
            if (transform.localPosition.x < -m_XClamp)
            {
                transform.localPosition = new Vector3(-m_XClamp, transform.localPosition.y, transform.localPosition.z);
            }

            if (transform.localPosition.x > m_XClamp)
            {
                transform.localPosition = new Vector3(m_XClamp, transform.localPosition.y, transform.localPosition.z);
            }
        }


    }

   
    private void SetCameraTarget(Transform transform)
    {
        m_Target = transform;
    }

  
}
