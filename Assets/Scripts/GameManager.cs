using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public List<GameObject> targets;
    //public GameObject[] targets2;
    private float spawnRate = 1.0f;
    public GameObject titleScreen;
    public Button restartButton;
    public bool isGameActive;
    private int score;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI gameOverText;

    // Start is called before the first frame update
    void Start()
    {
        //isGameActive = true;
        //StartCoroutine(SpawnTarget());
        //score = 0;
        //scoreText.text = "Score: " + score;
        //UpdateScore(0);

        //gameOverText.gameObject.SetActive(true);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator SpawnTarget()
    {
       // while(true)
        while(isGameActive)
        {
            yield return new WaitForSeconds(spawnRate);
            int index = Random.Range(0, targets.Count);
            Instantiate(targets[index]);
        }
    }

    public void UpdateScore(int scoreToAdd)
    {
        score += scoreToAdd;
        scoreText.text = "Score: " + score;
    }

    public void GameOver()
    {
        restartButton.gameObject.SetActive(true);
        gameOverText.gameObject.SetActive(true);
        isGameActive = false;
    }



    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void StartGame(int difficulty)
    {
        isGameActive = true;
        StartCoroutine(SpawnTarget());
        score = 0;
        spawnRate /= difficulty;
        //scoreText.text = "Score: " + score;
        UpdateScore(0);
        //gameOverText.gameObject.SetActive(true);
        titleScreen.gameObject.SetActive(false);
    }
}
