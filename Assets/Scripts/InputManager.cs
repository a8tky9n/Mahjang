using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class InputManager : MonoBehaviour
{
    // Update is called once per frame
    [SerializeField]
    Text text;
    void Update()
    {
        if (OnTouchDown())
        {
            Debug.Log("タップ");
        }
        //if (OnMouseDown())
        //{
        //    Debug.Log("hoge");
        //}

    }
    bool OnTouchDown()
    {
        if (0 < Input.touchCount)
        {
            for (int i = 0; i < Input.touchCount; i++)
            {
                Touch t = Input.GetTouch(i);

                Ray ray = Camera.main.ScreenPointToRay(t.position);
                RaycastHit hit = new RaycastHit();
                if (Physics.Raycast(ray, out hit))
                {
                    text.text = hit.collider.gameObject.name;
                    if (hit.collider.gameObject.name.Contains("Player"))
                    {
                        hit.collider.gameObject.GetComponent<WindButton>().ButtonDown();
                    }
                }

            }
            return true;
        }
        text.text = "";
        return false;
    }
    bool OnMouseDown()
    {
        if (Input.GetMouseButton(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            text.text = Input.mousePosition.ToString();
            RaycastHit hit = new RaycastHit();
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.gameObject.name.Contains("Player"))
                {
                    hit.collider.gameObject.GetComponent<WindButton>().ButtonDown();
                }
                return true;
            }

        }
        return false;
    }
}
