using UnityEngine;

public class Patrol : MonoBehaviour
{
    [SerializeField] private float _moveSpeed;
    [SerializeField] private Transform[] _points;
    private Vector3 _curTarget;
    private int _curTargetIndex = 0;
    private void Update() {
        _curTarget = _points[_curTargetIndex % _points.Length].position;
        if (transform.position != _curTarget) 
            transform.position = Vector3.MoveTowards(transform.position, _curTarget, _moveSpeed * Time.deltaTime);
        else 
            _curTargetIndex++;
    }
}
