using UnityEngine;
using System.Collections;
using System;
using UnityEngine.UI;

public class PlayerPreferences : MonoBehaviour {
    
    private string nickName;
    public InputField inputNickName;
    public bool finishDemo = false;

	// Use this for initialization
	void Start () {
        if (!String.IsNullOrEmpty(PlayerPrefs.GetString("NickName"))){ }
            inputNickName.text = PlayerPrefs.GetString("NickName");
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    
    public void SetNickName(){
        PlayerPrefs.SetString("NickName", inputNickName.text);
    }
}
