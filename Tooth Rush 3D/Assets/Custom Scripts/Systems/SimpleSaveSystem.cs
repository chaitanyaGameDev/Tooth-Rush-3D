using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class SimpleSaveSystem : MonoBehaviour
{
    //----------------------------------------------Variables-------------------------------------------------

    public readonly static string s_LevelNumberKey = "LevelNumber";
    public readonly static string s_SceneBuildIndexKey = "SceneBuildIndex";
    public readonly static string s_CoinsKey = "Coins";


    private int m_SavableLvlNumber;
    private int m_SavableSceneBuildIndex;
    private int m_SavableCoins;

    [Header("Uncheck on Final Build only for debugging")]
    [SerializeField] bool m_DeleteAllPrefs;

    //----------------------------------------------Actions------------------------------------------------------

    public static event Action s_SaveSystemUpdated_event;

    //----------------------------------------------Methods-----------------------------------------------------

    private void Start()
    {
        if (m_DeleteAllPrefs)
        {
            PlayerPrefs.DeleteAll();
        }
      
        // CreateKeySlots();      
    }
    private void OnEnable()
    {
        LevelLoadSystem.s_LoadLevelCompleted_Event += ResetAllMemberSavables;
    }
    private void OnDisable()
    {      
        LevelLoadSystem.s_LoadLevelCompleted_Event -= ResetAllMemberSavables;
    }


    //This will creates slots when are not available i.e on Game was started for the first time
    private void CreateKeySlots()
    {
        if (!PlayerPrefs.HasKey(s_LevelNumberKey))
        {
            PlayerPrefs.SetInt(s_LevelNumberKey, 1);
        }

        if (!PlayerPrefs.HasKey(s_SceneBuildIndexKey))
        {
            PlayerPrefs.SetInt(s_SceneBuildIndexKey, 1);
        }

        if (!PlayerPrefs.HasKey(s_CoinsKey))
        {
            PlayerPrefs.SetInt(s_CoinsKey, 0);
        }
    }

    private void ResetAllMemberSavables()
    {
        m_SavableLvlNumber = 0;
        m_SavableSceneBuildIndex = 0;
        m_SavableCoins = 0;
    }
    private void SetLvlNumberTobeSaved()
    {
        int alreadySavedLvlNumber = PlayerPrefs.GetInt(s_LevelNumberKey,1);

        int newLvlNumber = alreadySavedLvlNumber + 1;

        m_SavableLvlNumber = newLvlNumber;    
    }
    private void SetSceneBuildIndexTobeSaved()
    {
        int alreadySavedSceneBuildIndex = PlayerPrefs.GetInt(s_SceneBuildIndexKey,1);

        int newSceneBuildIndex = alreadySavedSceneBuildIndex + 1;

       /* if (newSceneBuildIndex > m_LastSceneIndex && SceneManager.sceneCount > 0)
        {
            newSceneBuildIndex = loopStartSceneIndex;
        }*/

        m_SavableSceneBuildIndex = newSceneBuildIndex;       
    }
    private void SetCoinsTobeSaved(int amount)
    {
        int alreadySavedCoins = PlayerPrefs.GetInt(s_CoinsKey,0);

        int newCoins = alreadySavedCoins + amount;


        m_SavableCoins = newCoins;
    }

    //Saves the data
    private void Save()
    {
        PlayerPrefs.SetInt(s_LevelNumberKey,m_SavableLvlNumber);
        PlayerPrefs.SetInt(s_SceneBuildIndexKey,m_SavableSceneBuildIndex);
        PlayerPrefs.SetInt(s_CoinsKey,m_SavableCoins);

        PlayerPrefs.Save();

        //event
        s_SaveSystemUpdated_event?.Invoke();
    }


 
   

}
