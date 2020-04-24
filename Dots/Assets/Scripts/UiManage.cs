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
    public void PauseButton()
    {
        pausePanel.DOAnchorPos(Vector2.zero, 0.25f);
    }

    public void MainMenuButton()
    {
        SceneManager.LoadScene(0);
    }

    public void ResumeButton()
    {
        pausePanel.DOAnchorPos(new Vector2(0,1905), 0.25f);
    }

}
