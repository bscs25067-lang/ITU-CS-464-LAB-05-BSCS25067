using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    [SerializeField] private TextMeshProUGUI currentScore;
    [SerializeField] private int targetScore;

    private int _currScore;

    private void Awake()
    {
        if(Instance != null)
        {
            Destroy(this);
        }

        Instance = this;
    }

    private void Start() => UpdateHUD();

    private void UpdateHUD()
    {
        currentScore.text = $"Score: {_currScore} / {targetScore}";
    }

    public void AddScore(int amount = 1)
    {
        _currScore += amount;
        UpdateHUD();

        if (_currScore >= targetScore) ShowWinUI();
    }

    private void ShowWinUI()
    {
        Time.timeScale = 0f;
    }
}
