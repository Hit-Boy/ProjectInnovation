using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ControlCannon : MonoBehaviour
{
    [SerializeField] private Transform _cannonCart;
    [SerializeField] private Transform _cannonBarrel;
    [SerializeField] private Transform _firePoint;
    [SerializeField] private float _sensitivityX;
    [SerializeField] private float _sensitivityY;
    [SerializeField] private float _forceSensitivity;
    [SerializeField] private GameObject _cannonBall;
    [SerializeField] private float _maximumForce;
    [SerializeField] private float _minimumForce;
    private bool _leftTouch = false;
    private int leftTouchId;

    private bool _rightTouch = false;
    private int rightTouchId;

    private float _fireStrength;
    // Update is called once per frame
    void Update()
    {
        //Debug.Log(Display.main.systemWidth);

        Touch[] touches = Input.touches;
        for (int i = 0; i < Input.touchCount; i++)
        {
            if (touches[i].phase == TouchPhase.Began && !_leftTouch && touches[i].position.x < Display.main.systemWidth / 2)
            {
                leftTouchId = touches[i].fingerId;
                _leftTouch = true;
                Debug.Log(_leftTouch);
            }

            if (touches[i].phase == TouchPhase.Began && !_rightTouch && touches[i].position.x > Display.main.systemWidth / 2)
            {
                rightTouchId = i;
                _rightTouch = true;
                Debug.Log(_rightTouch);
            }
        }
        Touch leftTouch = Array.Find(touches, x => x.fingerId == leftTouchId);
        Touch rightTouch = Array.Find(touches, x => x.fingerId == rightTouchId);
        //Debug.Log(leftTouch.fingerId);
        if (Input.touchCount > 0 && _leftTouch && leftTouch.phase == TouchPhase.Ended)
        {
            _leftTouch = false;
            Debug.Log(_leftTouch);
            //leftTouchIndex = -1;
        }

        if (Input.touchCount > 0 && _rightTouch && rightTouch.phase == TouchPhase.Ended)
        {
            _rightTouch = false;
            Debug.Log(_rightTouch);
            if(_fireStrength > _minimumForce) 
            FireCannon(_fireStrength);
            _fireStrength = 0;
            //rightTouchIndex = -1;
        }
        if (_leftTouch)
        {
            Debug.Log(_cannonBarrel.eulerAngles.z);
            //if (_cannonBarrel.eulerAngles.z <= 358 && _cannonBarrel.eulerAngles.z >= 270)
            _cannonBarrel.eulerAngles = new Vector3(_cannonBarrel.eulerAngles.x, _cannonBarrel.eulerAngles.y, -leftTouch.deltaPosition.y * _sensitivityY + _cannonBarrel.eulerAngles.z);
            //if (_cannonBarrel.eulerAngles.z > 358)
               // _cannonBarrel.eulerAngles = new Vector3(_cannonBarrel.eulerAngles.x, _cannonBarrel.eulerAngles.y, 358);
           // else if (_cannonBarrel.eulerAngles.z < 270)
               // _cannonBarrel.eulerAngles = new Vector3(_cannonBarrel.eulerAngles.x, _cannonBarrel.eulerAngles.y, 270);
            _cannonCart.eulerAngles = new Vector3(_cannonCart.eulerAngles.x, leftTouch.deltaPosition.x * _sensitivityX + _cannonCart.eulerAngles.y, _cannonCart.eulerAngles.z);
        }

        if (_rightTouch)
        {
            _fireStrength -= rightTouch.deltaPosition.y * _forceSensitivity;
            if (_fireStrength < 0)
                _fireStrength = 0;
            else if (_fireStrength > _maximumForce)
                _fireStrength = _maximumForce;
            Debug.Log(_fireStrength);

        }
    }

    private void FireCannon(float strength)
    {
        GameObject ball = Instantiate(_cannonBall, _firePoint.position, _firePoint.rotation);
        Rigidbody rb;
        if (ball.TryGetComponent<Rigidbody>(out rb))
        {
            Debug.Log("Rigitbody detected");
            rb.velocity = _firePoint.right * strength;
        }
    }

    public float GetMaxForce() {
        return _maximumForce;
    }
    
    public float GetMinForce() {
        return _minimumForce;
    }

    public float GetFireStrength() {
        return _fireStrength;
    }
}

