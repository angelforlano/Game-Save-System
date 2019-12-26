using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class SavePropertieProfile : ScriptableObject
{
    public string label;
}

[CreateAssetMenu(fileName = "SavePropertieProfile", menuName = "Game-Save-System/Int Save Propertie", order = 0)]
public class IntSavePropertieProfile : SavePropertieProfile
{
    public int value;
}

[System.Serializable]
public abstract class SavePropertie
{
    [SerializeField] public string label;

    public abstract object GetValue();
    public abstract void SetValue(object _value);
}

[System.Serializable]
public class IntSavePropertie : SavePropertie
{
    [SerializeField] public int value;

    public override object GetValue()
    {
        return value;
    }

    public override void SetValue(object _value)
    {
        if (_value == null)
            return;

        value = int.Parse(_value.ToString());
    }
}

[System.Serializable]
public class FloatSavePropertie : SavePropertie
{
    [SerializeField] public float value;

    public override object GetValue()
    {
        return value;
    }

    public override void SetValue(object _value)
    {
        if (_value == null)
            return;

        value = (float)_value;
    }
}