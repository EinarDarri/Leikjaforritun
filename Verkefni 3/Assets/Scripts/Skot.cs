using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skot : MonoBehaviour
{
    // þetta er keyrt þegar skotið snertir einhvað
    private void OnCollisionEnter(Collision collision)
    {
        // ef að skotið leindir á óvini
        if (collision.collider.tag == "Enemy")
        {
            // teingjast við Enemy Scriptuna hjá þeim óvini og láta það vita að hann var skotinn
            collision.collider.gameObject.GetComponent<Enemy>().Hit();
            // eyða þessari byssu kúlu
            Destroy(this.gameObject);
          
        }
    }
}
