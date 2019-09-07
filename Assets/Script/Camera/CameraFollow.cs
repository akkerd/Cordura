using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField]
    SO_ObjectRef targetRef;
    [SerializeField]
    float cameraOffset = 10.0f;

    private Vector3 targetPosition;

    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        targetPosition = targetRef.getGameObject().transform.position;
        targetPosition.z -= cameraOffset;
        this.transform.position = targetPosition;
    }
}
