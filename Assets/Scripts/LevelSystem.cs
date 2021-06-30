using UnityEngine;
using UnityEngine.Events;

public class LevelSystem : MonoBehaviour
{
    [SerializeField] private ChangeLevelEvent _onChangeLevel;
    [SerializeField] private UnityEvent _onGameOver;

    private GameLevels _gameLevels;

    private void Start()
    {
        _gameLevels = GameLevels.Easy;
        _onChangeLevel.Invoke(_gameLevels);
        Cell.onRightClick += ChangeGameLevel;
    }
    private void OnDisable()
    {
        Cell.onRightClick -= ChangeGameLevel;
    }
    public void ChangeGameLevel()
    {
        if (_gameLevels == GameLevels.Difficult)
        {
            MakeCellsInactive();
            _onGameOver.Invoke();
            return;
        }
        _gameLevels++;
        _onChangeLevel.Invoke(_gameLevels);
    }
    public void StartNewGame()
    {
        _gameLevels = GameLevels.Easy;
        _onChangeLevel.Invoke(_gameLevels);
        ChangeGameLevel();
    }
    private void MakeCellsInactive()
    {
        Cell[] allCells = GameObject.FindObjectsOfType<Cell>();
        foreach(var cell in allCells)
        {
            cell.MakeInactive();
        }
    }
}

[System.Serializable]
public class ChangeLevelEvent : UnityEvent<GameLevels> { }