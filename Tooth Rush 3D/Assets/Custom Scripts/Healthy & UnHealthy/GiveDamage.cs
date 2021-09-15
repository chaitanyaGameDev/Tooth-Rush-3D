using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GiveDamage : MonoBehaviour
{
    //----------------------------------------------Variables-----------------------------------------------

    [SerializeField] int m_Damage;
    public int DamageValue
    {
        get
        {
            return m_Damage;
        }
    }
}
