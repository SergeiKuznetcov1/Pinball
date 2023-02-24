using UnityEngine;

public class FlipControl : MonoBehaviour
{
    enum Flipper { Left, Right }
	[SerializeField] private bool _keyPressed;
    [SerializeField] private float _flipSpeed;
    [Tooltip("Only 1 or -1")]
    [SerializeField] private float _directMultiplayer;
    [SerializeField] private KeyCode _key;
    [SerializeField] private Flipper _flipper;
    private HingeJoint2D _hingeJoint2D;
    private JointMotor2D _jointMotor;
    public bool PlayFlipSound { get; private set; }

    void Start() {
        _hingeJoint2D = GetComponent<HingeJoint2D>();
        _jointMotor = _hingeJoint2D.motor;

    }

    private void Update() {
        if (_flipper == Flipper.Left) {
            MoveFlipper(TouchTracker.LeftSidePressed);
        }
        else if (_flipper == Flipper.Right) {
            MoveFlipper(TouchTracker.RightSidePressed);
        }
    }

    private void MoveFlipper(bool flipperToMove) {
        if (flipperToMove) {
            _jointMotor.motorSpeed = _flipSpeed * _directMultiplayer;
            _hingeJoint2D.motor = _jointMotor;
            PlayFlipSound = true;
        }
        else {
            _jointMotor.motorSpeed = -_flipSpeed * _directMultiplayer;
            _hingeJoint2D.motor = _jointMotor;
            PlayFlipSound = false;
        }
    }
}
