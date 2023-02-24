using UnityEngine;
using UnityEngine.Tilemaps;

public class TileManager : MonoBehaviour
{
    public delegate void PercentReached();
    public static event PercentReached OnPercentReached;
	[SerializeField] private Tilemap _tilemap;
    [SerializeField] private GameObject _objToInst;
    [SerializeField] private float _offsetAmount;
    [SerializeField] private float _percentToActivateAll;
    private float _totalAmount;
    private float _activatedAmount;

    private void OnEnable() {
        SeedControl.OnActivation += DoAfterActivationProcedure;
    }
    
    private void OnDisable() {
        SeedControl.OnActivation -= DoAfterActivationProcedure;
    }

    private void Start() {
        PlaceObjectOnTile();
    }
    
    private void PlaceObjectOnTile() {
        _tilemap.CompressBounds();
        BoundsInt bounds = _tilemap.cellBounds;
        for (int x = bounds.min.x; x < bounds.max.x; x++) {
            for (int y = bounds.min.y; y < bounds.max.y; y++) {
                Vector3Int cellPos = new Vector3Int(x, y, 0);
                if (_tilemap.GetTile(cellPos) == null) {
                    continue;
                }
                GameObject obj = Instantiate(_objToInst,
                    _tilemap.CellToWorld(cellPos) + new Vector3(_offsetAmount, _offsetAmount, 0.0f),
                    Quaternion.identity, transform);
                obj.name = $"Square x: {x} y: {y}";
                _totalAmount++;
            }
        }
    }

    private void DoAfterActivationProcedure() {
        IncreaseActivatedAmount();
        CheckActivateAllCondition();
    }
    
    private void IncreaseActivatedAmount() {
        _activatedAmount++;
    }

    private void CheckActivateAllCondition() {
        if (((_activatedAmount / _totalAmount) * 100) >= _percentToActivateAll) {
            OnPercentReached();
        }
    }
}
