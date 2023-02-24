using UnityEngine;

public class ShadowEffect : MonoBehaviour
{
    [SerializeField] private GameObject _objToFollow;
    [SerializeField] private Vector3 _shadowOffset;

    private void LateUpdate() {
        transform.position = _objToFollow.transform.position + _shadowOffset;
        transform.rotation = _objToFollow.transform.rotation;
    }
}
