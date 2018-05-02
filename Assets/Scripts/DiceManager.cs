using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiceManager : MonoBehaviour {

    [SerializeField]
    GameObject[] dice = new GameObject[2];
    Rigidbody[] diceRigid = new Rigidbody[2];
    public float mult;
    bool isShaking;
    // Use this for initialization
    
    void Update()
    {
        // デバッグ用
        if (Input.GetKeyDown(KeyCode.Space))
        {
            for(int i = 0; i < 2; i++)
            {
                dice[i].GetComponent<Dice>().Shake();
            }
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            for (int i = 0; i < 2; i++)
            {
                dice[i].GetComponent<Dice>().StopShake();
            }
        }
    }
    public void DiceShake()
    {
        if (!isShaking)
        {
            for (int i = 0; i < 2; i++)
            {
                dice[i].GetComponent<Dice>().Shake();
                isShaking = true;
            }
        }
        else
        {
            return;
        }
    }
    public void StopShake()
    {
        for (int i = 0; i < 2; i++)
        {
            dice[i].GetComponent<Dice>().StopShake();
        }
        isShaking = false;
    }
}
