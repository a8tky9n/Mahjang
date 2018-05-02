using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dice : BaseBehaviour
{
    Rigidbody rb;
    bool isShaking;
    int value;
    bool isRunning;
    Vector3 initPos;
    void Start()
    {
        initPos = gameObject.transform.position;
        rb = gameObject.GetComponent<Rigidbody>();
        value = 0;
        isRunning = false;
    }
    private void Update()
    {
        if (gameObject.transform.position.x >= 1.5f
                    || gameObject.transform.position.x <= -1.5f)
        {
            PosReset();
        }
        if (gameObject.transform.position.z >= 1.5f
           || gameObject.transform.position.z <= -1.5f)
        {
            PosReset();
        }
    }
    public int GetValue()
    {
        return value;
    }
    // サイコロを振るインターフェース
    public void Shake()
    {
        ShakeMove();
        isShaking = true;
        StartCoroutine(DiceCheck());
    }
    // 床と接触した時の挙動
    void OnCollisionEnter(Collision col)
    {
        if (!isShaking)
            return;
        if (col.gameObject.name == "Ground")
        {
            ShakeMove();
        }
    }
    // サイコロを振る動き
    void ShakeMove()
    {
        rb.maxAngularVelocity = 10000;
        //rb.AddForce(Vector3.up * 3, ForceMode.Impulse);
        rb.AddTorque(new Vector3(Random.Range(1f, 10f), Random.Range(1f, 10f), Random.Range(1f, 10f)) * 0.5f, ForceMode.Impulse);
    }
    // サイコロをとめるインターフェース
    public void StopShake()
    {
        isShaking = false;
    }
    // サイコロの向きを判断する
    int CheckValue()
    {
        // 2～5まで
        if (Mathf.RoundToInt(gameObject.transform.eulerAngles.x) % 180 == 0)
        {
            //Debug.Log("2～5("+ Mathf.RoundToInt(gameObject.transform.eulerAngles.x)+","+Mathf.RoundToInt(gameObject.transform.eulerAngles.y)+","+Mathf.RoundToInt(gameObject.transform.eulerAngles.z)+")");
            switch (Mathf.RoundToInt(gameObject.transform.eulerAngles.z) % 360)
            {
                case 0:
                    return 5;
                case 90:
                    return 3;
                case 270:
                    return 4;
                case 180:
                    return 2;
            }
        }
        // 1 or 6
        else if (Mathf.RoundToInt(gameObject.transform.eulerAngles.x) % 360 == 90)
        {
            return 1;
        }
        else if (Mathf.RoundToInt(gameObject.transform.eulerAngles.x) % 360 == 270)
        {
            return 6;
        }
        return 0;
    }
    // サイコロが止まったか見る
    IEnumerator DiceCheck()
    {
        if (isRunning)
        {
            yield break;
        }
        isRunning = true;
        while (true)
        {
            yield return new WaitForSeconds(2f);
            if (rb.angularVelocity == Vector3.zero)
            {
                //Debug.Log("止まったで");
                isRunning = false;
                break;
            }
        }
    }
    private void PosReset()
    {
        gameObject.transform.position = initPos;
    }
}
