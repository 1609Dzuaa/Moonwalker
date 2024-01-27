using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : Singleton<UIManager>
{
    GameObject _loosePanel;

    public override void Awake()
    {
        base.Awake();
        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        _loosePanel = GameObject.FindWithTag("Respawn");
        _loosePanel.SetActive(false);
    }

    public void PopUpLoosePanel()
    {
        _loosePanel.SetActive(true);
    }

    public void PopDownLoosePanel()
    {
        _loosePanel.SetActive(false);
        TimeCountController.Instant._hasPop = false;
        TimeCountController.Instant._elapsedTime = 0;
    }
}
