using UnityEngine;

public class Coin : MonoBehaviour
{
    public enum CoinType
    {
        Default,
        Blue,
        Red
    }

    public CoinType Type {
        get { return coinType; }
    }

    [SerializeField] private CoinType coinType = CoinType.Default;
    [SerializeField] private int value = 1;
    [SerializeField] private float rotSpeed = 2;

    private void Update()
    {
        transform.Rotate(Vector3.up, rotSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag != "Player") return;

        switch(coinType)
        {
            case CoinType.Default:
                GameManager.Instance.AddScore(value);
                break;

            case CoinType.Red:
                GameManager.Instance.SpawnBlueCoins();
                break;

            case CoinType.Blue:
                GameManager.Instance.AddBonusScore(value);
                break;
        }
        
        Destroy(gameObject);
    }
}
