using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GiveHealth : MonoBehaviour
{
    //----------------------------------------------Variables-----------------------------------------------
    [SerializeField] int m_MinHealth;
    public int MinHealth
    {
        get
        {
            return m_MinHealth;
        }
    }

    [SerializeField] int m_MaxHealth;
    public int MaxHealth
    {
        get
        {
            return m_MaxHealth;
        }
    }
}
