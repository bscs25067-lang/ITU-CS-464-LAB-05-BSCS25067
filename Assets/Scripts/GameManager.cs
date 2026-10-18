using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    [SerializeField] private TextMeshProUGUI currentScore;
    [SerializeField] private GameObject winUI;
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

    private void Start()
    {
        UpdateHUD();
        winUI.SetActive(false);
    }

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
        winUI.SetActive(true);
    }

    public void RestartGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
