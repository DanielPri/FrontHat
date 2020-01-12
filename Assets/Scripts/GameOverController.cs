using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverController : MonoBehaviour
{
    Transform gotCaught;
    Transform crashed;
    HatController hatController;
    WindController wind;

    float timer;
    public int seconds;

    // Start is called before the first frame update
    void Start()
    {
        gotCaught = gameObject.transform.GetChild(0);
        crashed = gameObject.transform.GetChild(1);
        hatController = GameObject.Find("Hat").GetComponent<HatController>();
        wind = GameObject.Find("Wind").GetComponent<WindController>();
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        seconds = (int)(timer % 60);

        if (hatController.gotCaught)
        {
            gotCaught.gameObject.SetActive(true);

            if (Input.anyKeyDown)
            {
                Time.timeScale = 1;
                gotCaught.gameObject.SetActive(false);
                hatController.gotCaught = false;
                wind.stopWind = false;
                timer = 0;
            }
        }

        if (hatController.crashed)
        {
            crashed.gameObject.SetActive(true);

            if (Input.anyKeyDown)
            {
                Time.timeScale = 1;
                crashed.gameObject.SetActive(false);
                hatController.crashed = false;
                wind.stopWind = false;
                timer = 0;
            }
        }
    }
}
