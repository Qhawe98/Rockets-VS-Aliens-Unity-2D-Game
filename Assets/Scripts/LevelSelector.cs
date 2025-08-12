using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSelector : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    public void OpenScene()
    {
        SceneManager.LoadScene("Level 1");
    }

    public void RunScene()
    {
        SceneManager.LoadScene("Level 2");
    }

    public void RunScene3()
    {
        SceneManager.LoadScene("Level 3");
    }

    
    public void GoToSelector()
    {
        SceneManager.LoadScene("LevelSelector");
    }

    public void ExitGame()
    {
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #else
            Application.Quit();
        #endif
    }
}
