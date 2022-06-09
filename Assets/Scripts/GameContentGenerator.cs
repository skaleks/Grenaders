using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(IBombable))]
public class GameContentGenerator : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> _enemyList;
    [SerializeField]
    private List<Vector3> _enemySpawnLocations;
    [SerializeField]
    private List<GameObject> _bombList;
    [SerializeField]
    private List<Vector3> _bombSpawnLocations;

    private Inventory _inventory;

    private void Awake()
    {
        _inventory = new Inventory();
    }

    private void Start()
    {
        SpawnContentOnStart(_enemySpawnLocations, _enemyList);
        SpawnContentOnStart(_bombSpawnLocations, _bombList);
    }

    public void OnBombTriggered(GameObject bomb)
    {
        _inventory.PutBomb(bomb);
        SpawnSameBomb(bomb);
    }


    private void SpawnContentOnStart(List<Vector3> locations, List<GameObject> gameObjectList)
    {
        foreach (Vector3 location in locations)
        {
            Instantiate(gameObjectList[Random.Range(0, gameObjectList.Count)], location, Quaternion.identity);
        }
    }

    public GameObject GetBomb(Vector3 position)
    {
        GameObject bomb = Instantiate(_bombList[0], position, Quaternion.identity);

        return bomb;
    }

    private void SpawnSameBomb(GameObject targetBomb)
    {
        System.Type typeOfTargetBomb =
            targetBomb.GetComponent<IBombable>().GetType();

        GameObject sameBomb =
            _bombList.Find(x => typeOfTargetBomb.IsInstanceOfType(x.GetComponent<IBombable>()));

        Vector3 targetPosition = targetBomb.transform.position;

        Destroy(targetBomb);
        StartCoroutine(SpawnInTime(sameBomb, targetPosition));
    }

    private IEnumerator SpawnInTime(GameObject bomb, Vector3 position)
    {
        yield return new WaitForSeconds(4);

        Instantiate(bomb, position, Quaternion.identity);
    }
}


