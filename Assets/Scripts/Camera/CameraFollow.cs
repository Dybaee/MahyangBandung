using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField]
    private Transform _player;

    [SerializeField]
    private int _smoothSpeed = 10;
    [SerializeField]
    private Vector3 _offset;

    [SerializeField]
    private float _mixX;
    [SerializeField]
    private float _maxX;
    // Update is called once per frame
    void Update()
    {
        
    }

    
    void LateUpdate()
    {
        Vector3 desiredPosition = _player.position + _offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, _smoothSpeed * Time.deltaTime);
        smoothedPosition = new Vector3(Mathf.Clamp(smoothedPosition.x, _mixX, _maxX), smoothedPosition.y, smoothedPosition.z);
        transform.position = smoothedPosition;
        transform.LookAt(_player);
    }
}
