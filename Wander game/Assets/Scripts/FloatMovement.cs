using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatMovement : MonoBehaviour
{
    private Transform PlayerPosition;
    public Vector3 PlayerVector;
    [Range(0f, 5f)]
    public float ConstantSpeed = 1f;

    void Start()
    {
        PlayerPosition = GetComponent<Transform>();
        PlayerVector = PlayerPosition.position;
    }

    void FixedUpdate()
    {
        PlayerVector += transform.right * ConstantSpeed * Time.deltaTime;
        PlayerPosition.position = PlayerVector;
    }
}
