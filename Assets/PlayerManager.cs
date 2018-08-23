using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public Animator Anim;
    public float Speed;

    private int counter = 0;
    private BallsManager _ballsManager;
    private SingleBall _currentBall;

    void Start()
    {
        _ballsManager = BallsManager.Instance;
        Anim.SetTrigger("StartWalk");
        _currentBall = _ballsManager.Balls[counter];
        transform.LookAt(_currentBall.transform);
    }

    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, _currentBall.transform.position, Speed * Time.deltaTime);
        Debug.Log(Vector3.Distance(transform.position, _currentBall.transform.position));
        if (Vector3.Distance(transform.position, _currentBall.transform.position) <= 1)
        {
            counter++;
            if (counter == _ballsManager.Balls.Length)
            {
                Anim.SetTrigger("StopWalk");
                enabled = false;
                return;
            }
            _currentBall = _ballsManager.Balls[counter];
            transform.LookAt(_currentBall.transform);
        }
    }


}
