using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Variables3 : MonoBehaviour
{
    public FIshing3Script fshScript;
    // Start is called before the first frame update
    void Start()
    {
        fshScript.fish1.SetActive(false);
        fshScript.fish2.SetActive(false);
        fshScript.fish3.SetActive(false);
    }
}
