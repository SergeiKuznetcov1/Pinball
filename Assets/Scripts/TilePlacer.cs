using UnityEngine;
using UnityEngine.Tilemaps;

public class TilePlacer : MonoBehaviour
{
	public Tilemap tilemap;
    public Transform ball;
    private Vector3Int location;

    private void Update() {
            Vector3 mp = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            location = tilemap.WorldToCell(mp);
            if (Input.GetMouseButtonDown(1)) {
                GetTile();
            }
    }

    private void GetTile() {
            Vector3 mp = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            location = tilemap.WorldToCell(mp);
            if (tilemap.GetTile(location)) {
                Debug.Log($"Tile location on tilemap is {location}");
                Debug.Log($"Tile location in world is {tilemap.CellToWorld(location)}");
            }
            else {
                Debug.Log("No tile");
            }
            
    }
}
