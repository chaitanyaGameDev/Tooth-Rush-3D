using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PathCreator : MonoBehaviour
{
    [Header("(Add Points Here)")]

    [SerializeField] List<Transform> m_path_Objs = new List<Transform>();
    public List<Transform> PathPoints
    {
        get
        {
            return m_path_Objs;
        }
    }


    private List<Transform> m_GizmosPath_Objs = new List<Transform>();
    private Transform[] m_ArrayOf_PathObjs;

#if UNITY_EDITOR
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.black;


        m_ArrayOf_PathObjs = GetComponentsInChildren<Transform>();

        m_GizmosPath_Objs.Clear();



        foreach (var item in m_ArrayOf_PathObjs)
        {
            if (item != this.transform)
            {
                m_GizmosPath_Objs.Add(item);
            }
        }

        if (m_GizmosPath_Objs.Count > 0)
        {

            for (int i = 0; i < m_GizmosPath_Objs.Count; i++)
            {

                if (m_GizmosPath_Objs[i] != null)
                {
                    Vector3 position = m_GizmosPath_Objs[i].position;

                    if (i > 0)
                    {
                        Vector3 previous = m_GizmosPath_Objs[i - 1].position;
                        Gizmos.DrawLine(previous, position);
                    }
                }
                

            }

        }

    }

#endif
}
