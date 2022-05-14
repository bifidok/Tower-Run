using UnityEngine.UI;
using UnityEngine;

public class SceneChange : MonoBehaviour
{
    [SerializeField] private Image _menu;
    [SerializeField] private Button _reloadButton;
    [SerializeField] private Button _nextSceneButton;
    [SerializeField] private Text _menuText;
    private SceneLoader _scene;

    private void Start()
    {
        _scene = new SceneLoader();
        _menu.gameObject.SetActive(false);
    }

    public void MenuText(string text)
    {
        _menuText.text = text;
    }

    public void GetEndLevelMenu(bool passed)
    {
        Time.timeScale = 0f;
        if(_menu.IsActive())
        {
            _menu.gameObject.SetActive(false);
            Time.timeScale = 1;
        } 
        else 
        {
            _menu.gameObject.SetActive(true);

            if (passed)
            {
                _nextSceneButton.gameObject.SetActive(true);
                _reloadButton.gameObject.SetActive(false);
            }
            else
            {
                _reloadButton.gameObject.SetActive(true);
                _nextSceneButton.gameObject.SetActive(false);
            }
        }

    }

    public void ReloadLevel()
    {
        _scene.ReloadScene();
        _menu.gameObject.SetActive(false);
        Time.timeScale = 1;
    }
    
    public void LoadNextScene()
    {
        _scene.LoadNextScene();
        _menu.gameObject.SetActive(false);
        Time.timeScale = 1;
    }

}
