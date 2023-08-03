using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Settings : MonoBehaviour
{
    private Button btSettings;
    private GameObject SettingsPanel;
    private TrailRenderer[] trails;

    public bool isAllowDrag = true;
    private GameObject AuthorPanel;
    // Start is called before the first frame update
    void Start()
    {
        AuthorPanel = GameObject.FindWithTag("AuthorPanel");
        AuthorPanel.SetActive(false);
        SettingsPanel = GameObject.FindWithTag("SettingsPanel");
        SettingsPanel.SetActive(false);
        btSettings = GameObject.Find("btSettings").GetComponent<Button>();
        btSettings.onClick.AddListener(PanelSetActive);
        trails = GameObject.Find("Planets").GetComponentsInChildren<TrailRenderer>();

    }

    void PanelSetActive()
    {
        SettingsPanel.SetActive(!SettingsPanel.activeSelf);
    }

    public void SetTrailLength(float length)
    {
        foreach(TrailRenderer trail in trails)
        {
            trail.time = length;
        }
    }

    public void OpenAuthorPanel()
    {
        AuthorPanel.SetActive(true);
    }

    public void CloseAuthorPanel()
    {
        AuthorPanel.SetActive(false);
    }

}
