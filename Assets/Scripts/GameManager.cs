using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    [SerializeField] private TextMeshProUGUI currentScore;

    private int score;

    private void Awake()
    {
        if(Instance != null)
        {
            Destroy(this);
        }

        Instance = this;
    }

    public void AddScore(int amount = 1)
    {
        score += amount;
        currentScore.text = $"Score: {score}";
    }
}
