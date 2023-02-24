using UnityEngine;

public class FlipControlSound : MonoBehaviour
{
	private AudioSource _audioSource;
    private bool _playFlipSound;
    private void Awake() {
        _audioSource = GetComponent<AudioSource>();
    }

    private void Update() {
        _playFlipSound = gameObject.GetComponent<FlipControl>().PlayFlipSound;
        if (_playFlipSound && _audioSource != null)
            _audioSource.Play();
    }
}
