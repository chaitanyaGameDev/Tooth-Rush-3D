using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GiveHealth : MonoBehaviour
{
    //----------------------------------------------Variables-----------------------------------------------
    [SerializeField] int m_Health;
    public int HealthValue
    {
        get
        {
            return m_Health;
        }
    }
}
