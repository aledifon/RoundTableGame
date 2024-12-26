using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeGravity : MonoBehaviour
{
    [SerializeField] private float gravityScale;  // Escala de gravedad personalizada
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.useGravity = false;
    }

    void FixedUpdate()
    {
        // Aplica una gravedad personalizada en cada frame
        Vector3 gravity = new Vector3(0, -9.81f * gravityScale, 0);
        rb.AddForce(gravity, ForceMode.Acceleration);
    }
}
