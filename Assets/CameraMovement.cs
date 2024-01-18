using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] private float speed = 30.0f;
    private Vector3 camMovement;

    private void Start()
    {
        camMovement = Vector3.zero;
    }
    private void Update()
    {
        if (Input.GetKey(KeyCode.RightArrow))
        {
            camMovement.z = 1;
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            camMovement.z = -1;
        }
        if (Input.GetKey(KeyCode.UpArrow))
        {
            camMovement.x = -1;
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            camMovement.x = 1;
        }

        transform.Translate(camMovement * speed * Time.deltaTime, Space.World);
        camMovement = Vector3.zero;
    }

}