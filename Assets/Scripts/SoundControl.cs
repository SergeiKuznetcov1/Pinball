using UnityEngine;

public class SoundControl : MonoBehaviour
{
    private AudioSource _audioSource;

    private void Start() {
        _audioSource = GetComponent<AudioSource>();
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if (_audioSource != null) 
            _audioSource.Play();
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (_audioSource != null && other.name == "Ball") 
            _audioSource.Play();    
    }
}
