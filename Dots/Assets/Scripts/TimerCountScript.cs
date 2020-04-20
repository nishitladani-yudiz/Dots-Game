using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerCountScript : MonoBehaviour
{
    public Text timeText;
    int timerq = 60;
    bool isTimeOver = false;
    public GameObject gameOverPanel;
    
    void Start()
    {
        StartCoroutine(Time());
    }

    // Update is called once per frame
    IEnumerator Time()
    {
        while(true)
        {
            yield return new WaitForSeconds(1);
            if(timerq > 0)
            {
                timerq--;
                timeText.text = timerq.ToString();
                //Debug.Log(timerq);
            }
            else
            {
                timeText.text = "Time's UP";
                //Debug.Log("Game Over");
                isTimeOver = true;
                gameOverPanel.SetActive(true);
            }
            
        }
    }
}
