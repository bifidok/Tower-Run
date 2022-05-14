using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Human : MonoBehaviour
{
    [SerializeField] private Transform _fixationPoint;
    public Transform fixationPoint => _fixationPoint;
    private Animator _animator;
    private Vector3 _randomDirectionExplosion;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }
    public void DestroyHuman()
    {
        _randomDirectionExplosion = new Vector3(Random.Range(0, 30), 0, Random.Range(0,30));
        Rigidbody rigidbody = GetComponent<Rigidbody>();
        Collider collider = GetComponent <BoxCollider>();
        collider.enabled = false;
        rigidbody.velocity =  _randomDirectionExplosion;
        rigidbody.AddExplosionForce(Random.Range(10,30), transform.position, 10, 0, ForceMode.Impulse);
        Destroy(gameObject, 3);
    }

    public void Run()
    {
        _animator.SetBool("Running", true);
    }

    public void StopRun()
    {
        _animator.SetBool("Running", false);
    }
    public void Idle()
    {
        _animator.SetBool("Idle", true);
    }
    public void StopIdle()
    {
        _animator.SetBool("Idle", false);
    }
}
