using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public void TimeScene()
    {
        SceneManager.LoadScene(1);
    }
    public void MoveScene()
    {
        SceneManager.LoadScene(2);
    }
}
