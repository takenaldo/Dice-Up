using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public bool isGameOver = false;
    public int score = 0;

    public GameObject dialogGameOver;
    public Ball ballPrefab;
    public Transform ballPrefabParent;

    public TextMeshProUGUI txtScore;

    public TextMeshProUGUI txtDialogScore;
    public TextMeshProUGUI txtBestScore;

    public Sprite[] ballSprites;

    public GameObject lastDroppedBall;

    public GameObject ceiling;
    public GameObject middler;

    public int fallenBalls = 0;


    public int FALLING_THRESHOLD = 7;

    private void Awake()
    {
        if (instance == null)
            instance = this;
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (isGameOver)
        {
            updateScore();
            print("Game Over");
            if(!dialogGameOver.activeSelf)
                dialogGameOver.SetActive(true);
        }
        else
        {
            if (allBallsStopped())
            {
                if (towerReachedMax())
                {
                    HashSet<GameObject> ballsToDrop = getBallsToDrop();

                    foreach (GameObject ball in ballsToDrop)
                    {
                        ball.layer = LayerMask.NameToLayer("no_collision");
                    }
                }
                SpawnBall();
            }
        }
        
    }

    private HashSet<GameObject>  getBallsToDrop()
    {
        int i = 0;
        float middler_y = middler.transform.position.y;
        HashSet<GameObject> ballsToDrop = new HashSet<GameObject>();
        GameObject[] allBalls = GameObject.FindGameObjectsWithTag("ball");
        foreach (GameObject ball in allBalls)
        {
            float ball_y = ball.transform.position.y;

            if (ball_y < middler_y && ball.activeSelf)
            {
                ballsToDrop.Add(ball);
            }
        }
        return ballsToDrop;
    }

    private bool towerReachedMax()
    {
        int i = 0;
        float ceiling_y  = ceiling.transform.position.y;

        GameObject[] allBalls = GameObject.FindGameObjectsWithTag("ball");
        foreach (GameObject ball in allBalls)
        {
            float ball_y = ball.transform.position.y;

            if (ball_y < ceiling_y && ball.activeSelf)
                i++;

        }
        Debug.Log("i is " +i);

        return (i >= FALLING_THRESHOLD);


    }
    private void updateScore()
    {

        if(score > Helper.getHighScore())
        {
            Helper.setHighScore(score);
        }

        txtDialogScore.text = score + "";
        txtBestScore.text = Helper.getHighScore()+"";
    }

    private void SpawnBall()
    {
        Ball b = GameObject.Instantiate(ballPrefab, ballPrefabParent);

    }

    private bool allBallsStopped()
    {
        bool allDropped = false;
        int i = 0;
        GameObject[] allBalls = GameObject.FindGameObjectsWithTag("ball");
        foreach ( GameObject go in allBalls)
        {
            i++;
            
            Ball ball = go.GetComponent<Ball>();
            Vector2 velocity = ball.rb.velocity;



            if (velocity != Vector2.zero)
                Debug.Log(velocity);


            if (velocity == Vector2.zero && ball.dropped)
            {
                
                allDropped = true;
            }
            else
                return false;
        }
        if (allDropped)
        {
            //score = Mathf.Max( allBalls.Length, score);
            score = allBalls.Length + fallenBalls;

            txtScore.text = score + "m";
        }
        return allDropped;
    }
}
