# Editable Runtime Input System Unity
RuntimeInputSystem is a simple code which enables to modify keys corresponding to a specific input at runtime.

https://github.com/miventech/Editable-Runtime-Input-System-Unity/releases/tag/RuntimeInputSystem
By Jose Jaspe [JaspeCode] [Miventech]



# Download
+ [Release](github.com/miventech/Editable-Runtime-Input-System-Unity/releases/tag/RuntimeInputSystem
)


# [Donaciones] [Donations]

+ [Ayudame con un Cafe](paypal.me/MiVenTech)

+ [Help me with a coffee](paypal.me/MiVenTech)


# [en-us] (translate)

Runtime Input System (RIS) is a code for unity that allows you to edit during runtime a group of "inputs" that work based on established
"KeyMaps", in this way we can assign these "KeyMap" to a code. and these will reweight, like the unity "Input" system. in fact the
implementation is the closest thing to the native system of unity 
"Input.GetKey (```KeyCode``` Key)" -> "jinput.GetKey (```string``` NameKeyMap)"

## Create the KeyMaps
 
### By Code

You must go to the script of ```jinput.cs``` and define them in the arrays of ```KeyMaps``` and ```defaults``` that are at the beginning of the
code.

```
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
```
 ### By Interface
 
 try to have in the scene the prefab ```InputManagerRealTime``` or have an object with the component ``` jinputManager``` with the inspector.
 You can view the variable ```keyMappingCustom``` which is a list that we can edit, adding or removing KeyMaps.

 It is important to take into account the box ```UseKeysMappingNative``` which determines which KeyMaps the system will work with.

 [true]
 It will use the Code Defined KeyMaps.

 [False]
 It will use the KeyMaps Defined by the interface.
 
 ![jinputManager](https://github.com/miventech/Editable-Runtime-Input-System-Unity/blob/main/png/jinputManager.PNG)
 
 
 ## jinput.cs
 
  This class is the one that we will use to implement the keys in the systems that are designed.
 
  ## Get Keys
 
  + ```Bool``` GetKey (``` string``` KeyMapName)
  + ```Bool``` GetKeyDown (``` string``` KeyMapName)
  + ```Bool``` GetKeyUp (``` string``` KeyMapName)

  With all these static functions we can obtain the Boolean state of each KeyMap under different conditions.

  ```
      if (jinput.GetKeyDown ("Jump")) {
             // The player jumps
      }
     
      if (jinput.GetKey ("Forward")) {
             //walk forward
      }
     
      if (jinput.GetKeyUp ("Fly")) {
             // Stop Flying
      }
  ```
  
  
  ## Get Axes
 
  + ```Float``` GetAxis (``` string``` KeyMapPositive, ```string``` KeyMapNegative)
 
  With this function we will choose an artificial axis that we can define between two keyMaps a positive and a negative one.
  the result of this function is ```-1``` || ```0``` || ```1```
  
  ```
 
  float _v =   jinput.GetAxis("Forward", "Backward");
 
  ```
 
 
 
 ```
 using UnityEngine;
 using RuntimeInputSystem;

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
 ```
 ## Edit the KeyMap
 
+ SetKeyMap (```string``` keyMap, ```KeyCode``` Newkey)

 With this function we can assign a new key to any KeyMap that is in the list during the execution of the code.
  
  
# [es-ve]

Runtime Input System (RIS) es un codigo para unity que te permite editar durante el tiempo de ejecucion un grupo de "inputs" que
funcionan en base a unos "KeyMaps" establecidos, de esta forma podemos asignar estos "KeyMap" a un codigo. y estos reponderan, al
igual que el sistema de "Input" de unity. de echo la implementacion es lo mas parecido al sistema nativo de unity 
"Input.GetKey(```KeyCode``` Key)" - > "jinput.GetKey(```string``` NameKeyMap)"

 ## Crear los KeyMaps
 
 ### Por Codigo
 
 Debe irse al script de ```jinput.cs``` y definirlos en los array de  ```KeyMaps``` y ```defaults``` qeu se encuentran al inicio del 
 codigo.

```
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
```

 
 ### Por Interfaz
 
 procure tener en la scena el prefab ```InputManagerRealTime``` o tener un objeto con el componente ```jinputManager``` con el inspector.
 podra visualizar la variable ```keyMappingCustom``` que es una lista que podemos editar, añadiendo o eliminando KeyMaps.
 
 Es importante tener en cuenta la casilla ```UseKeysMappingNative``` que determian con que KeyMaps va trabajar el sistema.
 
 [verdadero]
 Usara los KeyMaps Definidos por Codigo.
 
 [Falso]
 Usara los KeyMaps Definidos por La interfaz.
 
 ![jinputManager](https://github.com/miventech/Editable-Runtime-Input-System-Unity/blob/main/png/jinputManager.PNG)
 
 
 ## jinput.cs
 
 Esta clase es la que usaremos para implemetar las teclas en los sistemas que se diseñen.
 
 ## Optener Teclas
 
 + ```Bool``` GetKey( ```string```  KeyMapName) 
 + ```Bool``` GetKeyDown( ```string```  KeyMapName) 
 + ```Bool``` GetKeyUp( ```string```  KeyMapName) 

 Con todas estas funciones estaticas podemos obtener el estado booleano de cada KeyMap en diferentes condiciones.

 ```
     if(jinput.GetKeyDown("Jump")){
            //Salta el jugador
     }
     
     if(jinput.GetKey("Forward")){
            //caminar Hacia adelante
     }
     
     if(jinput.GetKeyUp("Fly")){
            //Dejo de Volar
     }
 ```
 
 ## Optener Ejes
 
 + ```Float``` GetAxis( ```string```  KeyMapPositive , ```string```  KeyMapNegative )
 
 Con esta funcion optendremos un eje artificial que podemos definir entre dos keyMaps uno positivo y uno negativo.
 el resultado de esta funcion es de ```-1``` || ```0``` || ```1```
 ```
 
 float _v =   jinput.GetAxis("Forward", "Backward");
 
 ```
 
 
 
 ```
 using UnityEngine;
 using RuntimeInputSystem;

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
 ```
 
 ## Editar los KeyMap
 
+ SetKeyMap( ```string```  keyMap , ```KeyCode```  Newkey )

 Con esta funcion podemos asignar una nueva tecla a cualquier KeyMap que este en la lista durante la ejecucion del codigo.

 
 
 

# Download
+ [Release](github.com/miventech/Editable-Runtime-Input-System-Unity/releases/tag/RuntimeInputSystem
)


# [Donaciones] [Donations]

+ [Ayudame con un Cafe](paypal.me/MiVenTech)

+ [Help me with a coffee](paypal.me/MiVenTech)
