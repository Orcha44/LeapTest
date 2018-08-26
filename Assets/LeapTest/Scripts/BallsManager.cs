using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallsManager : MonoBehaviour
{
    public static BallsManager Instance { get; set; }
    public SingleBall[] Balls;
    public float MinX, MaxX, MinY, MaxY, MinZ, MaxZ;
    public Texture ToTexture;

    private void Awake()
    {
        Instance = this;

        // Place every ball in a random position between Min_ and Max_
        foreach (var ball in Balls)
        {
            ball.transform.position = new Vector3(Random.Range(MinX, MaxX), Random.Range(MinY, MaxY), Random.Range(MinZ, MaxZ));
        }
    }
}
