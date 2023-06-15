using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private float moveSpeed;
    [SerializeField] private Vector3 cameraOffset;

    void Start()
    {
        if (!target) target = FindObjectOfType<PlayerController>().transform;
    }

    private void FixedUpdate()
    {
        Vector3 targetPos = new Vector3(target.position.x, target.position.y, target.position.z) + cameraOffset;
        transform.position = Vector3.Lerp(transform.position, targetPos, moveSpeed * Time.deltaTime);
    }
}
