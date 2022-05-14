using UnityEngine.SceneManagement;

public class SceneLoader
{
    public void LoadNextScene()
    {
        if(SceneManager.GetActiveScene().buildIndex < SceneManager.sceneCount)
        {
        int nextScene = SceneManager.GetActiveScene().buildIndex + 1;
        SceneManager.LoadScene(nextScene);
        }
        else
        {
            ReloadScene();
        }
        
    }
    public void ReloadScene()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.name);
    }
}
