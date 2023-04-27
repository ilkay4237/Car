using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{
    public enum Axel
    {
        Front,
        Rear
    }
    [Serializable]
    public struct Wheel
    {
        public GameObject wheelModel;
        public WheelCollider wheelCollider;
        public GameObject wheelEffectObj;
        public ParticleSystem smokeParticle;

        public Axel axel;
    }

    public float maxAcceleration = 30.0f;
    public float brakeAcceleration = 50.0f;

    public float turnSensitivity = 1f;
    public float maxSteerAngle = 30.0f;

    public Vector3 _centerOfMass;

    public List<Wheel> wheels;

    float moveInput;
    float steerInput;

    private Rigidbody carRb;

    private void Start()
    {
        carRb = GetComponent<Rigidbody>();
        carRb.centerOfMass= _centerOfMass;
        move();

    }

    
    /*

    void Update()
    {
        GetInputs();
    }
    */
    private void LateUpdate()
    {
        Steer();

    }
    public void SteerInput(float input)
    {
        steerInput = input;
    }
    /*
    void GetInputs()
    {
        moveInput = Input.GetAxis("Vertical");
        steerInput = Input.GetAxis("Horizontal");
    }
    */
    void move()
    {
        
        foreach (var wheel in wheels)
        {
            wheel.wheelCollider.motorTorque=  600 * maxAcceleration * Time.deltaTime;
        }
    }

    void Steer()
    {
        foreach(var wheel in wheels)
        {
            if(wheel.axel == Axel.Front)
            {
                var _steerAngle = steerInput * turnSensitivity * maxSteerAngle;
                wheel.wheelCollider.steerAngle = Mathf.Lerp(wheel.wheelCollider.steerAngle, _steerAngle, 0.6f);
            }
        }
    }

    public void WheelEffects()
    {
        foreach(var wheel in wheels)
        {
            wheel.wheelEffectObj.GetComponentInChildren<TrailRenderer>().emitting= true;
            wheel.smokeParticle.Emit(1);
        }
    }
    public void WheelEffects2()
    {
        foreach (var wheel in wheels)
        {
            wheel.wheelEffectObj.GetComponentInChildren<TrailRenderer>().emitting = false;
        }
    }
}
