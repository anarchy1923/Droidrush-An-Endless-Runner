using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public bool gameStarted;
    public GameObject platformSpawner;
    public Text highScoreText;
    public Text scoreText;
    public GameObject gamePlayUI;
    public GameObject menuUI;

    AudioSource audioSource;
    public AudioClip[] gameMusic;
    

    int score = 0;
    int highScore = 0;



    private void Awake()
    {
        if(instance == null)
        {
            instance = this; // we check if the gameManager is called before start, if the instance is not set to anything, we set our instance to this object. 
        }

        audioSource = GetComponent<AudioSource>();

    }
    // Start is called before the first frame update
    void Start() 
    {
        highScore = PlayerPrefs.GetInt("HighScore");
        highScoreText.text = "Best Score : " + highScore;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!gameStarted)
        {
            if (Input.GetMouseButtonDown(0))
            {
                GameStart(); 
            }
        }
        
    }


    public void GameStart()
    {
        gameStarted = true;
        platformSpawner.SetActive(true);
        menuUI.SetActive(false);
        gamePlayUI.SetActive(true);
        StartCoroutine("UpdateScore");

        //[play audio
        audioSource.clip = gameMusic[1];

        audioSource.Play();
    }

    public void GameOver()
    {
        platformSpawner.SetActive(false);
        StopCoroutine("UpdateScore");
        SaveHighScore();
        Invoke("ReloadLevel", 1f);
    }

    void ReloadLevel()
    {
        SceneManager.LoadScene("Game");
    }

    IEnumerator UpdateScore()
    {
        while (true)
        {
            yield return new WaitForSeconds(1f);

            score++;
            scoreText.text = score.ToString();    // converts the score integer to the string. 
            //print(score);

        }
    }

    

    public void IncrementScore()
    {
        score += 2; //score  is score + 2
        scoreText.text = score.ToString();

        audioSource.PlayOneShot(gameMusic[2], 0.2f);
    }
    void SaveHighScore()
    {
        if (PlayerPrefs.HasKey("HighScore"))
        {
            //we already have a highscore
            if(score > PlayerPrefs.GetInt("HighScore"))
            {
                PlayerPrefs.SetInt("HighScore", score);
            }

        }
        else
        {
            //playing for the first time
            PlayerPrefs.SetInt("HighScore", score);
        }
    }

}
