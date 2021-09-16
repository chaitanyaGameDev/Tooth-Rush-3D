using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerMovement : MonoBehaviour
{
    //----------------------------------------------Variables-----------------------------------------------

    [SerializeField] List<Vector3> m_MovePath = new List<Vector3>();
    private float m_MoveSpeed = 10f;
    private float m_rotationSpeed = 5f;

    private int m_CurrentPointID = 0;
    private bool m_IsPointsAvailable = false;

    private float m_accuracy = 1f;


    //----------------------------------------------Methods--------------------------------------------------
    private void OnEnable()
    {
        PlayerCollision.s_OnGroundEntry_Triggered_event += SetMovementPath;
    }
    private void OnDisable()
    {
        PlayerCollision.s_OnGroundEntry_Triggered_event -= SetMovementPath;
    }
  
    private void LateUpdate()
    {
        if (Player.s_State == PlayerState.Playing)
        {
            PathMovementAndRotation();
        }  
    }

    private void PathMovementAndRotation()
    {
        if (m_MovePath.Count > 0)
        {

            Vector3 lookAtGoal = new Vector3(m_MovePath[m_CurrentPointID].x, this.transform.position.y,
               m_MovePath[m_CurrentPointID].z);


            Vector3 direction = lookAtGoal - this.transform.position;
            this.transform.rotation = Quaternion.Slerp(this.transform.rotation, Quaternion.LookRotation(direction),
                Time.deltaTime * m_rotationSpeed);


            if (direction.magnitude < m_accuracy)
            {
                if (m_CurrentPointID < m_MovePath.Count - 1)
                {
                    m_CurrentPointID++;
                }
            }

            this.transform.position += transform.forward * m_MoveSpeed * Time.deltaTime;

        }

        else
        {
            transform.position += transform.forward * m_MoveSpeed * Time.deltaTime;
        }
    }






    //OLD
    /*   private void RotateOnPath()
       {
           Vector3 movement = m_MovePath[m_CurrentPointID] - transform.position;
           var rotation = Quaternion.LookRotation(movement);
           //  var rotation = Quaternion.LookRotation(m_MovePath[m_CurrentPointID] - transform.position);
           rotation.x = 0f;
           rotation.z = 0f;

           if (movement != Vector3.zero)
           {
               transform.rotation = Quaternion.Lerp(transform.rotation, rotation, Time.deltaTime * m_rotationSpeed);

           }
       }   
       private void MoveOnPath()
       {
           float distance = Vector3.Distance(m_MovePath[m_CurrentPointID], transform.position);
           transform.position = Vector3.MoveTowards(transform.position, m_MovePath[m_CurrentPointID], Time.deltaTime * m_MoveSpeed);


           if (distance <= 1f && m_CurrentPointID < m_MovePath.Count - 1)
           {
               m_CurrentPointID++;
           }
       }
       private void CheckForWayPointsAvailable()
       {
           if (m_CurrentPointID >= m_MovePath.Count || m_MovePath.Count == 0)
           {
               m_IsPointsAvailable = false;
           }

           else
           {
               m_IsPointsAvailable = true;
           }
       }*/

    private void SetMovementPath(List<Transform> pathPoints)
    {    
        for (int i = 0; i < pathPoints.Count; i++)
        {
            m_MovePath.Add(pathPoints[i].position);
        }    
    }
}
