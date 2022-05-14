using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PathCreation;

public class LevelGeneration : MonoBehaviour
{
    public int TowerCount;
    [SerializeField] private PathCreator _path;
    [SerializeField] private Tower _tower;

    private void Start()
    {
        GenerateLevel();
    }

    private void GenerateLevel()
    {
        float roadLength = _path.path.length;
        float distanceBetweenTower = roadLength / TowerCount;
        float distanceToSpawn = 0;
        for (int i = 0; i < TowerCount; i++)
        {
            distanceToSpawn += distanceBetweenTower;
            Vector3 spawnPoint = _path.path.GetPointAtDistance(distanceToSpawn,EndOfPathInstruction.Stop);

            var newTower = Instantiate(_tower, spawnPoint, Quaternion.identity);
        }
    }
}
