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
    float windRotation;
    public Vector2 windDirection;
    public bool stopWind;

    private GameController gameController;

    // Start is called before the first frame update
    void Start()
    {
        gameController = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
        canRotate = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!stopWind)
        {
            rotateCondition();
            rotateSelf(initialAngle, targetAngle);
            windRotation = transform.rotation.eulerAngles.z;
            windDirection = new Vector2(Mathf.Cos(windRotation * Mathf.Deg2Rad), Mathf.Sin(windRotation * Mathf.Deg2Rad));
        }
    }

    private void rotateCondition()
    {
        if(timeElapsed >= rotateFrequency)
        {
            canRotate = true;
            timeElapsed = 0f;
            initialAngle = transform.eulerAngles.z;
            targetAngle = initialAngle + (UnityEngine.Random.Range(0, 2) * 2 - 1) * 90f;
            gameController.SpawnAll();
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
                newAngle = new Vector3(0, 0, targetAngle);
                transform.eulerAngles = newAngle;
                rotateProgress = 0f;
                canRotate = false;
            }

            gameController.SetDirection(newAngle.z);
        }
    }
    public void StopWind()
    {
        Time.timeScale = 0;
        stopWind = true;
    }
}
