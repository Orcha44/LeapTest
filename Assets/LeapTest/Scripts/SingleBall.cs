using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingleBall : MonoBehaviour
{
    public Rigidbody RB;
    public Renderer ShapeRenderer;
    public Collider Col;

    private BallsManager _ballsManager;

    private bool _wasTouched = false;

    private void OnCollisionEnter(Collision other)
    {
        // If it's the first time the ball was touched, and the player touched it
        if (!_wasTouched && other.transform.tag == "Player")
        {
            _wasTouched = true;
            other.transform.GetComponent<PlayerManager>().NextBall();
            ChangeBall();
        }
    }

    private void ChangeBall()
    {
        ScoreManager.Instance.AddScore(1);
        _ballsManager = BallsManager.Instance;
        //Change texture
        ShapeRenderer.material.mainTexture = _ballsManager.ToTexture;
        //Add physics
        RB.constraints = RigidbodyConstraints.None;
        RB.useGravity = true;
        enabled = true;
    }

    private void Update()
    {
        // If the ball x or z are out of the field, the ball wi
        if (transform.position.x < _ballsManager.MinX || transform.position.x > _ballsManager.MaxX
        || transform.position.z < _ballsManager.MinZ || transform.position.z > _ballsManager.MaxZ)
        {
            gameObject.SetActive(false);
        }

    }

    private void Reset()
    {
        RB = GetComponent<Rigidbody>();
        ShapeRenderer = GetComponent<Renderer>();
        Col = GetComponent<Collider>();
    }
}
