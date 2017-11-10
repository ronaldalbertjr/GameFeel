using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    [SerializeField]
    Transform cannon;
    [HideInInspector]
    public float shakeDuration;
    private Transform mainCamera;
    private float shakeAmount;
    private float decreaseFactor;
    private Vector3 lastCamPosition;
    private Vector3 camPosition;
    private Vector3 initialPosition;

    private void Start()
    {
        initialPosition = Camera.main.transform.position;
        mainCamera = Camera.main.transform;
        lastCamPosition = mainCamera.position;
        shakeDuration = 0;
        shakeAmount = 0.3f;
        decreaseFactor = 1;
    }
    
    void Update ()
    {
        CameraShake();
        ChangeCameraPosition();
    }

    void CameraShake()
    {
        camPosition = initialPosition;
        if (shakeDuration > 0)
        {
            initialPosition = camPosition + (Vector3) UnityEngine.Random.insideUnitCircle * shakeAmount;
            shakeDuration -= Time.deltaTime * decreaseFactor;
        }
        else
        {
            shakeDuration = 0f;
            initialPosition = lastCamPosition;
        }
    }

    void ChangeCameraPosition()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 distance = mousePosition - initialPosition;
        Vector3 offset = new Vector3(distance.x, distance.y)/10f;

        Camera.main.transform.position = initialPosition + offset;
    }
}
