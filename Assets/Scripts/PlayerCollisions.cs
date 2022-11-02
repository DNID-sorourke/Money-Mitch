using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;
using System;

public class PlayerCollisions : MonoBehaviour
{
    public SerializableDecimal currentTotal;

    [SerializeField] private TextMeshProUGUI _currentTotalDisplay;
    [SerializeField] private MoneyMitchManager _mmm;

    private void Start()
    {
        currentTotal.value = 0.00M;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Currency")
        {
            Currency c = other.gameObject.GetComponent<Currency>();
            currentTotal.value += c.data.Value.value;

            UpdateDisplay();
            GameObject.Destroy(c.gameObject);
            _mmm.CheckTotal(currentTotal.value);
        }
    }

    private void UpdateDisplay()
    {
        _currentTotalDisplay.text = ("$" + currentTotal.value);
    }
}
