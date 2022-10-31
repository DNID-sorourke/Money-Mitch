using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurrencyDestroyer : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Currency")
        {
            GameObject.Destroy(other.gameObject);
        }
    }
}
