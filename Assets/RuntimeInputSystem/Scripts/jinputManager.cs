using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//create by jcode (miventech)
/*

By Jcode

This is the section in charge of controlling the graphical interface
in addition to being able to edit the defined keyMaps in a more comfortable way.
                        (
                        )     (
                 ___...(-------)-....___
             .-""       )    (          ""-.
       .-'``'|-._             )         _.-|
      /  .--.|   `""---...........---""`   |
      `\ `\  |                             |
        `\ ` |                             |
         _/ /\                             /
        (__/  \                           /
     _..---""` \                         /`""---.._
  .-'           \                       /          '-.
 :               `-.__             __.-'              :
 :                  ) ""---...---"" (                 :
  '._               `"--...___...--"`              _.'
    \""--..__                              __..--""/
     '._     """----.....______.....----"""     _.'
        `""--..,,_____            _____,,..--""`
*/

namespace RuntimeInputSystem  {
    public class jinputManager : MonoBehaviour
    {
        public bool UseKeysMappingNative = true;
        public List<NewKeyInput>  keyMappingCustom;
        public GameObject UIElementKeyMap;
        public RectTransform ContainerInputs;
        void Start()
        {   
            StartCoroutine(startAsync());
            GetComponent<Canvas>().enabled = false;
        }

        IEnumerator startAsync(){
            if(UseKeysMappingNative){
                jinput.InitializeDictionary();
            }else{
                createCustomInput();
            }
            yield return new WaitForSeconds(1);
            BuildKeyUI();
            
        }

        void Awake()
        {
            if(UseKeysMappingNative){
                jinput.InitializeDictionary();
            }else{
                createCustomInput();
            }
            BuildKeyUI();
        }
        void Update()
        {
            if(jinputElementUI.changeKeyInput && Input.anyKey){
                foreach(KeyCode vKey in System.Enum.GetValues(typeof(KeyCode))){
                    if(Input.GetKey(vKey)){
                        if(!HasKeyInOtherInput(jinputElementUI.EditingInput.NameInput.text , vKey)){
                            jinput.SetKeyMap(jinputElementUI.EditingInput.NameInput.text , vKey);
                            jinputElementUI.EditingInput.UpdateKeyCode();
                        }else{
                            jinputElementUI.EditingInput.NameKey.text = "Key in Use...";
                        }
                    }
                }
            }
        }

        bool HasKeyInOtherInput(string NoCompora , KeyCode key){
            bool r = false;
            foreach (var nameInput in jinput.keyMapping.Keys)
            {
                if(nameInput != NoCompora){
                    if(jinput.keyMapping[nameInput] == key){
                        return true;
                    }
                }
            }
            return r;
        }

        void createCustomInput(){
            string[] __keyMaps = new string [keyMappingCustom.Count];
            KeyCode[] __keyCodes = new KeyCode[keyMappingCustom.Count];
            for (int i = 0; i < keyMappingCustom.Count; i++)
            {
                __keyMaps[i] = keyMappingCustom[i].NameInput;
                __keyCodes[i] = keyMappingCustom[i].Key;
            }
            jinput.CustomInitializeDictionary(__keyMaps,__keyCodes);
        }
        public void BuildKeyUI(){
            List<jinputElementUI> lUI = new List<jinputElementUI>();
            int c = ContainerInputs.transform.childCount - 1;
            for (int i =  c; i >= 0; i--)
            {
                if(ContainerInputs.transform.GetChild(i).gameObject != ContainerInputs.transform.gameObject)
                Destroy(ContainerInputs.GetChild(i).gameObject);
            }
            foreach (var nameInput in jinput.keyMapping.Keys)
            {
                jinputElementUI elemUI = Instantiate(UIElementKeyMap , Vector3.zero , Quaternion.identity , ContainerInputs).GetComponent<jinputElementUI>();
                elemUI.NameInput.text = nameInput;
                elemUI.NameKey.text = jinput.keyMapping[nameInput].ToString();
                lUI.Add(elemUI);

            }  
            for (int i = 0; i < lUI.Count; i++)
            {
                lUI[i].LoadKey();
            } 
        }

        [System.Serializable]
        public struct NewKeyInput{
            public string NameInput;
            public KeyCode Key;
        }
    }
}
