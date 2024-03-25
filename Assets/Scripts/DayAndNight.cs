using System;
using UnityEditor.Rendering;
using UnityEngine;

public class DayAndNight : MonoBehaviour
{
    Vector3 rotation = Vector3.zero;
    private int previousRotation;
    public float degPerSec = 6;
    public Material skyBox;
    private float rotationShader = 0;
    private float xposureShader = 0.21f;
    public float rotationSkySpeed = 10;

    private void Start()
    {
        skyBox.SetFloat("_Exposure", xposureShader);
    }

    void Update()
    {
        if (rotation.x > 630)
        {
            rotation.x = 270;
            xposureShader = 0.21f;
        }
        rotation.x = degPerSec * Time.deltaTime;
        previousRotation = Mathf.RoundToInt(rotation.x);
        transform.Rotate(rotation, Space.World);
        if (rotationShader < 360)
        {
            rotationShader += Time.deltaTime * rotationSkySpeed;
        }
        else
        {
            rotationShader = 0;
        }

        if (previousRotation - rotation.x <= 0)
        {
            if (rotation.x > 270 & rotation.x < 450)
            {
                xposureShader += 0.00727778f;
            }
            if (rotation.x > 450)
            {
                xposureShader -= 0.00727778f;
            }
        }
        skyBox.SetFloat("_Rotation", rotationShader);
        skyBox.SetFloat("_Exposure", xposureShader);
    }
}
