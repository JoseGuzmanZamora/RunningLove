using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CityGenerator : MonoBehaviour
{
    public GameObject buildingPrefab;
    private Vector2 sideWalkSize;
    private Vector2 buildingGrid = new Vector2(3, 8);
    private float buildingSizeFactor = 0.8f;
    private MeshRenderer mRenderer;

    void Start()
    {
        mRenderer = gameObject.GetComponent<MeshRenderer>();
        var size = mRenderer.bounds.size;
        sideWalkSize = new Vector2(size.x, size.z);

        var xTerrainSize = sideWalkSize.x / (float) buildingGrid.x;
        var yTerrainSize = sideWalkSize.y / (float) buildingGrid.y;
        GetBuildingPositions(xTerrainSize, yTerrainSize);
    }

    private void GetBuildingPositions(float xTerrainSize, float yTerrainSize)
    {
        var topLeftCorner = new Vector2(mRenderer.bounds.min.x, mRenderer.bounds.max.z);
        for (int x = 1; x <= buildingGrid.x; x++)
        {
            for (int y = 1; y <= buildingGrid.y; y++)
            {
                // Wee need to instantiate the prefab in the specific position
                var newXPosition = topLeftCorner.x + (xTerrainSize * (float) x) - (xTerrainSize / 2f);
                var newZPosition = topLeftCorner.y - (yTerrainSize * (float) y) + (yTerrainSize / 2f);
                var instantiatePosition = new Vector3(newXPosition, 0, newZPosition);
                var newBuilding = Instantiate(buildingPrefab, instantiatePosition, Quaternion.identity);

                // Set building dimensions
                var yScale = Random.Range(10, 50);
                var xzScale = Random.Range(5f, xTerrainSize * buildingSizeFactor);
                newBuilding.transform.localScale = new Vector3(xzScale, yScale, xzScale);

                // Set parent
                newBuilding.transform.SetParent(transform);
            }
        }
    }
}
