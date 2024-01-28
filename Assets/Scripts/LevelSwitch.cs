using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSwitch : MonoBehaviour
{
    public void LoadNextDay()
    {
        Manage.Instance.Day += 1;
        Manage.Instance.left_Time = 30f;
        Player.Instance.Init();
        SceneManager.UnloadSceneAsync("EndScene");
    }

    public void Retry()
    {
        Manage.Instance.left_Time = 30f;
        StartCoroutine(load());
    }

    public IEnumerator load()
    {
        Manage.Instance.Day = 1;
        AsyncOperation _loadscene = SceneManager.LoadSceneAsync("SampleScene");
        if (!_loadscene.isDone)
            yield return 0;
        SceneManager.UnloadSceneAsync("EndScene");
    }

    public void Exit()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
                Application.Quit();
#endif
    }
}