using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SavePropertieProfile", menuName = "Game-Save-System/Int Save Propertie", order = 0)]
public class IntSavePropertieProfile : SavePropertieProfile
{
    public int value;

    public override object GetValue()
    {
        return value;
    }

    public override void SetValue(object value)
    {
        this.value = int.Parse(value.ToString());
    }

    public void Add(int value = 1)
    {
        this.value += value; 
    }
}