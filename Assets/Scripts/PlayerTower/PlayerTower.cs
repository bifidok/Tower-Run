using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTower : MonoBehaviour
{
    public event Action<int> onHumanAdded;

    [SerializeField] private float _fixationMaxDistance;
    [SerializeField] private HumanCountText _humanCountText;

    [SerializeField] private Human _startHuman;
    [SerializeField] private Transform _distanceChecker;
    [SerializeField] private BoxCollider _collider;
    [SerializeField] private CheckForEndLevel _checkForEndLevel;
    [HideInInspector] public List<Human> _human;
    private Vector3 _startSpawnPoint;

    private void Start()
    {
        _startSpawnPoint = transform.position;
        _human = new List<Human>();
        SpawnStartHuuman();
        _human[0].StopIdle();
        _human[0].Run();
        onHumanAdded?.Invoke(_human.Count);
    }

    private void SpawnStartHuuman()
    {
        _human.Add(Instantiate(_startHuman, _startSpawnPoint,Quaternion.identity, transform));
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.TryGetComponent(out Human human))
        {
            Tower collisionTower = human.GetComponentInParent<Tower>();
            if(collisionTower != null)
                {
                List<Human> collectedHumans = collisionTower.CollectHumans(_distanceChecker, _fixationMaxDistance);

                if(collectedHumans != null)
                    {
                    _human[0].StopRun();
                    _human[0].Idle();
                        for (int i = collectedHumans.Count - 1; i >= 0; i--)
                        {
                        Human insertHuman = collectedHumans[i];
                        InsertHumans(insertHuman);
                        _humanCountText.UpdateText(_human.Count);
                    }
                    onHumanAdded?.Invoke(_human.Count);
                    _human[0].StopIdle();
                    _human[0].Run();
                }
                _checkForEndLevel.UpdateTowerCount(_human.Count);

            }

        }
    }

    private void InsertHumans(Human collectedHuman)
    {
        _human.Insert(0, collectedHuman);
        SetHumanPosition(collectedHuman);
    }

    private void SetHumanPosition(Human human)
    {
        human.transform.parent = transform;
        _human[0].transform.localPosition = new Vector3(0, human.transform.localPosition.y, 0);
        human.transform.localRotation = Quaternion.identity;
        DisplaceChecker();
    }

    private void DisplaceChecker()
    {
        float checkerPositionY = 0.1f;
        _distanceChecker.position = new Vector3(_distanceChecker.position.x,checkerPositionY, _distanceChecker.position.z);
    }
}
