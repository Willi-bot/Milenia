using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMotor : MonoBehaviour
{
    public Transform lookAt;

    public float boundX = 0.30f;
    public float boundY = 0.10f;
    public float smoothingFactor = 0.01f;

    public Vector2 minPosition;
    public Vector2 maxPosition;

    private Vector3 _targetPosition;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        Vector3 delta = Vector3.zero;
        
        float deltaX = lookAt.position.x - transform.position.x;
        if (deltaX > boundX || deltaX < -boundX)
        {
            if (transform.position.x < lookAt.position.x)
            {
                delta.x = deltaX - boundX;
            }
            else
            {
                delta.x = deltaX + boundX;
            }
        }
        
        
        float deltaY = lookAt.position.y - transform.position.y;
        if (deltaY > boundY || deltaY < -boundY)
        {
            if (transform.position.y < lookAt.position.y)
            {
                delta.y = deltaY - boundY;
            }
            else
            {
                delta.y = deltaY + boundY;
            }
        }

        if (delta.x != 0 || delta.y != 0)
        {
            Vector3 camPosition = transform.position;
            
            Vector3 targetPosition = new Vector3(camPosition.x + delta.x, camPosition.y + delta.y, -10);

            targetPosition.x = Mathf.Clamp(targetPosition.x, minPosition.x, maxPosition.x);
            targetPosition.y = Mathf.Clamp(targetPosition.y, maxPosition.y, minPosition.y);
            
            transform.position = Vector3.Lerp(camPosition, targetPosition, smoothingFactor);
        }
    }
}
