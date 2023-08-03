using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseDrag : MonoBehaviour
{

    private Settings settings;
    // Start is called before the first frame update
    void Start()
    {
        settings = GameObject.FindWithTag("UIManager").GetComponent<Settings>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0) && settings.isAllowDrag)
        {
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
            if(hit.collider!=null)
            {
                print(hit.collider.gameObject.tag);
                hit.collider.gameObject.GetComponent<PlanetInteraction>().isGrabbed = true;
            }
        }
        if(Input.GetMouseButtonUp(0))
        {
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
            if (hit.collider != null)
            {
                print(hit.collider.gameObject.tag);
                hit.collider.gameObject.GetComponent<PlanetInteraction>().isGrabbed = false;
            }
        }
    }
}
