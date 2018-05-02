using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class InputManager : MonoBehaviour
{
    [System.Serializable]
    public class TouchEvent : UnityEvent<string> { }
    [System.Serializable]
    public class ReleaseEvent : UnityEvent { }
    [SerializeField]
    private TouchEvent OnTouched = new TouchEvent();
    [SerializeField]
    private ReleaseEvent OnRelesed = new ReleaseEvent();
    // Update is called once per frame
    [SerializeField]
    Text text;
    void Update()
    {
        if (OnTouchDown())
        {
            Debug.Log("タップ");
        }
        else
        {
            OnRelesed.Invoke();
        }
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
                    OnTouched.Invoke(hit.collider.gameObject.name);
                    text.text = hit.collider.gameObject.name;
                    return true;
                }
                else
                {
                    return false;
                }

            }
        }
        text.text = "";
        return false;
    }
}
