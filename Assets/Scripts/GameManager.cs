using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public int totalObjects = 10; // Total number of objects to be picked up
    public int score = 0; // Current score
    public bool isGameOver = false;
    

    // Other GameManager code...

    public int GetScore()
    {
        return score;
    }

    public static object Instance { get; internal set; }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }

    public void AddScore(int scoreValue)
    {
        
            

        score += scoreValue;
        Debug.Log("Score: " + score);

        if (score >= totalObjects)
        {
            Debug.Log("Congratulations! You've collected all objects!");
            isGameOver = true;
            // Add code to handle game over or victory condition here
        }
    }

    public void ResetScore()
    {
        score = 0;
        Debug.Log("Score reset!");
    }

    public void Update()
    {
        if (isGameOver)
        {
            ResetScore();
            SceneManager.LoadScene(3);
        }
    }
}
