using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerMovement : MonoBehaviour
{
    //----------------------------------------------Variables-----------------------------------------------

    private List<Vector3> m_MovePath = new List<Vector3>();

    [SerializeField]  private float m_MoveSpeed = 7.5f;
    [SerializeField]  private float m_rotationSpeed = 5f;
    [SerializeField]  private float m_accuracy = 1f;

   
    private int m_CurrentPointID = 0;
  //  private bool m_IsPointsAvailable = false;
   // private bool m_CanMove;
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
        //Continus Path movement
         if (Player.s_State == PlayerState.Playing && Character.s_State != CharacterState.Brushing)
         {
            MoveAndRotateOnPath();
            Character.ChangeState(CharacterState.Moving);
         }     
    }

    private void MoveAndRotateOnPath()
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

            Movement();
      
        }

        else
        {
            Movement();
        }
    }
    private void Movement()
    {
        transform.position += transform.forward * m_MoveSpeed * Time.deltaTime;
    }
    private void SetMovementPath(List<Transform> pathPoints)
    {
        m_MovePath.Clear();
        m_CurrentPointID = 0;

        for (int i = 0; i < pathPoints.Count; i++)
        {
            m_MovePath.Add(pathPoints[i].position);
        }    
    }

}
