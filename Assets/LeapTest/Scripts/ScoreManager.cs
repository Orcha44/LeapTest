using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance { get; set; }
    public Text ScoreText;
    public Text TimeText;

    private float _time = 0;
    private int _score = 0;

    private void Awake()
    {
        Instance = this;
    }

    private void Update()
    {
        _time += Time.deltaTime;
        TimeText.text = string.Format("{0:0.00}", _time);
    }

    public void AddScore(int value)
    {
        _score += value;
        ScoreText.text = _score.ToString();
    }
}
