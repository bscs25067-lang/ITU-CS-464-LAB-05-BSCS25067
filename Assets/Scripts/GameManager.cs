using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    [SerializeField] private Transform player;
    [SerializeField] private TextMeshProUGUI currentScore;
    [SerializeField] private TextMeshProUGUI bonusScore;
    [SerializeField] private GameObject bonusScorePopup;
    [SerializeField] private GameObject winUI;
    [SerializeField] private ParticleSystem collectFX;
    [SerializeField] private int targetScore;

    private int _currScore;
    private int _bonusCoins;
    private Spawner _spawner;

    private void Awake()
    {
        if(Instance != null)
        {
            Destroy(this);
        }

        Instance = this;
        _spawner = GetComponentInChildren<Spawner>();
    }

    private void Start()
    {
        UpdateHUD();
        winUI.SetActive(false);
    }

    private void Update() => FollowPlayer();

    private void UpdateHUD()
    {
        currentScore.text = $"Score: {_currScore} / {targetScore}";
    }
    private void ShowPopup()
    {
        bonusScore.text = $"Bonus Coins Collected: {_bonusCoins} / 50";
    }


    private void FollowPlayer()
    {
        collectFX.transform.position = player.position;
    }

    public void AddScore(int amount = 1)
    {
        _currScore += amount;
        collectFX.Play();
        UpdateHUD();

        if (_currScore >= targetScore) ShowWinUI();
    }

    public void AddBonusScore(int amount = 1)
    {
        _bonusCoins += amount;
        collectFX.Play();
        bonusScorePopup.SetActive(true);
        ShowPopup();
    }

    public void SpawnBlueCoins() => _spawner.SpawnBlueCoins(50);

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
