using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonAnim : MonoBehaviour
{   
    [SerializeField]
    Text textButton;

    [HideInInspector]
     public AnimationManager animationManager;

    private void Start()
    {
        animationManager = FindObjectOfType<AnimationManager>();
        this.GetComponent<Button>().onClick.AddListener(SetButtonOnClick);
    }
    public void SetTextButton(string text)
    {
        textButton.text = text;
        
    }
    void SetButtonOnClick()
    {
        animationManager.SetAnimation(textButton.text);
    }
}
