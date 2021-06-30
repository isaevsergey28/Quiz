using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class RestartSystem : MonoBehaviour
{
    [SerializeField] private UnityEvent _onRestart;

    public void RestartGame()
    {
        _onRestart?.Invoke();
        gameObject.SetActive(false);
    }

}
