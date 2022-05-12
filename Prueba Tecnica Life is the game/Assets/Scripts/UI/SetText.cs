using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;



public class SetText : MonoBehaviour
{
    
    // Start is called before the first frame update
    void Start()
    {
        this.GetComponent< TMP_Text >().text = "Bailando " +PassData.animationName;
    }

  
}
