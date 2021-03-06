﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using System.Linq;
using UnityEngine.EventSystems;

public class LineScript : MonoBehaviour
{
    public GameObject pauseButton;
    public Material material;
    public List<GameObject> dots;
    public GameObject LinePrefab;
    public Transform Parent;
    public Text scoreText;
    public Text gameOverScoreText;
    int score = 0;
    public Text moveText;
    int movesRemaining = 60;
    public RectTransform gameOverPanel;
    public AudioSource popSound;

    private LineRenderer line;
    private Vector3 mousePos;
    private int numberOfPoints = 0;//this is same as index
    private int currLines = 0;
    private DotScript dotScript;
    Vector3 startPosition;
    bool CantDestroy;
    // Start is called before the first frame update
    void Start()
    {
        CantDestroy = false;
    }

    // Update is called once per frame
    void Update()
    {
        
            
        if (Input.GetMouseButton(0))
        {
            if(IsPointerOverUIObject())
                return;
            mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePos.z = 0;

            Collider2D hitCollider = Physics2D.OverlapPoint(mousePos);
            if (hitCollider != null && hitCollider.CompareTag("Dot"))
            {
                startPosition = hitCollider.transform.position;
                if (line == null)
                {
                    GenerateLine(hitCollider.gameObject.GetComponent<SpriteRenderer>().color);
                    line.startColor = hitCollider.gameObject.GetComponent<SpriteRenderer>().color;
                    Debug.Log(hitCollider.gameObject.GetComponent<SpriteRenderer>().color);
                    line.positionCount += 1;
                    line.SetPosition(numberOfPoints, startPosition);
                    //                    Debug.Log(numberOfPoints);
                    dotScript = hitCollider.gameObject.GetComponent<DotScript>();
                    dotScript.traversed = true;
                    dots.Add(hitCollider.gameObject);
                }
                else
                {
                    // Debug.Log(hitCollider.gameObject.GetComponent<SpriteRenderer>().color);
                    // Debug.Log(line.startColor);
                    Color c1 = hitCollider.gameObject.GetComponent<SpriteRenderer>().color;
                    Color c2 = line.startColor;
                    if (c1 == c2 && dots[numberOfPoints] != hitCollider.gameObject && (hitCollider.transform.position - line.GetPosition(numberOfPoints)).magnitude <= 1.1)
                    {
                        //dots.All((obj)
                        if (dots.All((obj) => obj.transform != hitCollider.gameObject.transform))
                        {
                            dots.Add(hitCollider.gameObject);
                            numberOfPoints += 1;

                            line.SetPosition(numberOfPoints, hitCollider.transform.position);
                            // u can set the moves code here
                            line.positionCount += 1;
                            //dots.Remove(dots.FindLastIndex(1));              //ArBeCmDoEvFe  ZtYhXiVsU
                        }
                        
                    }

                }
                
                if (dots.Count >= 2 && hitCollider.gameObject.transform == dots[dots.Count - 2].transform)
                {
                    Debug.Log("same");
                    dots.RemoveAt(dots.Count - 1);
                    line.positionCount -= 1;
                    numberOfPoints -= 1;

                    // can do with bool is well
                    CantDestroy = true;
                }

            }
            if (line != null)
            {
                //                Debug.Log(line.positionCount);

                line.SetPosition(line.positionCount - 1, mousePos);

            }
        }
        if (Input.GetMouseButtonUp(0) && line != null)
        {
            Destroy(line.gameObject);
            if (numberOfPoints > 0)
            {
                foreach (GameObject item in dots)
                {
                    // item.GetComponent<DotScript>().destroyDot();
                    Destroy(item);
                }
                //destroySelectedDots();
            }
            if(numberOfPoints == 1)
            {
                score += 2;
                movesRemaining--;
                scoreText.text = " " + score;
                gameOverScoreText.text = " " + score;
                Debug.Log(score);
            }
            if(numberOfPoints == 2)
            {
                score += 3;
                movesRemaining--;
                scoreText.text = " " + score;
                gameOverScoreText.text = " " + score;
                Debug.Log(score);
            }
            if(numberOfPoints == 3)
            {
                score += 4;
                movesRemaining--;
                scoreText.text = " " + score;
                gameOverScoreText.text = " " + score;
                Debug.Log(score);
            }
            if(numberOfPoints >= 4)
            {
                score += 5;
                movesRemaining--;
                scoreText.text = " " + score;
                gameOverScoreText.text = " " + score;
                Debug.Log(score);
            }
            //score increment
            if(movesRemaining > 1)
            {
                //movesRemaining--;
                moveText.text = "" + movesRemaining;
                line = null;
                numberOfPoints = 0;
                dots.Clear();
                popSound.Play();
            }
            if(movesRemaining == 0)
            {
                Debug.Log("Game Over");
                pauseButton.SetActive(false);
                gameOverPanel.DOAnchorPos(new Vector2(0, 0), 0.25f);
            }
            
            

        }
        
        
    }

    bool IsPointerOverUIObject()
    {
        PointerEventData eventDataCurrentPosition = new PointerEventData(EventSystem.current);
        eventDataCurrentPosition.position = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        List<RaycastResult> result = new List<RaycastResult>();
        EventSystem.current.RaycastAll(eventDataCurrentPosition, result);
        return result.Count > 0;
    }

    bool compareColor(Color c1, Color c2)
    {
        bool b = false;

        b = c1.r - c2.r < 0.02f;
        b = c1.g - c2.g < 0.02f;
        b = c1.b - c2.b < 0.02f;
        return b;
    }
    void removeDot(int index)
    {
        dotScript = dots[index].GetComponent<DotScript>();
        dotScript.traversed = false;
        dots.RemoveAt(index);
    }
    void destroySelectedDots()
    {
        foreach (GameObject item in dots)
        {
            item.GetComponent<DotScript>().destroyDot();
        }
    }
    void CreateLine(Color color)
    {
        line = new GameObject("Line" + currLines).AddComponent<LineRenderer>();
        line.material = material;
        line.startColor = color;
        line.endColor = color;
        line.positionCount = 2;
        line.startWidth = 0.25f;
        line.endWidth = 0.25f;
        line.useWorldSpace = true;
        line.numCapVertices = 90;
    }
    void GenerateLine(Color color)
    {
        line = Instantiate(LinePrefab, Parent).GetComponent<LineRenderer>();
        line.startColor = color;
        line.endColor = color;
        line.positionCount = 1;
    }
}
