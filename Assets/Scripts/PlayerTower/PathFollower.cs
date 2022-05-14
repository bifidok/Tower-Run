using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PathCreation;

    [RequireComponent(typeof(Rigidbody))]
public class PathFollower : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private PathCreator _path;

    private Rigidbody _rigidbody;
    private float _distanceTravelled;
    private Vector3 _nextPoint;

    private void Start()
    {
        _distanceTravelled = 0;
        _rigidbody = GetComponent<Rigidbody>();
        _nextPoint = _path.path.GetPointAtDistance(_distanceTravelled);
        _rigidbody.MovePosition(_nextPoint);
    }

    private void Update()
    {
        Movement();  
    }

    private void Movement()
    {
        _distanceTravelled += Time.deltaTime * _speed;
        _nextPoint = _path.path.GetPointAtDistance(_distanceTravelled,EndOfPathInstruction.Stop);
        _nextPoint.y = transform.position.y;

        transform.LookAt(_nextPoint);
        _rigidbody.MovePosition(_nextPoint);

    }
}
