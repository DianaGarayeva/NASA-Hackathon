using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 3f;

    private void Update()
    {
        float x = Input.GetAxisRaw("Horizontal");   // A и D
        float z = Input.GetAxisRaw("Vertical");     // W и S

        Vector3 direction = new Vector3(x, 0f, z);
        direction = Vector3.ClampMagnitude(direction, 1f);   // по диагонали не быстрее

        transform.Translate(direction * moveSpeed * Time.deltaTime, Space.World);
    }
}

