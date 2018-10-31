using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

    public GameObject hazard;
    public Vector3 spawnValues;
    public int hazardCount;
    public float spawnWait;
    public float startWait;
    public float waveWait;

    public Text ScoreText;
    private int score;

    public Text RestartText;
    public Text gameOverText;
    private bool gameOver;
    private bool Restart;

    private void Start()
    {
        StartCoroutine (SpawnWaves());
        score = 0;
        UpdateScore();
        gameOver = false;
        Restart = false;
        RestartText.text = "";
        gameOverText.text = ""; 
    }

    void Update()
    {
        if (Restart)
        {
         if(Input.GetKeyDown(KeyCode.R))
            {
                UnityEngine.SceneManagement.SceneManager.LoadScene(0);
            }
        }
        if (Input.GetKey("escape"))
        {
            Application.Quit();
        }
    }
    IEnumerator SpawnWaves()
    {
        while (true)
        {
            for (int i = 0; i < hazardCount; i++)
            {
                yield return new WaitForSeconds(startWait);
                Vector3 spawnPosition = new Vector3(Random.Range(-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
                Quaternion spawnRotation = Quaternion.identity;
                Instantiate(hazard, spawnPosition, spawnRotation);
                yield return new WaitForSeconds(spawnWait);

            }
            yield return new WaitForSeconds(waveWait);

            if (gameOver)
            {
                RestartText.text = "Press 'R' To Restart!";
                Restart = true;
                break;
            }
        }
    }

    public void AddScore(int newScoreValue)
    {
        score += newScoreValue;
        UpdateScore();
    }

    void UpdateScore()
    {
        ScoreText.text = "Score: " + score;
    }

    public void GameOver()
    {
        gameOverText.text = "Game Over!";
        gameOver = true;
    }
}



