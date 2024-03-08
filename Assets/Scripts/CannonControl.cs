using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class ControlCannon : MonoBehaviour
{
    [SerializeField] private Transform _cannonCart;
    [SerializeField] private Transform _cannonBarrel;
    [SerializeField] private Transform _firePoint;
    [SerializeField] private float _sensitivityX;
    [SerializeField] private float _sensitivityY;
    [SerializeField] private GameObject _cannonBall;
    [SerializeField] public float _maximumForce;
    [SerializeField] public float _minimumForce;
    [SerializeField] private TriggerParticles particles;
    [SerializeField] private Slider slider;
    [SerializeField] private AudioClip[] clips;
    private bool _leftTouch = false;
    private int leftTouchId;
    private bool _rightTouch = false;
    private int rightTouchId;
    private float _fireStrength;

    private AudioSource source;
    private UIManager ui;
    private void Start(){
        ui = FindObjectOfType<UIManager>();
        source = GetComponent<AudioSource>();
    }
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
                source.clip = clips[2];
                source.Play();
            }

            if (touches[i].phase == TouchPhase.Began && !_rightTouch && touches[i].position.x > Display.main.systemWidth / 1.1f)
            {
                rightTouchId = touches[i].fingerId;
                _rightTouch = true;
                Debug.Log(_rightTouch);
                source.clip = clips[3];
                source.Play();
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
            _fireStrength = slider.value;
            if (_fireStrength > _minimumForce)
                FireCannon(_fireStrength);
            _fireStrength = 0;
            slider.value = slider.minValue;
            //rightTouchIndex = -1;
        }
        if (_leftTouch)
        {
            if (_cannonBarrel.eulerAngles.z >= 90 && _cannonBarrel.eulerAngles.z <= 200)
                _cannonBarrel.eulerAngles = new Vector3(_cannonBarrel.eulerAngles.x, _cannonBarrel.eulerAngles.y, -leftTouch.deltaPosition.y * _sensitivityY + _cannonBarrel.eulerAngles.z);
            if (_cannonBarrel.eulerAngles.z < 90)
                _cannonBarrel.eulerAngles = new Vector3(_cannonBarrel.eulerAngles.x, _cannonBarrel.eulerAngles.y, 90);
            else if (_cannonBarrel.eulerAngles.z > 200)
                _cannonBarrel.eulerAngles = new Vector3(_cannonBarrel.eulerAngles.x, _cannonBarrel.eulerAngles.y, 200);
            _cannonCart.eulerAngles = new Vector3(_cannonCart.eulerAngles.x, leftTouch.deltaPosition.x * _sensitivityX + _cannonCart.eulerAngles.y, _cannonCart.eulerAngles.z);
        }
    }

    private void FireCannon(float strength)
    {
        GameObject ball = Instantiate(_cannonBall, _firePoint.position, _firePoint.rotation);

        if(strength < _maximumForce/2)
            source.clip = clips[0];
        else if(strength >= _maximumForce/2)
            source.clip = clips[1];
        source.Play();
        if (ball.TryGetComponent<Rigidbody>(out Rigidbody rb)) {
            Debug.Log("Rigitbody detected");
            rb.velocity = _firePoint.right * strength;
        }
        particles.TriggerEventParticles();
        ui.OnShoot();
    }
    public float GetMaxForce()
    {
        return _maximumForce;
    }

    public float GetMinForce()
    {
        return _minimumForce;
    }

    public float GetFireStrength()
    {
        return _fireStrength;
    }
}


