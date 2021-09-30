using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToothBody : MonoBehaviour
{
    //----------------------------------------------Variables-----------------------------------------------

    [SerializeField] GameObject m_ToothPasteGel_Gobj;

    public static bool s_HasToothPasteGel { private set; get; }

    //----------------------------------------------Methods--------------------------------------------------
    private void Start()
    {
        s_HasToothPasteGel = false;
        m_ToothPasteGel_Gobj.gameObject.SetActive(false);
    }
    private void OnEnable()
    {
        CharacterCollision.s_OnToothPaste_Triggered_event += SetAndEnable_ToothPasteGel;
        CharacterCollision.s_OnUnHealth_Triggered_event += SetAndDisable_ToothPasteGel;


        ToothBrushing.s_OnBrushingStarted_event += SetAndDisable_ToothPasteGel;
        CharacterCollision.s_OnUnHealth_Triggered_event += SetAndDisable_ToothPasteGel;
    }
    private void OnDisable()
    {
        CharacterCollision.s_OnToothPaste_Triggered_event -= SetAndEnable_ToothPasteGel;
        CharacterCollision.s_OnUnHealth_Triggered_event -= SetAndDisable_ToothPasteGel;


        ToothBrushing.s_OnBrushingStarted_event -= SetAndDisable_ToothPasteGel;
        CharacterCollision.s_OnUnHealth_Triggered_event -= SetAndDisable_ToothPasteGel;
    }

    private void SetAndEnable_ToothPasteGel()
    {
        s_HasToothPasteGel = true;
        m_ToothPasteGel_Gobj.SetActive(true);
    }
    private void SetAndDisable_ToothPasteGel()
    {
        s_HasToothPasteGel = false;
        m_ToothPasteGel_Gobj.SetActive(false);
    }


   
}
