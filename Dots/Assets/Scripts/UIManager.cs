using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using DG.Tweening;

public class UIManager : MonoBehaviour
{
    public AudioSource clickSound;
    public RectTransform mainMenu;

    void Start()
    {
        mainMenu.DOAnchorPos(Vector2.zero, 0.25f);
    }
    public void TimeScene()
    {
        clickSound.Play();
        SceneManager.LoadScene(1);
    }
    public void MoveScene()
    {
        SceneManager.LoadScene(2);
    }
}
