using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        /*
         * Esta linea es para hacer el set de los parametros que se envian a sonido
         * CUIDADO QUE LINEAS DE CODIGO RELACIONADO CON WWISE QUE NO COMPILE HACE QUE WWISE ENTERO SE DESCONECTE
         */
        AkSoundEngine.SetRTPCValue("nombreParametro", 0);       
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
