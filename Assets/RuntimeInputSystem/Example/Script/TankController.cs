using System.Security.Cryptography.X509Certificates;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RuntimeInputSystem;
/*
This movement system for the tank uses the "RuntimeInputSystem"
system which allows to modify in runtime which key corresponds
to which behavior in a way that is always to be used.

By Jcode


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
public class TankController : MonoBehaviour
{
    public float velTank = 5;
    public float velRot = 40;
    public float JumpForce = 40;
    Rigidbody rb;
   
   void Start()
   {
       rb = GetComponent<Rigidbody>();
   }
    // Update is called once per frame
    void Update()
    {
        float _v =   jinput.GetAxis("Forward", "Backward");
        float _h =   jinput.GetAxis("Right", "Left");
        transform.Translate(transform.forward * _v * velTank * Time.deltaTime , Space.World);
        transform.Rotate(transform.up * velRot * _h * Time.deltaTime , Space.World);
        if(jinput.GetKeyDown("Jump")){
            rb.AddForce(Vector3.up * JumpForce , ForceMode.Impulse);
        }
        
    }
}
