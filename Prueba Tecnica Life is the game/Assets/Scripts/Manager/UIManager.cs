using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class UIManager : MonoBehaviour
{
     
    [Header("UI")]
    [SerializeField]
    Transform panelButton;
    [Header("Prefab")]
    [SerializeField]
    GameObject _buttonTemplate;
    //---------------
    AnimationManager _animationManager;
    Animator _characteranim;
    
    // create UI buttons for Each  animator parameter 
    void Start()
    {
        _animationManager = FindObjectOfType<AnimationManager>();
        _characteranim = _animationManager._characterAnim;
        foreach (AnimatorControllerParameter animParam in _characteranim.parameters)
        {
            GameObject currentObject = Instantiate(_buttonTemplate,panelButton);
            
            currentObject.GetComponent<ButtonAnim>().SetTextButton(animParam.name);
        }
    }

   

 
}
