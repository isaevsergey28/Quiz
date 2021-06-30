using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class TaskText : MonoBehaviour
{
    private Text _taskText;

    private void Awake()
    {
        _taskText = GetComponent<Text>();
    }
    public void ShowTaskText(GameLevels gameLevels)
    {
        _taskText.DOFade(0, 0);
        _taskText.DOFade(1, 3f);
        _taskText.text = "Find " + LevelData.AssignmentPurpose;
    }
}
