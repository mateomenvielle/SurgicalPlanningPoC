using UnityEngine;

public class PlaneController : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Transform bone;

    [Header("Movement")]
    [SerializeField] private float step = 0.1f;

    private Vector3 axis;

    void Start()
    {
        axis = (bone != null) ? bone.up : transform.up;
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.UpArrow))
            MoveUp();

        if (Input.GetKey(KeyCode.DownArrow))
            MoveDown();
    }

    public void MoveUp()
    {
        transform.position += axis * step;
    }

    public void MoveDown()
    {
        transform.position -= axis * step;
    }
}