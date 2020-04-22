using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using DG.Tweening;

public class UIManager : MonoBehaviour
{
    public RectTransform mainMenu;

    void Start()
    {
        mainMenu.DOAnchorPos(Vector2.zero, 0.25f);
    }
    public void TimeScene()
    {
        SceneManager.LoadScene(1);
    }
    public void MoveScene()
    {
        SceneManager.LoadScene(2);
    }
}
