using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : Singleton<UIManager>
{
    GameObject _loosePanel;
    GameObject _winPanel;

    [SerializeField] float _delaySpawnWinPanel;

    public override void Awake()
    {
        base.Awake();
        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        _loosePanel = GameObject.FindWithTag("Loser");
        _winPanel = GameObject.FindWithTag("Winner");
        _loosePanel.SetActive(false);
        _winPanel.SetActive(false);
    }

    public void PopUpLoosePanel()
    {
        _loosePanel.SetActive(true);
    }

    public void PopUpWinPanel()
    {
        _winPanel.SetActive(true);
    }

    public void PopDownLoosePanel()
    {
        _loosePanel.SetActive(false);
        TimeCountController.Instant._hasPop = false;
        TimeCountController.Instant._elapsedTime = 0;
    }

    public void PopDownWinPanel()
    {
        _winPanel.SetActive(false);
    }
}
