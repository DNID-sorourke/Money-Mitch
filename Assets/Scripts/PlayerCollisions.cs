using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerCollisions : MonoBehaviour
{
    public float currentTotal = 0.00f;

    [SerializeField] private TextMeshProUGUI _currentTotalDisplay;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Currency")
        {
            Currency c = other.gameObject.GetComponent<Currency>();
            currentTotal += c.data.Value;
            UpdateDisplay();
            GameObject.Destroy(c.gameObject);
        }
    }

    private void UpdateDisplay()
    {
        _currentTotalDisplay.text = "$" + currentTotal;
    }
}
