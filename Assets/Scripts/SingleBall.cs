using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingleBall : MonoBehaviour
{
    public Rigidbody RB;
    public Renderer ShapeRenderer;

    private BallsManager _ballsManager;


    void OnCollisionEnter(Collision other)
    {
        if (other.transform.tag == "Player")
        {
            ChangeBall();
        }
    }

    private void ChangeBall()
    {
        _ballsManager = BallsManager.Instance;
        ShapeRenderer.material.mainTexture = _ballsManager.ToTexture;
        RB.constraints = RigidbodyConstraints.None;
        RB.useGravity = true;
        enabled = true;
    }

    private void Update()
    {
        if (transform.position.x < _ballsManager.MinX || transform.position.x > _ballsManager.MaxX
        || transform.position.z < _ballsManager.MinZ || transform.position.z > _ballsManager.MaxZ)
        {
            killBall();
        }

    }

    private void killBall()
    {
        gameObject.SetActive(false);
    }

    private void Reset()
    {
        RB = GetComponent<Rigidbody>();
        ShapeRenderer = GetComponent<Renderer>();
    }
}
