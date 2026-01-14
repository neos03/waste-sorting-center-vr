using UnityEngine;

public class TrashSpawner : MonoBehaviour
{
    public Transform spawnPoint;
    public GameObject[] trashPrefabs;
    public float spawnInterval = 1.2f;
    public float randomOffset = 0.15f;

    float timer;

    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= spawnInterval)
        {
            timer = 0f;
            Spawn();
        }
    }

    void Spawn()
    {
        if (trashPrefabs == null || trashPrefabs.Length == 0) return;

        var prefab = trashPrefabs[Random.Range(0, trashPrefabs.Length)];
        var pos = spawnPoint.position + spawnPoint.right * Random.Range(-randomOffset, randomOffset);

        Instantiate(prefab, pos, spawnPoint.rotation);
    }
}
