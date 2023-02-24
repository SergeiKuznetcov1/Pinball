using UnityEngine;

public class TintChanger : MonoBehaviour
{
    [SerializeField] private int _minBound;
    [SerializeField] private int _maxBound;
    [SerializeField] private int _divider;
	private SpriteRenderer _spriteRenderer;
    private float _extractionNum;

    private void Start() {
        _extractionNum = (float)Random.Range(_minBound, _maxBound) / _divider;
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _spriteRenderer.color = new Color(_spriteRenderer.color.r - _extractionNum,
                                          _spriteRenderer.color.g - _extractionNum,
                                          _spriteRenderer.color.b - _extractionNum);
    }
}
