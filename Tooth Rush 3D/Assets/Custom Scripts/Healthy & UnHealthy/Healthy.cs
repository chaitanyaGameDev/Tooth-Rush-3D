using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Healthy : MonoBehaviour
{
    [SerializeField] HealthyItemType m_ItemType;
    public HealthyItemType ItemType
    {
        get
        {
            return m_ItemType;
        }
    }

}

public enum HealthyItemType
{
    Base,
    ToothPaste,
    ToothBrushing
}
