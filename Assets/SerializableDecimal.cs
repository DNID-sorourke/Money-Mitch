using UnityEngine;
using System.Collections;

[System.Serializable]
public class SerializableDecimal : ISerializationCallbackReceiver
{
    [HideInInspector] public decimal value;
    [SerializeField]
    private int[] data;

    //[SerializeField] private string inspectorField = "0";

    public void OnBeforeSerialize()
    {
        data = decimal.GetBits(value);
    }
    public void OnAfterDeserialize()
    {
        if (data != null && data.Length == 4)
        {
            value = new decimal(data);
        }
    }
}
