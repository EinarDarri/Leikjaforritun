using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    // breita fyrir player
    public GameObject Player;
    // breita fyrir staðsetningu myndarvélar frá player
    public Vector3 offset = new Vector3(0, 5, -15);
    // Update is called once per frame
    void Update()
    {
        // myndavélin mun fylgja staðsetninguni á player breituni
        transform.position = Player.transform.position + offset;
    }
}
