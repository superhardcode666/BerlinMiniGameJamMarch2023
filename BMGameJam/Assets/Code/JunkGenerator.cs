using System.Collections.Generic;
using UnityEngine;

public class JunkGenerator : MonoBehaviour
{
    public float spawnRange;
    public float amountToSpawn;
    public GameObject junkObject;
    public float startSafeRange;
    private readonly List<GameObject> _objectsToPlace = new();
    private Vector3 _spawnPoint;

    // Start is called before the first frame update
    private void Start()
    {
        for (var i = 0; i < amountToSpawn; i++)
        {
            PickSpawnPoint();

            //pick new spawn point if too close to player start
            while (Vector3.Distance(_spawnPoint, Vector3.zero) < startSafeRange) PickSpawnPoint();

            _objectsToPlace.Add(Instantiate(junkObject, _spawnPoint,
                Quaternion.Euler(Random.Range(0f, 360f), Random.Range(0f, 360f), Random.Range(0f, 360f))));
            _objectsToPlace[i].transform.parent = transform;
        }

        junkObject.SetActive(true);
    }

    private void PickSpawnPoint()
    {
        _spawnPoint = new Vector3(
            Random.Range(-1f, 1f),
            Random.Range(-1f, 1f),
            Random.Range(-1f, 1f));

        if (_spawnPoint.magnitude > 1) _spawnPoint.Normalize();

        _spawnPoint *= spawnRange;
    }
}