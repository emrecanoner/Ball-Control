using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collasion : MonoBehaviour
{
    // Start is called before the first frame update
    private void OnTriggerEnter(Collision collision)
    {
        if (collision.gameObject.tag == "ballTag")
        {
            Destroy(collision.gameObject);
        }
    }
}
