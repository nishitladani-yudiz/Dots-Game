using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UiManage : MonoBehaviour
{
    public GameObject pausePanel;
    public void RestartButton()
    {
        SceneManager.LoadScene(2);
    }
    public void PauseButton()
    {
        pausePanel.SetActive(true);
        Time.timeScale = 0f;
    }

    public void MainMenuButton()
    {
        SceneManager.LoadScene(0);
    }

    public void ResumeButton()
    {
        pausePanel.SetActive(false);
        StartCoroutine(Wait());
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(0.5f);
    }

}
