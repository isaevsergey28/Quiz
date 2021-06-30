using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class LevelBuildingSystem : MonoBehaviour
{
    [SerializeField] private GameObject _cellPrefab;
    [SerializeField] private GameObject _cellsParent;

    private SpriteRenderer _cellSpriteRenderer;
    private float _cellSizeX;
    private float _cellSizeY;
    private LevelData _levelData;
    private List<Sprite> _cellsType = new List<Sprite>();
    private int _cellsNumberInRow = 3;
    private List<GameObject> _currentCells = new List<GameObject>();

    private void Awake()
    {
        _levelData = GetComponent<LevelData>();
        _cellSpriteRenderer = _cellPrefab.transform.GetChild(0).GetComponent<SpriteRenderer>();
        _cellSizeX = _cellSpriteRenderer.bounds.max.x - _cellSpriteRenderer.bounds.min.x;
        _cellSizeY = _cellSpriteRenderer.bounds.max.y - _cellSpriteRenderer.bounds.min.y;
    }
    public void ClearLevel()
    {
        foreach(var cell in _currentCells.ToList())
        {
            _currentCells.Remove(cell);
            Destroy(cell);
        }
    }
    public void BuildLevel(GameLevels gameLevels)
    {
        ClearLevel();
        int levelNumber = Convert.ToInt32(gameLevels);
        _levelData.SetActiveCells(levelNumber);
        _cellsType = _levelData.GetActiveCells();

        Vector2 firstCellPos;
        float firstCellPosX;

        FintOutFirstCellPos(levelNumber, out firstCellPos, out firstCellPosX);
        SpawnCells(levelNumber, firstCellPos, firstCellPosX);
    }

    private void FintOutFirstCellPos(int levelNumber, out Vector2 firstCellPos, out float firstCellPosX)
    {
        firstCellPos = transform.position;
        if (levelNumber % 2 == 0)
        {
            firstCellPos.y = transform.position.y + ((_cellSizeY - _cellSizeY * 0.5f) * levelNumber) / 2;
        }
        else if (levelNumber % 2 == 1)
        {
            firstCellPos.y = transform.position.y + ((_cellSizeY) * (levelNumber - 1)) / 2;
        }
        firstCellPos.x -= _cellSizeX * (int)(_cellsNumberInRow / 2);
        firstCellPosX = firstCellPos.x;
    }

    private void SpawnCells(int levelNumber, Vector2 firstCellPos, float firstCellPosX)
    {
        int cellNumber = 0;
        for (int i = 0; i < levelNumber; i++)
        {
            for (int j = 0; j < _cellsNumberInRow; j++)
            {
                GameObject cell;
                cell = Instantiate(_cellPrefab, firstCellPos, Quaternion.identity, _cellsParent.transform);
                _currentCells.Add(cell);
                cell.transform.GetChild(0).GetChild(0).GetComponent<SpriteRenderer>().sprite = _cellsType[cellNumber++];
                firstCellPos.x += _cellSizeX;
            }
            firstCellPos.x = firstCellPosX;
            firstCellPos.y -= _cellSizeY;
        }
    }
}
