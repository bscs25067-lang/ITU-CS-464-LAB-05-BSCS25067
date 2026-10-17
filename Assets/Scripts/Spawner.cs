using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private float playerRadius;

    [SerializeField] private GameObject coinPrefab;
    [SerializeField] private int maxCoins;
    [SerializeField] private int area;
    [SerializeField] private float interval;

    private float _duration;

    private void Start() => _duration = 0;

    private void Update()
    {
        if (maxCoins >= transform.childCount) return;

        _duration += Time.deltaTime;

        if(_duration >= interval)
        {
            Spawn();
            _duration = 0;
        }
    }

    private void Spawn()
    {
        float x = Random.Range(-area, area + 1);
        float z = Random.Range(-area, area + 1);

        Vector3 spawnPos = new Vector3(x, 0.5f, z);
        if (Vector3.Distance(spawnPos, player.position) < playerRadius) Spawn();

        Instantiate(coinPrefab, spawnPos, Quaternion.identity, transform);
    }
}
