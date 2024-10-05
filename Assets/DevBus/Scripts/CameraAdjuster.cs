using Unity.VisualScripting;
using UnityEngine;

public class CameraAdjuster : MonoBehaviour
{
    public Camera mainCamera;   
    public Transform minPoint; 
    public Transform maxPoint; 

    private void Start()
    {
        AdjustCameraSize();
    }

    void AdjustCameraSize()
    {
        Vector3 minViewportPos = mainCamera.WorldToViewportPoint(minPoint.position);
        Vector3 maxViewportPos = mainCamera.WorldToViewportPoint(maxPoint.position);

        // Kiểm tra xem hai điểm có nằm ngoài camera hay không
        if (minViewportPos.x < 0 || minViewportPos.x > 1 || maxViewportPos.x < 0 || maxViewportPos.x > 1)
        {
            // Nếu một trong hai điểm nằm ngoài khung hình theo trục X, điều chỉnh kích thước camera
            float distanceX = Mathf.Abs(maxPoint.position.x - minPoint.position.x);
            float aspectRatio = (float)Screen.width / (float)Screen.height;

            // Điều chỉnh kích thước orthographicSize dựa trên khoảng cách trục X và tỷ lệ khung hình
            mainCamera.orthographicSize = (distanceX / 2f) / aspectRatio + 1f; // Thêm lề 1 đơn vị
        }
    }
}
