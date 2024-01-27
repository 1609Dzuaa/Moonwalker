using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TimeCountController : Singleton<TimeCountController>
{
    [SerializeField] int _maxTimePlay;
    [SerializeField] Text _timeText;
    public bool _hasPop;
    public float _elapsedTime = 0;

    public override void Awake()
    {
        base.Awake();
        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        _hasPop = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!_hasPop)
        {
            _elapsedTime += Time.deltaTime;

            int time = (int)(_maxTimePlay - _elapsedTime);

            if (time >= 0)
                _timeText.text = "Time Left: " + time.ToString();
            else
            {
                if (!_hasPop)
                {
                    _hasPop = true;
                    UIManager.Instant.PopUpLoosePanel();
                    //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
                }
            }
        }
    }
}
