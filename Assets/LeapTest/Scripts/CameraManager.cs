using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    public Transform CamPos;
    public float RotationSpeed = 5;
    public float MoveSpeed = 5;

    private void Awake()
    {
        transform.position = CamPos.position;
        transform.rotation = transform.rotation;
    }

    private void Update()
    {
        transform.position = Vector3.Lerp(transform.position, CamPos.position, MoveSpeed * Time.deltaTime);
        transform.rotation = Quaternion.Lerp(transform.rotation, CamPos.rotation, RotationSpeed * Time.deltaTime);
    }
}
