using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public Animator Anim;
    public float WalkSpeed;

    private int _counter = 0;
    private BallsManager _ballsManager;
    private SingleBall _currentBall;
    private Vector3 _moveVector;

    private void Start()
    {
        _ballsManager = BallsManager.Instance;
        Anim.SetTrigger("StartWalk");
        SetNewBallTarget();
    }

    private void Update()
    {
        MovePlayer();
    }

    private void SetNewBallTarget()
    {
        _currentBall = _ballsManager.Balls[_counter];
        _currentBall.Col.enabled = true;
        transform.LookAt(_currentBall.transform);
    }

    private void MovePlayer()
    {
        _moveVector = _currentBall.transform.position;
        _moveVector.y = 0;
        transform.position = Vector3.MoveTowards(transform.position, _moveVector, WalkSpeed * Time.deltaTime);
    }

    public void NextBall()
    {
        _counter++;

        // if there are no more targets, the game has ended
        if (_counter == _ballsManager.Balls.Length)
        {
            Anim.SetTrigger("StopWalk");
            enabled = false;
            GameManager.Instance.EndGame();
            return;
        }
        SetNewBallTarget();
    }

}
