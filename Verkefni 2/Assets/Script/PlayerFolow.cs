using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFolow : MonoBehaviour
{
    public Transform Player;
    public Vector3 Offset;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Player.transform.position + Offset;
        transform.rotation = Player.transform.rotation;
    }
}
