using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;
using System;
using System.Threading;
using Random = UnityEngine.Random;

public class SpawnableObjectHandler : MonoBehaviour
{
    [SerializeField] private SpawnableObject fishPrefab;
    [SerializeField] private SpawnableObject hijaiyahPrefab;

    private CancellationTokenSource spawnCancellation;
    private int _hijaiyahCount = 20;

    private List<GameObject> fishObjectPool = new List<GameObject>();
    private List<GameObject> hijaiyahObjectPool = new List<GameObject>();

    private void Awake()
    {
        InstantiateObject(fishPrefab.gameObject, 10, fishObjectPool);
        InstantiateObject(hijaiyahPrefab.gameObject, 10, hijaiyahObjectPool);
    }

    private void OnApplicationQuit()
    {
        OnGameStopped();
    }

    private GameObject GetObject(List<GameObject> sourcePool, GameObject fallbackObject)
    {
        foreach (GameObject obj in sourcePool)
        {
            if (obj.gameObject.activeInHierarchy) continue;
            return obj;
        }

        return InstantiateObject(fallbackObject, 1, sourcePool);
    }

    private GameObject InstantiateObject(GameObject obj, int count, List<GameObject> targetPool)
    {
        GameObject spawnedObj = null;
        for (int i = 0; i < count; i++)
        {
            spawnedObj = Instantiate(obj);
            spawnedObj.SetActive(false);
            targetPool.Add(spawnedObj);
        }

        return spawnedObj;
    }

    public void OnGameStarted()
    {
        spawnCancellation = new CancellationTokenSource();
        float hijaiyahSpawnDelay = LevelHandler.MaxDuration / _hijaiyahCount;

        foreach(GameObject obj in fishObjectPool)
        {
            obj.SetActive(false);
        }

        foreach (GameObject obj in hijaiyahObjectPool)
        {
            obj.SetActive(false);
        }

        HandleObjectSpawn(fishObjectPool, () => { return Random.Range(hijaiyahSpawnDelay/3, hijaiyahSpawnDelay/2); }, fishPrefab.gameObject);
        HandleObjectSpawn(hijaiyahObjectPool, () => { return hijaiyahSpawnDelay; }, hijaiyahPrefab.gameObject);
    }

    public void OnGameStopped()
    {
        if(spawnCancellation != null)
        {
            spawnCancellation.Cancel();
        }
    }

    private async void HandleObjectSpawn(List<GameObject> sourcePool, Func<float> delay, GameObject fallbackObject)
    {
        try
        {
            while (true)
            {
                if (Time.timeScale <= 0) continue;

                SpawnableObject obj = GetObject(sourcePool, fallbackObject).GetComponent<SpawnableObject>();
                obj.gameObject.SetActive(true);
                obj.Move(Random.Range(-1f, 1f) >= 0 ? 1 : -1);

                await Task.Delay(TimeSpan.FromSeconds(delay()), cancellationToken: spawnCancellation.Token);
            }
        }
        catch(Exception)
        {
            if(spawnCancellation != null)
            {
                spawnCancellation.Dispose();
            }
            spawnCancellation = null;
        }
        
    }
}
