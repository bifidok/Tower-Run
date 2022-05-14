using UnityEngine;

public class CheckForEndLevel : MonoBehaviour
{
    [SerializeField] private float _percentForNextLevel;
    [SerializeField] private LevelGeneration _levelGeneration;
    [SerializeField] private SceneChange _scene;
    private float _towerCountNow;
    private float _allTowers;
    private float _humanCount;
    private bool _next;
    private string _menuText;

    private void Start()
    {
        _allTowers = _levelGeneration.TowerCount;
        _towerCountNow = _levelGeneration.TowerCount;
    }
    public void UpdateTowerCount(int humanCount)
    {
        _humanCount = humanCount - 1;
        _towerCountNow--;
        if (_towerCountNow == 0)
        {
            _menuText = $"Required score: {_percentForNextLevel} \n" +
                        $"Your score: {(_humanCount / _allTowers) * 100}";
            if((_humanCount / _allTowers) * 100 >= _percentForNextLevel)
            {
                _next = true;
            }
            else
            {
                _next = false;
            }
            _scene.GetEndLevelMenu(_next);
            _scene.MenuText(_menuText);
        }

    }

}
