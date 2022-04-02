using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public GameObject winPanel;
    public GameObject failPanel;
    public Text diamondScoreText;
    [HideInInspector] public int diamondScore;
    [HideInInspector] public bool isGameOver = false;
    [HideInInspector] public bool isGameWin = false;
    [HideInInspector] public bool isFinish = false;
    [HideInInspector] public bool isGameStart = false;

    private void Awake()
    {
        instance = this;
    }

    public void UpdateScore(int value)
    {
        diamondScore += value;
        diamondScoreText.text = diamondScore.ToString();
    }

    public void WinPanel()
    {
        StartCoroutine(WinPanelDelay());
    }

    IEnumerator WinPanelDelay()
    {
        yield return new WaitForSeconds(1f);
        winPanel.SetActive(true);
    }

    public void FailPanel()
    {
        StartCoroutine(FailPanelDelay());
    }

    IEnumerator FailPanelDelay()
    {
        yield return new WaitForSeconds(1f);
        failPanel.SetActive(true);
    }
    
    public void Retry()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
