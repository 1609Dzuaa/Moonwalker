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
        if (_loosePanel)
            _loosePanel.SetActive(false);
        if (_winPanel)
            _winPanel.SetActive(false);
    }

    public void PopUpLoosePanel()
    {
        if (_winPanel.activeInHierarchy)
            return;

        _loosePanel.SetActive(true);
    }

    public void PopDownLoosePanel()
    {
        if (_loosePanel)
            _loosePanel.SetActive(false);
        TimeCountController.Instant._hasPop = false;
        TimeCountController.Instant._elapsedTime = 0;
    }

    public void PopDownWinPanel()
    {
        if (_winPanel)
            _winPanel.SetActive(false);
    }

    public IEnumerator PopUpWinPanel()
    {
        yield return new WaitForSeconds(_delaySpawnWinPanel);

        _winPanel.SetActive(true);
    }

}
