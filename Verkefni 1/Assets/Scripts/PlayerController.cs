using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // breita fyrir hraðan á bílnum
    public float hradi = 0;
    public float beygjuHradi = 0f;
    // input breita
    private float beygjuInput;
    private float aframInput;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // fá Input
        beygjuInput = Input.GetAxis("Horizontal");
        aframInput = Input.GetAxis("Vertical");
        // Færa Bíllinn áfram
        transform.position += transform.forward * hradi * aframInput;
        // snúa bílnum
        transform.Rotate(0, beygjuHradi * beygjuInput, 0);
    }
}
