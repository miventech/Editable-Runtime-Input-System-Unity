using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//create by jcode (miventech)
/*

By Jcode

RuntimeInputSystem -> Jinput is a simple method to modify keys 
corresponding to a specific input at runtime.
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


namespace RuntimeInputSystem {
    public class jinput
    {
        public static Dictionary<string, KeyCode> keyMapping;


            //define default keymaps
            static string[] keyMaps = new string[7]
            {
                "Jump",
                "Forward",
                "Backward",
                "Left",
                "Right",
                "Up",
                "Down",
            };
            static KeyCode[] defaults = new KeyCode[7]
            {
                KeyCode.Space,
                KeyCode.W,
                KeyCode.S,
                KeyCode.A,
                KeyCode.D,
                KeyCode.E,
                KeyCode.Q,
            };
        
            //initilize all KeyMaps
            public static void InitializeDictionary()
            {
                keyMapping = new Dictionary<string, KeyCode>();
                for(int i=0;i<keyMaps.Length;++i)
                {
                    keyMapping.Add(keyMaps[i], defaults[i]);
                }
            }

            public static void CustomInitializeDictionary(string[] _keyMaps , KeyCode[] _keyCodes)
            {
                keyMapping = new Dictionary<string, KeyCode>();
                for(int i=0;i<_keyMaps.Length;++i)
                {
                    keyMapping.Add(_keyMaps[i], _keyCodes[i]);
                }
            }

            public static void SetKeyMap(string keyMap,KeyCode key)
            {
                if (!keyMapping.ContainsKey(keyMap))
                    throw new ArgumentException("Invalid KeyMap in SetKeyMap: " + keyMap);
                keyMapping[keyMap] = key;
            }

            public static float GetAxis(string KeyMapPositive, string KeyMapNegative){
                float r  = 0;
                if((GetKey(KeyMapPositive) ^ GetKey(KeyMapNegative))){
                    if(GetKey(KeyMapPositive)){
                        r  = 1;
                    }
                    if(GetKey(KeyMapNegative)){
                        r  = -1;
                    }
                }
                return r;
            }


            public static bool GetKeyDown(string keyMap)
            {
                return Input.GetKeyDown(keyMapping[keyMap]);
            }

            public static bool GetKey(string keyMap)
            {
                return Input.GetKey(keyMapping[keyMap]);
            }

            public static bool GetKeyUp(string keyMap)
            {
                return Input.GetKeyUp(keyMapping[keyMap]);
            }
    }
}