using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class btLength : MonoBehaviour
{
    private Button btLength0, btLength5, btLength10, btLength15, btLength20, btLength30;
    private Settings settings;
    private Button[] Buttons;
    // Start is called before the first frame update
    void Start()
    {
        settings = GameObject.FindWithTag("UIManager").GetComponent<Settings>();
        Buttons = gameObject.GetComponentsInChildren<Button>();
        foreach(Button bt in Buttons)
        {
            switch(bt.name)
            {
                case "btLength0":
                    btLength0 = bt;
                    break;
                case "btLength5":
                    btLength5 = bt;
                    break;
                case "btLength10":
                    btLength10 = bt;
                    break;
                case "btLength15":
                    btLength15 = bt;
                    break;
                case "btLength20":
                    btLength20 = bt;
                    break;
                case "btLength30":
                    btLength30 = bt;
                    break;
            }
        }
        btLength0.onClick.AddListener(Set0);
        btLength5.onClick.AddListener(Set5);
        btLength10.onClick.AddListener(Set10);
        btLength15.onClick.AddListener(Set15);
        btLength20.onClick.AddListener(Set20);
        btLength30.onClick.AddListener(Set30);
        btLength10.interactable = false;
    }

    void SetButtonSelected(string name)
    {
        foreach (Button bt in Buttons)
        {
            if (bt.name == name)
            {
                bt.interactable = false;
            }
            else
            {
                bt.interactable = true;
            }
        }
    }

    void Set0()
    {
        settings.SetTrailLength(0f);
        SetButtonSelected("btLength0");
    }
    void Set5()
    {
        settings.SetTrailLength(5f);
        SetButtonSelected("btLength5");
    }
    void Set10()
    {
        settings.SetTrailLength(10f);
        SetButtonSelected("btLength10");
    }
    void Set15()
    {
        settings.SetTrailLength(15f);
        SetButtonSelected("btLength15");
    }
    void Set20()
    {
        settings.SetTrailLength(20f);
        SetButtonSelected("btLength20");
    }
    void Set30()
    {
        settings.SetTrailLength(30f);
        SetButtonSelected("btLength30");
    }
    
}
