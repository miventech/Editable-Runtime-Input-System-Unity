using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
namespace RuntimeInputSystem  {
    public class jinputElementUI : MonoBehaviour
    {
        public static bool changeKeyInput;
        public Text NameInput;
        public Text NameKey;

        
        // Start is called before the first frame update
        public static jinputElementUI EditingInput;
        
        public void changeInput(){
            changeKeyInput = true;
            if(EditingInput != null){
                NameKey.text = jinput.keyMapping[NameInput.text].ToString();
            }
            EditingInput = this;
            NameKey.text = "Press Key...";
        }
        public void UpdateKeyCode(){
            changeKeyInput = false;
            if(EditingInput != null){
                NameKey.text = jinput.keyMapping[NameInput.text].ToString();
                EditingInput = null;
            }
            changeKeyInput = true;
            NameKey.text = jinput.keyMapping[NameInput.text].ToString();
            saveKey();
        }

        public void saveKey(){
            PlayerPrefs.SetInt("InputSystem_"+NameInput.text, (int)jinput.keyMapping[NameInput.text]);
        }

        public void LoadKey(){
            if(PlayerPrefs.HasKey("InputSystem_"+NameInput.text)){
                int k =  PlayerPrefs.GetInt("InputSystem_"+NameInput.text);
                jinput.SetKeyMap(NameInput.text , (KeyCode)k );
                NameKey.text = ((KeyCode)k).ToString();
            }
        }
    }
}