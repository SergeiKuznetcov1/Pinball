using UnityEngine;

public class RespawnPlayer : MonoBehaviour
{
	[SerializeField] private Transform[] _respawnPos;
    [SerializeField] private float _respawnDelay;
    private Transform _ballPos;

    private void OnTriggerEnter2D(Collider2D other) {
        _ballPos = other.transform;
        other.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        Invoke(nameof(MoveBallToRespawnPoint), _respawnDelay);
    }

    private void MoveBallToRespawnPoint() {
        int respawnPosIndex = Random.Range(0, 2);
        _ballPos.position = _respawnPos[respawnPosIndex].position;
    }
}
