using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindController : MonoBehaviour
{
    [SerializeField]
    float rotateSpeed = 50f;
    [SerializeField]
    float rotateFrequency = 2f;

    Vector3 newAngle;
    float rotateProgress = 0f;
    bool canRotate;

    float initialAngle = 0f;
    float targetAngle = 90f;

    float timeElapsed = 0f;

    // Start is called before the first frame update
    void Start()
    {
        canRotate = false;
    }

    // Update is called once per frame
    void Update()
    {
        rotateCondition();
        rotateSelf(initialAngle, targetAngle);
    }

    private void rotateCondition()
    {
        if(timeElapsed >= rotateFrequency)
        {
            canRotate = true;
            timeElapsed = 0f;
            initialAngle = transform.eulerAngles.z;
            targetAngle = initialAngle + (UnityEngine.Random.Range(0, 2) * 2 - 1) * 90f;
        }
        if (!canRotate)
        {
            timeElapsed += Time.deltaTime;
        }
    }

    void rotateSelf(float rotateFrom, float rotateTo)
    {
        if (canRotate)
        {
            newAngle = new Vector3(0, 0, Mathf.LerpAngle(rotateFrom, rotateTo, rotateProgress));
            transform.eulerAngles = newAngle;

            rotateProgress += Time.deltaTime * rotateSpeed;

            if (rotateProgress >= 1)
            {
                transform.eulerAngles = new Vector3(0, 0, targetAngle);
                rotateProgress = 0f;
                canRotate = false;
            }
        }
    }
}
