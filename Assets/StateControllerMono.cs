using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateControllerMono : MonoBehaviour
{
    [SerializeField] private Canvas _uiCanvas;
    [SerializeField] private Menu _mainMenuPrefab;
    [SerializeField] private GameOverPanel _gameOverPrefab;

    private void Update()
    {
        if (StateController.IsPaused || !Input.GetKeyDown(KeyCode.Escape)) return;
        StateController.IsPaused = true;
        Instantiate(_mainMenuPrefab, _uiCanvas.transform);
    }

    public void InstantiateGameOverPanel()
    {
        Instantiate(_gameOverPrefab, _uiCanvas.transform);
    }
}