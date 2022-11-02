using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Currency", menuName = "Currency")]
public class CurrencyData : ScriptableObject
{
    public CurrencyType Type;
    public SerializableDecimal Value;
}
