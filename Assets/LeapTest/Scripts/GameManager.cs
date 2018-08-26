using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Scene = UnityEngine.SceneManagement.SceneManager;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; set; }
    public CanvasGroup GameOver;

    private bool _gameEnded = false;

    private void Awake()
    {
        Instance = this;
    }

    private void Update()
    {
        if (_gameEnded)
        {
            if (GameOver.alpha < 1)
            {
                GameOver.alpha += Time.deltaTime * 2;
            }
            if (Input.GetKeyDown(KeyCode.R))
            {
                ResetScene();
            }
        }
    }

    private void ResetScene()
    {
        Scene.LoadScene(Scene.GetActiveScene().buildIndex);
    }

    public void EndGame()
    {
        _gameEnded = true;
        ScoreManager.Instance.enabled = false;
    }
}
