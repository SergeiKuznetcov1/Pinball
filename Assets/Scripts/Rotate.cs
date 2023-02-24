using UnityEngine;

public class Rotate : MonoBehaviour
{
    [SerializeField] private float _rotationSpeed;
    private void FixedUpdate() {
        transform.Rotate(Vector3.forward, _rotationSpeed);
    }
}
