using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] private float _additionalForce;
    private float _initAdditionalForce;
    private Rigidbody2D _myRigBody;

    private void Awake() {
        _initAdditionalForce = _additionalForce;
        _myRigBody = GetComponent<Rigidbody2D>();
    }

    private void Update() {
        if (TouchTracker.LeftSidePressed && TouchTracker.RightSidePressed || 
            !TouchTracker.LeftSidePressed && !TouchTracker.RightSidePressed)
            {
                _additionalForce = 0.0f;
            }
        else if (TouchTracker.LeftSidePressed)
            _additionalForce = _initAdditionalForce * -1.0f;
        else if (TouchTracker.RightSidePressed)
            _additionalForce = _initAdditionalForce * 1.0f;
    }
	private void OnTriggerStay2D(Collider2D other) {
        SeedControl seedTile = other.GetComponent<SeedControl>();
        

        if (seedTile != null && seedTile.Activated == true) {
            _myRigBody.velocity = new Vector2(_myRigBody.velocity.x + _additionalForce, _myRigBody.velocity.y);
        }

        
    }
}
