using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class AnimationManager : MonoBehaviour
{
    
    public Animator _characterAnim;

    private void Start()
    {
        if (PassData.animationName != null)
            SetAnimation(PassData.animationName);
        else
           
            SetAnimation(_characterAnim.parameters[0].name);

    }
    public void SetAnimation(string animName)
    {
        PassData.animationName = animName;
        _characterAnim.SetTrigger(animName);
        
    }

    public void ChangeScene(string nameScene)
    {
        if (nameScene == string.Empty)
        {
            if (SceneManager.GetActiveScene().buildIndex == 0)
            {
                SceneManager.LoadScene(1);
            }
            else {
                SceneManager.LoadScene(0);
            }
            return;
        }
        SceneManager.LoadScene(nameScene);

    }
}



