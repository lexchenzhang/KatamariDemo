using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private float smoothTime;
    [SerializeField] private Transform target = null;

    private Vector3 _offset;
    private Vector3 _currentVelocity = Vector3.zero;

    private void Awake()
    {
        if (target == null) throw new UnassignedReferenceException("player transform in camera not set");
    }

    void Start()
    {
        _offset = transform.position - target.position;
    }

    void Update()
    {
        Vector3 targetPosition = target.position + _offset;
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref _currentVelocity, smoothTime);
    }
}
