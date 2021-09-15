using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToothAgeingVisual : MonoBehaviour
{
    //----------------------------------------------Variables-----------------------------------------------
    [Header("(Shiny Tooth Visual)")]

    [SerializeField] ShinyVisual m_shiny_Visual;

    [Header("(Healthy Tooth Visual)")]

    [SerializeField] HealthyVisual m_healthy_Visual;


    [Header("(Germs Tooth Visual)")]

    [SerializeField] GermsVisual m_germs_Visual;

    [Header("(Plague Tooth Visual)")]

    [SerializeField] PlagueVisual m_plague_Visual;

    [Header("(Cavity1 Tooth Visual)")]

    [SerializeField] Cavity1Visual m_cavity1_Visual;

    [Header("(Cavity2 Tooth Visual)")]

    [SerializeField] Cavity2Visual m_cavity2_Visual;

    [Header("(Rotten Tooth Visual)")]

    [SerializeField] RottenVisual m_Rotten_Visual;


    //----------------------------------------------Methods--------------------------------------------------
    private void OnEnable()
    {
        ToothAgeing.s_OnStateChanged_event += CheckAndEnableToothAgeingVisual;
    }
    private void OnDisable()
    {
        ToothAgeing.s_OnStateChanged_event -= CheckAndEnableToothAgeingVisual;
    }


    private void CheckAndEnableToothAgeingVisual(ToothAgeState state)
    {
        switch (state)
        {
            case ToothAgeState.none:
                break;


            //-----------------------------------------


            case ToothAgeState.Shiny:

                //Enable
                m_shiny_Visual.Enable(true);

                //Disable
               
                m_plague_Visual.Enable(false);
                m_cavity1_Visual.Enable(false);
                m_cavity2_Visual.Enable(false);
                m_Rotten_Visual.Enable(false);

                

                break;


                //-----------------------------------------

            case ToothAgeState.Healthy:

                //Enable
                m_healthy_Visual.Enable(true);

                //Disable
               
                m_plague_Visual.Enable(false);
                m_cavity1_Visual.Enable(false);
                m_cavity2_Visual.Enable(false);
                m_Rotten_Visual.Enable(false);

               


                break;


            //-----------------------------------------



            case ToothAgeState.Germs:

                //Enable
                

                //Disable

                break;


            //-----------------------------------------



            case ToothAgeState.Plague1:

                //Enable
                m_plague_Visual.Enable(true);


                //Disable
                m_healthy_Visual.Enable(false);
                m_shiny_Visual.Enable(false);
                m_cavity1_Visual.Enable(false);
                m_cavity2_Visual.Enable(false);
                m_Rotten_Visual.Enable(false);

                

                break;


            //-----------------------------------------


            case ToothAgeState.Plague2:


                //Enable
                m_plague_Visual.Enable(true);


                //Disable
                m_healthy_Visual.Enable(false);
                m_shiny_Visual.Enable(false);
                m_cavity1_Visual.Enable(false);
                m_cavity2_Visual.Enable(false);
                m_Rotten_Visual.Enable(false);


                break;


            //-----------------------------------------


            case ToothAgeState.Plague3:

                //Enable
                m_plague_Visual.Enable(true);


                //Disable
                m_healthy_Visual.Enable(false);
                m_shiny_Visual.Enable(false);
                m_cavity1_Visual.Enable(false);
                m_cavity2_Visual.Enable(false);
                m_Rotten_Visual.Enable(false);



                break;


            //-----------------------------------------


            case ToothAgeState.Cavity1:

                //Enable
                m_cavity1_Visual.Enable(true);


                //Disable
                m_plague_Visual.Enable(false);
                m_healthy_Visual.Enable(false);
                m_shiny_Visual.Enable(false);
                m_cavity2_Visual.Enable(false);
                m_Rotten_Visual.Enable(false);

                break;


            //-----------------------------------------


            case ToothAgeState.Cavity2:

                //Enable
                m_cavity2_Visual.Enable(true);

                //Disable
                m_plague_Visual.Enable(false);
                m_healthy_Visual.Enable(false);
                m_shiny_Visual.Enable(false);
                m_cavity1_Visual.Enable(false);
                m_Rotten_Visual.Enable(false);
                break;


            //-----------------------------------------


            case ToothAgeState.Rotten:

                //Enable
                m_Rotten_Visual.Enable(true);


                //Disable
                m_plague_Visual.Enable(false);
                m_healthy_Visual.Enable(false);
                m_shiny_Visual.Enable(false);
                m_cavity1_Visual.Enable(false);
                m_cavity2_Visual.Enable(false);
               
                break;
        }


        if (ToothAgeing.s_HasGerms)
        {
            m_germs_Visual.Enable(true);
        }
        else if(!ToothAgeing.s_HasGerms)
        {
            m_germs_Visual.Enable(false);
        }

    }



   
    


}
[System.Serializable]
public class ShinyVisual
{
    public GameObject Tooth_Shiny_Gobj;


    public void Enable(bool status)
    {
        Tooth_Shiny_Gobj.SetActive(status);
    }

}

[System.Serializable]
public class HealthyVisual
{
    public GameObject Tooth_Healthy_Gobj;


    public void Enable(bool status)
    {
        Tooth_Healthy_Gobj.SetActive(status);
    }

}

[System.Serializable]
public class GermsVisual
{
    public GameObject Tooth_Germs_Gobj;


    public void Enable(bool status)
    {
        Tooth_Germs_Gobj.SetActive(status);
    }

}

[System.Serializable]
public class PlagueVisual
{
    public GameObject Tooth_Plague_White_Gobj;
    public GameObject Tooth_Plague_Gobj;


    public void Enable(bool status)
    {
        Tooth_Plague_White_Gobj.SetActive(status);
        Tooth_Plague_Gobj.SetActive(status);
    }

}

[System.Serializable]
public class Cavity1Visual
{
    public GameObject Tooth_Cavity1_White_Gobj;
    public GameObject Tooth_Cavity1_Gobj;


    public void Enable(bool status)
    {
        Tooth_Cavity1_White_Gobj.SetActive(status);
        Tooth_Cavity1_Gobj.SetActive(status);
    }

}

[System.Serializable]
public class Cavity2Visual
{
    public GameObject Tooth_Cavity2_White_Gobj;
    public GameObject Tooth_Cavity2_Gobj;



    public void Enable(bool status)
    {
        Tooth_Cavity2_White_Gobj.SetActive(status);
        Tooth_Cavity2_Gobj.SetActive(status);

    }
}

[System.Serializable]
public class RottenVisual
{
    public GameObject Tooth_Rotten_White_Gobj;
    public GameObject Tooth_Rotten_Gobj;


    public void Enable(bool status)
    {
        Tooth_Rotten_White_Gobj.SetActive(status);
        Tooth_Rotten_Gobj.SetActive(status);
    }

}
