using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class btDrag : MonoBehaviour
{
    private Button btAllowDrag;
    private Button btForbidDrag;

    private Settings settings;
    
    // Start is called before the first frame update
    void Start()
    {
        settings = GameObject.FindWithTag("UIManager").GetComponent<Settings>();
        
        Button[] Buttons = gameObject.GetComponentsInChildren<Button>();
        foreach(Button bt in Buttons)
        {
            if(bt.name=="btAllowDrag")
            {
                btAllowDrag = bt;
            }
            else
            {
                btForbidDrag = bt;
            }
        }
        btAllowDrag.onClick.AddListener(AllowDrag);
        btForbidDrag.onClick.AddListener(ForbidDrag);
        btAllowDrag.interactable = false;
    }


    void AllowDrag()
    {
        settings.isAllowDrag = true;
        btAllowDrag.interactable = false;
        btForbidDrag.interactable = true;
    }

    void ForbidDrag()
    {
        settings.isAllowDrag = false;
        btForbidDrag.interactable = false;
        btAllowDrag.interactable = true;
    }
}
