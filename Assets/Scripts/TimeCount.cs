using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeCount : MonoBehaviour
{
    private Slider slider;

    private GameObject player;

    public float timer;
    private float timerBurn = 1f;

    private void Awake()
    {
        GetPreferences();
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (!player)
        {
            return;
        }
        if (timer > 0)
        {
            timer -= timerBurn * Time.deltaTime;
            slider.value = timer;
        }
        else
        {
            GetComponent<GameplayController>().PlayerDied();
            Destroy(player);
        }
    }

    void GetPreferences()
    {
        player = GameObject.Find("Player");
        slider = GameObject.Find("Time Slider").GetComponent<Slider>();

        slider.minValue = 0f;
        slider.maxValue = timer;
        slider.value = slider.maxValue;
    }
}
