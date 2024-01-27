using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeCountController : MonoBehaviour
{
    [SerializeField] int _maxTimePlay;
    [SerializeField] Text _timeText;

    // Update is called once per frame
    void Update()
    {
        int time = (int)(_maxTimePlay - Time.time);

        _timeText.text = "Time Left: " + time.ToString();
        //Debug.Log("Time: " + time);
    }
}
