using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindButton : MonoBehaviour
{

    Vector3 init_pos;
    Vector3 moved_pos;
    DiceManager diceManager;
    // Use this for initialization
    void Start()
    {
        init_pos = gameObject.transform.position;
        moved_pos = new Vector3(init_pos.x, init_pos.y - 0.3f, init_pos.z);
        diceManager = gameObject.transform.parent.gameObject.GetComponent<DiceManager>();
    }
    // ボタンが押されたときの処理
    public void ButtonDown(string name)
    {
        if (name == gameObject.name)
        {
            gameObject.transform.position = moved_pos;
            diceManager.DiceShake();
        }
    }
    // ボタンが離されたときの処理
    public void ButtonUp()
    {
        gameObject.transform.position = init_pos;
        diceManager.StopShake();
    }
}
