using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class TestOnly : MonoBehaviour
{
    public Text text;
    public IntSavePropertieProfile score;
    
    void Start()
    {
        SaveManager.Load(score);
        text.text = score.GetValue().ToString();
    }

    public void AddScore()
    {
        score.Add();
        text.text = score.GetValue().ToString();
        SaveManager.Save(score);
    }
}