using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    // Gildi sem Hægt er að stilla
    // Snúningur á X ás
    public float x = 0;
    // Snúningur á Y ás
    public float y = 0;
    // Snúningur á Z ás
    public float z = 0;
    // Fixed Update er kallað 60 sinum á sec
    void FixedUpdate()
    {
        // Snúa samhvæmt breitum
        transform.Rotate(x, y, z);
    }
}
