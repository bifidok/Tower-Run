using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTracker : MonoBehaviour
{
    [Header("Config")]
    [SerializeField] private Vector3 _offsetPosition;
    [SerializeField] private Vector3 _offsetRotation;
    [SerializeField] private float _offsetIndex;
    [Header("")]
    [SerializeField] private PlayerTower _playerTower;

    private void OnEnable()
    {
        _playerTower.onHumanAdded += HumanAdded;
    }

    private void OnDisable()
    {
        _playerTower.onHumanAdded -= HumanAdded;
    }
    private void Update()
    {
        UpdatePosition();
    }
    private void UpdatePosition()
    {
        transform.position = _playerTower.transform.position;
        transform.localPosition += _offsetPosition;
        Vector3 lookAtPoint = _playerTower.transform.position + _offsetRotation;

        transform.LookAt(lookAtPoint);
    }

    private void HumanAdded(int count)
    {
        _offsetPosition += (Vector3.up + Vector3.back) * count * _offsetIndex;
        UpdatePosition();
    }
}
