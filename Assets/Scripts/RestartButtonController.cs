using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartButtonController : MonoBehaviour
{
    [SerializeField] private GameObject _restartButton;

    public void ShowButton()
    {
        _restartButton.SetActive(true);
    }
}
