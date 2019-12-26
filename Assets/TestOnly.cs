using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestOnly : MonoBehaviour
{
    public int playerExp = 785;
    public IntSavePropertie playerHp = new IntSavePropertie();
    public FloatSavePropertie playerSpeed = new FloatSavePropertie();

    public IntSavePropertieProfile userHP;
    
    void Start()
    {
        Debug.Log(SaveManager.Load(nameof(playerSpeed)));
        Debug.Log(SaveManager.Load(playerHp));

        playerHp.value += 10;
        
        SaveManager.Save(nameof(playerSpeed), playerSpeed);
        SaveManager.Save(playerSpeed);
        SaveManager.Save("PlayerLevel", Random.Range(1, 999));
        SaveManager.Save("PlayerExp", Random.Range(1, 100));

        SaveManager.Save("PlayerLives", JsonUtility.ToJson(new TestSaveClass()));
    }
}

public class TestSaveClass
{
    public int playerLives = 7;
}