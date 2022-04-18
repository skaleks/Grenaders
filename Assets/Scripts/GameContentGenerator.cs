using System.Collections.Generic;
using UnityEngine;

public class GameContentGenerator : MonoBehaviour
{
    [SerializeField]
    protected List<GameObject> _enemyList;

    [SerializeField]
    protected List<Vector3> _enemySpawnLocations;

    [SerializeField]
    protected List<GameObject> _bombList;

    [SerializeField]
    protected List<Vector3> _bombSpawnLocations;

    private void Start()
    {
        SpawnOnStart(_enemySpawnLocations, _enemyList);
        SpawnOnStart(_bombSpawnLocations, _bombList);
    }

    public void SpawnOnStart(List<Vector3> locations, List<GameObject> gameObjectList)
    {
        foreach(Vector3 location in locations)
        {
            Instantiate(gameObjectList[Random.Range(0, gameObjectList.Count)], location, Quaternion.identity);
        }
    }


}


