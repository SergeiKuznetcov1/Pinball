using UnityEngine;

public class SeedControl : MonoBehaviour
{
    public delegate void TileActivated();
    public static event TileActivated OnActivation;
    [SerializeField] private GameObject _sprite;
    public bool Activated { get; private set; }

    private void OnEnable() {
        TileManager.OnPercentReached += ActivateAllTiles;
    }

    private void OnDisable() {
        TileManager.OnPercentReached -= ActivateAllTiles;
    }

	private void OnTriggerEnter2D(Collider2D other) {
        if (other.GetComponent<Ball>()) {
            if (Activated == false) {
                _sprite.SetActive(true);
                OnActivation();
            }
            else if (Activated == true) {
                _sprite.GetComponent<Animator>().SetTrigger("Retriggered");
            } 
        }
    }

    private void OnTriggerExit2D(Collider2D other) {
        if (other.GetComponent<Ball>()) {
            Activated = true;
        }    
    }

    private void ActivateAllTiles() {
        _sprite.SetActive(true);
        Activated = true;
    }
}