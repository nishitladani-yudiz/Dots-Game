using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class LineScript : MonoBehaviour
{
    public Material material;
    public List<GameObject> dots;
    public GameObject LinePrefab;
    public Transform Parent;
    public Text scoreText;
    public Text gameOverScoreText;
    int score = 0;
    public Text moveText;
    int movesRemaining = 60;
    public GameObject gameOverPanel;
    public AudioSource popSound;

    private LineRenderer line;
    private Vector3 mousePos;
    private int numberOfPoints = 0;//this is same as index
    private int currLines = 0;
    private DotScript dotScript;
    Vector3 startPosition;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {

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

                        dots.Add(hitCollider.gameObject);
                        numberOfPoints += 1;

                        line.SetPosition(numberOfPoints, hitCollider.transform.position);
                        // u can set the moves code here
                        line.positionCount += 1;


                    }

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
                scoreText.text = " " + score;
                gameOverScoreText.text = " " + score;
                Debug.Log(score);
            }
            if(numberOfPoints == 2)
            {
                score += 3;
                scoreText.text = " " + score;
                gameOverScoreText.text = " " + score;
                Debug.Log(score);
            }
            if(numberOfPoints == 3)
            {
                score += 4;
                scoreText.text = " " + score;
                gameOverScoreText.text = " " + score;
                Debug.Log(score);
            }
            if(numberOfPoints >= 4)
            {
                score += 5;
                scoreText.text = " " + score;
                gameOverScoreText.text = " " + score;
                Debug.Log(score);
            }
            //score increment
            if(movesRemaining > 1)
            {
                movesRemaining--;
                moveText.text = "" + movesRemaining;
                line = null;
                numberOfPoints = 0;
                dots.Clear();
                popSound.Play();
            }
            else
            {
                Debug.Log("Game Over");
                gameOverPanel.SetActive(true);
            }
            
            

        }

        
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
