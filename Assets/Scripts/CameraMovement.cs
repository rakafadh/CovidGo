using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public float CameraSpeed = 15f;
    public float SpeedIncreaseRate = 1f;

    // Update is called once per frame
    void Update()
    {
        CameraSpeed += SpeedIncreaseRate * Time.deltaTime;
        transform.position += new Vector3(CameraSpeed * Time.deltaTime, 0, 0);
    }
}
