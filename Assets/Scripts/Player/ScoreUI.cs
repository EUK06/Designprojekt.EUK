using TMPro;
using UnityEngine;

public class ScoreUI : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI scoreText;
    private GameManager gameManager;

    private void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        if (gameManager == null)
        {
            Debug.LogError("GameManager not found in the scene!");
        }
    }

    private void Update()
    {
        UpdateScoreUI();
    }

    private void UpdateScoreUI()
    {
        if (gameManager != null && scoreText != null)
        {
            scoreText.text = "Sacred Objects collected: " + gameManager.GetScore().ToString() + "/10";
        }
    }
}
