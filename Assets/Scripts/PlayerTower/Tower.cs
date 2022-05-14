using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{

    [SerializeField] private Human _human;
    private List<Human> _humaninTower;
    [SerializeField] private CheckForEndLevel _checkForEndLevel;



    private void Start()
    {
        _humaninTower = new List<Human>();
        int humanInTowerCount = Random.Range(2, 7);
        SpawnHumans(humanInTowerCount);
    }

    private void SpawnHumans(int humanCount)
    {
        Vector3 spawnPoint = transform.position;
        for (int i = 0; i < humanCount; i++)
        {
            Human spawnedHuman = _human;
            _humaninTower.Add(Instantiate(spawnedHuman, spawnPoint, Quaternion.identity, transform));
            _humaninTower[i].transform.localPosition = new Vector3(0, spawnPoint.y, 0);
            spawnPoint.y = _humaninTower[i].fixationPoint.position.y;
        }
    }

    public List<Human> CollectHumans(Transform distanceChecker, float fixationMaxDistance)
    {
        for (int i = 0; i < _humaninTower.Count; i++)
        {
            float distanceBetweenHumans = CheckDistanceY(distanceChecker, _humaninTower[i].fixationPoint.transform);

            if(distanceBetweenHumans < fixationMaxDistance)
            {
                List<Human> humansToCollect = _humaninTower.GetRange(0, i + 1);
                _humaninTower.RemoveRange(0, i + 1);
                RemoveOtherHumans();
                return humansToCollect;
            }
        }
        RemoveOtherHumans();
        return null;
    }

    private float CheckDistanceY(Transform distanceChecker, Transform fixationPoint)
    {
        Vector3 collectingHuman = new Vector3(0, distanceChecker.position.y, 0);
        Vector3 collisedHuman = new Vector3(0, fixationPoint.position.y, 0);
        return Vector3.Distance(collectingHuman, collisedHuman);
    }

    private void RemoveOtherHumans()
    {
        for (int j = 0; j < _humaninTower.Count; j++)
        {
            _humaninTower[j].gameObject.AddComponent(typeof(Rigidbody));
            Human human = _humaninTower[j].GetComponent<Human>();
            human.DestroyHuman();
        }
        transform.DetachChildren();
        Destroy(gameObject);
    }
}
