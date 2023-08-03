using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;


public class btBackgrouond : MonoBehaviour
{
    public Sprite bg_none,bg_built_in;
    private SpriteRenderer bg;
    private Button[] buttons;
    private Button btNone, btBuiltIn, btLoad;
    private Texture2D texture;
    
    // Start is called before the first frame update
    void Start()
    {
        bg = GameObject.FindWithTag("Background").GetComponent<SpriteRenderer>();
        buttons = gameObject.GetComponentsInChildren<Button>();
        foreach(Button bt in buttons)
        {
            switch(bt.name)
            {
                case "btNone":
                    btNone = bt;
                    break;
                case "btBuiltIn":
                    btBuiltIn = bt;
                    break;
                case "btLoad":
                    btLoad = bt;
                    break;
            }
        }
        btNone.onClick.AddListener(SetNone);
        btBuiltIn.onClick.AddListener(SetBuiltIn);
        btLoad.onClick.AddListener(LoadFile);
        btNone.interactable = false;
    }

    void SetNone()
    {
        bg.sprite = bg_none;
        btNone.interactable = false;
        btBuiltIn.interactable = true;
        btLoad.interactable = true;
    }
    void SetBuiltIn()
    {
        bg.sprite = bg_built_in;
        btBuiltIn.interactable = false;
        btNone.interactable = true;
        btLoad.interactable = true;
    }
    
    void LoadFile()
    {
        string FinalPath="";
        System.Windows.Forms.OpenFileDialog dialog = new System.Windows.Forms.OpenFileDialog();
        dialog.Title = "请选择图片文件";
        dialog.Filter = "图片文件(*.png,*.jpg,*.jpeg)|*.png;*.jpg;*.jpeg";
        dialog.InitialDirectory = "C:\\";
        if(dialog.ShowDialog()==System.Windows.Forms.DialogResult.OK)
        {
            FinalPath = dialog.FileName;
            print(FinalPath);
            FileStream fileStream = new FileStream(FinalPath, FileMode.Open, FileAccess.Read);
            fileStream.Seek(0, SeekOrigin.Begin);
            byte[] binary = new byte[fileStream.Length];
            fileStream.Read(binary, 0, (int)fileStream.Length);
            fileStream.Close();
            fileStream.Dispose();
            fileStream = null;
            texture = new Texture2D(1, 1);
            texture.LoadImage(binary);
            Sprite temp = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), new Vector2(0.5f, 0.5f));
            bg.sprite = temp;
        }
        btNone.interactable = true;
        btBuiltIn.interactable = true;
    }

    
}
