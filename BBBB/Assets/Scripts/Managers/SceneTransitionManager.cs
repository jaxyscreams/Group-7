using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

[InfoHeaderClass("Drag me into the scene. I can load new scenes")]
public class SceneTransitionManager : MonoBehaviour
{
    public static SceneTransitionManager Instance;   

    private void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);         
    }

    public void LoadNextScene()
    {
        int nextSceneBuildInt = SceneManager.GetActiveScene().buildIndex + 1;
        SceneManager.LoadScene("Level" + nextSceneBuildInt);
    }

    public void LoadSpecificScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void ReloadCurrentScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    //Only works for executables.
    public void QuitGame()
    {
        Application.Quit();
    }
}
