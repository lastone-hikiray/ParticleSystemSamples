using UnityEngine;

[System.Serializable]

public class MoveToMouse : MonoBehaviour
{

    [SerializeField] private float Speed;
    [SerializeField] private float DistanceFromCamera;
    [SerializeField] private Camera usedCamera;
    private void Reset()
    {
        usedCamera = Camera.main;
        for (int i = 0; i < 10; i++)
        {
            Debug.Log(Mathf.Exp(-i));
        }
    }

    void Update()
    {
        Vector3 MousePosition = Input.mousePosition;
        MousePosition.z = DistanceFromCamera;

        Vector3 MouseScreenToWorld = usedCamera.ScreenToWorldPoint(MousePosition);
        Vector3 Position = Vector3.Lerp(transform.position, MouseScreenToWorld, 1.0f - Mathf.Exp(-Speed * Time.deltaTime));

        transform.position = Position;
    }
}