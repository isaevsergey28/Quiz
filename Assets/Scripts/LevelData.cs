using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelData : MonoBehaviour
{
    [SerializeField] private int _cellsTypeNumber;
    [SerializeField] private Sprite[] _allLetters;
    [SerializeField] private Sprite[] _allNumbers;

    public static string AssignmentPurpose { get; private set; }

    private Sprite[] _currentCellsType;
    private List<Sprite> _activeCells = new List<Sprite>();
    private int _cellsNumberInRow = 3;

    public void SetActiveCells(int cellsNumber)
    {
        _activeCells.Clear();

        ChooseCellsType();

        for (int i = 0; i < cellsNumber * _cellsNumberInRow; i++)
        {
            Sprite tempSprite ;
            while(true)
            {
                tempSprite = _currentCellsType[Random.Range(0, _currentCellsType.Length)];
                if (!_activeCells.Contains(tempSprite))
                {
                    _activeCells.Add(tempSprite);
                    break;
                }
            }
            
        }
        SetPurpose();
    }
    private void SetPurpose()
    {
       AssignmentPurpose = _activeCells[Random.Range(0, _activeCells.Count)].name;
    }

    public List<Sprite> GetActiveCells()
    {
        return _activeCells;
    }
    private void ChooseCellsType()
    {
        int rand = Random.Range(0, _cellsTypeNumber);
        if(rand == 0)//неэффективно
        {
            _currentCellsType = _allLetters;
        }
        else if(rand == 1)
        {
            _currentCellsType = _allNumbers;
        }
    }
    
}
