using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class GameSession : MonoBehaviour
{
    //config params
   [Range(0.1f, 10f)] [SerializeField] public float gameSpeed;
    [SerializeField] int pointsPerBlock = 2;
    [SerializeField] TextMeshProUGUI scoreText;
    float currentSpeed;
    //state variable
    [SerializeField] int currentScore = 0;

    private void Awake()
    {
        int gameStatusCount = FindObjectsOfType<GameSession>().Length;
        if (gameStatusCount > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    private void Start()
    {
        scoreText.text = currentScore.ToString();
        currentSpeed = gameSpeed;
    }
    // Update is called once per frame
    void Update()
    {
        //Time.timeScale = gameSpeed;
        if(gameSpeed != currentSpeed)
        {
            GameObject.Find("ball3").GetComponent<Rigidbody2D>().velocity = GameObject.Find("ball3").GetComponent<Rigidbody2D>().velocity * gameSpeed;
            currentSpeed = gameSpeed;
        }
    }
    public void AddToScore()
    {
        currentScore += pointsPerBlock;
        scoreText.text = currentScore.ToString();
    }

    public void ResetGame()
    {
        Destroy(gameObject);
    }
}
