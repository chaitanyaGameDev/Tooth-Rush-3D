using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;

public class LevelLoadSystem : GenericSingleton<LevelLoadSystem>
{
    //----------------------------------------------Variables-----------------------------------------------

    private List<AsyncOperation> m_loadOperations;

    //----------------------------------------------Actions--------------------------------------------------

    public static event Action s_LoadLevelCompleted_Event;

    //----------------------------------------------Methods--------------------------------------------------

    private void OnEnable()
    {
        WinScreenUI.s_NextButtonClicked_event += LoadOnNextClick;
        FailScreenUI.s_ContinueButtonClick_Event += LoadOnContinueClick;
    }
    private void OnDisable()
    {
        WinScreenUI.s_NextButtonClicked_event -= LoadOnNextClick;
        FailScreenUI.s_ContinueButtonClick_Event -= LoadOnContinueClick;
    }
    private void Start()
    {
        m_loadOperations = new List<AsyncOperation>();
        StartCoroutine( LoadNewSceneOnStart());
    }

    //Async Methods
    //Load
    private void LoadLevel(int sceneIndex)
    {
        AsyncOperation ao = SceneManager.LoadSceneAsync(sceneIndex, LoadSceneMode.Single);

        if (ao == null)
        {
            return;
        }
        ao.completed += OnLoadLevelCompleted;
        m_loadOperations.Add(ao);

    }
    private void OnLoadLevelCompleted(AsyncOperation ao)
    {
        if (m_loadOperations.Contains(ao))
        {
            m_loadOperations.Remove(ao);
            if (m_loadOperations.Count == 0)
            {
                //event
                StartCoroutine(DelayLevelLoadCompletedEvent());
            }
        }
    }
   

    //UnLoad
    private void UnLoadLevel(int sceneIndex)
    {
        bool sceneLoaded = SceneManager.GetSceneByBuildIndex(sceneIndex).isLoaded;

        AsyncOperation ao = SceneManager.UnloadSceneAsync(sceneIndex);

        if (ao == null)
        {
            return;
        }

        ao.completed += OnUnLoadLevelCompleted;
        m_loadOperations.Add(ao);

    }
    private void OnUnLoadLevelCompleted(AsyncOperation ao)
    {
        if (m_loadOperations.Contains(ao))
        {
            m_loadOperations.Remove(ao);
            if (m_loadOperations.Count == 0)
            {


            }
        }
    }

    //Loads the level on --> Game Start
    private IEnumerator LoadNewSceneOnStart()
    {
        yield return new WaitForSeconds(3f);
        int savedBuildIndex = PlayerPrefs.GetInt(SimpleSaveSystem.s_SceneBuildIndexKey, 1);

        LoadLevel(savedBuildIndex);
    }

    //Loads the level on --> Level Completed
    private void LoadOnNextClick()
    {
        StartCoroutine(LoadNewSceneOnWin());
    }
    private IEnumerator LoadNewSceneOnWin()
    {      
        yield return new WaitForSeconds(3f);
        int savedBuildIndex = PlayerPrefs.GetInt(SimpleSaveSystem.s_SceneBuildIndexKey, 1);
        LoadLevel(savedBuildIndex);
    }

    //Loads the level on --> Level Failed
    private void LoadOnContinueClick()
    {
        StartCoroutine(LoadNewSceneOnFail());
    }
    private IEnumerator LoadNewSceneOnFail()
    {
        yield return new WaitForSeconds(3f);
        int savedBuildIndex = PlayerPrefs.GetInt(SimpleSaveSystem.s_SceneBuildIndexKey, 1);
        LoadLevel(savedBuildIndex);
    }


    private IEnumerator DelayLevelLoadCompletedEvent()
    {
        yield return new WaitForSeconds(0.1f);
        s_LoadLevelCompleted_Event?.Invoke();
    }




}
