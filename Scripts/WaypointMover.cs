using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveToPoint : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private Transform[] _waypoints;

    private Transform _nextWaypoint;
    private int _indexWaypoint = 0;

    private void Start()
    {
        _nextWaypoint = _waypoints[_indexWaypoint];
    }

    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, _nextWaypoint.position, _speed * Time.deltaTime);

        if (transform.position == _nextWaypoint.position)
            SwitchNext();
    }

    private void SwitchNext()
    {
        _indexWaypoint++;

        if (_indexWaypoint == _waypoints.Length)
            _indexWaypoint = 0;

        _nextWaypoint = _waypoints[_indexWaypoint];
    }
}