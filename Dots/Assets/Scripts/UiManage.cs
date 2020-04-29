using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using DG.Tweening;

public class UiManage : MonoBehaviour
{
    public RectTransform pausePanel;
    public RectTransform gameOverPanel;
    public void RestartButton()
    {
        gameOverPanel.DOAnchorPos(Vector2.zero, 0.25f);
        SceneManager.LoadScene(1);
    }

    public void TRestartButton()
    {
        gameOverPanel.DOAnchorPos(Vector2.zero, 0.25f);
        SceneManager.LoadScene(2);
    }

    public void PauseButton()
    {
        pausePanel.DOAnchorPos(Vector2.zero, 0.25f);
        StartCoroutine(Wait());
    }

    public void MainMenuButton()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1f;
    }

    public void ResumeButton()
    {
        pausePanel.DOAnchorPos(new Vector2(0,1905), 0.25f);
        Time.timeScale = 1f;
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(0.5f);
        Time.timeScale = 0f;
    }
}
