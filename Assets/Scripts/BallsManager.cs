using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallsManager : MonoBehaviour
{
    public static BallsManager Instance { get; set; }
    public SingleBall[] Balls;
    public float MinX, MaxX, MinY, MaxY, MinZ, MaxZ;
    public Texture ToTexture;

    private Vector3 _positionVector;

    private void Awake()
    {
        Instance = this;

        foreach (var ball in Balls)
        {
            _positionVector = new Vector3(Random.Range(MinX, MaxX), Random.Range(MinY, MaxY), Random.Range(MinZ, MaxZ));
            ball.transform.position = _positionVector;
        }
    }



}
