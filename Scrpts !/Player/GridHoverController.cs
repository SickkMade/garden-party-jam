using UnityEditor.PackageManager;
using UnityEngine;

public class GridHoverController : MonoBehaviour
{
    [SerializeField]
    private GameObject tileHoverPrefab;
    [SerializeField]
    private LayerMask floorMask;
    [Header("Grid Settings"), SerializeField]
    private float maxDistance = 5;
    private float gridSize = 1;

    //vars
    private GameObject hoverTile;
    private Camera currentCamera;


    void Start()
    {
        currentCamera = GetComponentInChildren<Camera>();
        if (currentCamera == null) Debug.LogError("Player Does Not Have Camera as Child");
        
        hoverTile = Instantiate(tileHoverPrefab);
        hoverTile.SetActive(false);
        hoverTile.transform.localScale = new(gridSize, 1, gridSize);
    }
    void FixedUpdate()
    {
        //Debug.DrawRay(currentCamera.transform.position, currentCamera.transform.forward * 100, Color.red);

        Ray ray = new(currentCamera.transform.position, currentCamera.transform.forward);
        if (Physics.Raycast(ray, out RaycastHit hit, maxDistance, floorMask))
        {
            hoverTile.SetActive(true);

            Vector3 snappedPosition = new(
                Mathf.Floor(hit.point.x / gridSize) * gridSize + (gridSize/2),
                hit.point.y + 0.01f, //to help against z fighting
                Mathf.Floor(hit.point.z / gridSize) * gridSize + (gridSize/2)
            );

            hoverTile.transform.position = snappedPosition;
        }
        else
        {
            hoverTile.SetActive(false);
        }
    }
}
