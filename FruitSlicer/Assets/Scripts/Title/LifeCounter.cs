using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LifeCounter : MonoBehaviour
{
    [Header("Gameplay")]
    public int numberofLives;

    [Header("Visuals")]
    public GameObject lifePrefab;
    public GameObject scoreText;
    public GameObject gameOverGroup;

    private List<GameObject> lives;

    // Start is called before the first frame update
    void Start()
    {
        gameOverGroup.SetActive(false);

        lives = new List<GameObject>();
        for(int i=0; i<numberofLives; i++)
        {
            GameObject lifeInstance = Instantiate(lifePrefab, transform);
            lives.Add(lifeInstance);
        }
        
    }

    public void LoseLife()
    {
        numberofLives--;

        //get the last life
        GameObject lastLife = lives[lives.Count - 1];
        lives.Remove(lastLife);

        Destroy(lastLife);

        if(numberofLives <= 0)
        {
            gameOverGroup.SetActive(true);
            Text gameOverText = gameOverGroup.GetComponentInChildren<Text>();

            //get the score
            int score = GameObject.Find("ScoreText").GetComponent<ScoreText>().Score;

            //set the score in game over message
            gameOverText.text = string.Format(gameOverText.text, score);

            scoreText.SetActive(false);
        }
    }

    private void Update()
    {
        if (numberofLives <=0 && Input.GetMouseButtonDown(0))
        {
            //go back to main menu scene
            SceneManager.LoadScene("MainMenu");
        }
    }

}
