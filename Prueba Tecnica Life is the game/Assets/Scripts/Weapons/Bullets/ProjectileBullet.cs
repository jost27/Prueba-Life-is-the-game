using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileBullet : MonoBehaviour
{


}
///trying to make with a slerp

    /*
    public Transform beginpos, endedpos;
    [SerializeField]
    float journeyTime = 1f;
    [SerializeField]
    float speed;
    [SerializeField]
    LineRenderer line;

    bool activateslerp;
    float startTime;
    Transform initalpos, endpos;
    Vector3 centerpoint, startpostion, endposition;
    InputManager inputs;

    // Start is called before the first frame update
    void Start()
    {
        inputs = FindObjectOfType<InputManager>();
        inputs.inputs.Character.interact.started += x => { 
            activateslerp=true; 
            startTime = Time.time;
            initalpos = beginpos;
            endpos = endedpos;
        };
        startTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if(activateslerp)
            ActionSlerp();
    }
    private void FixedUpdate()
    {
        DrawSlerp();
    }

    public void ActionSlerp()
    {
        GetCenter(Vector3.up);
        float fractime = (Time.time - startTime) / journeyTime;
        transform.position = Vector3.Slerp(startpostion, endposition, fractime);
        transform.position += centerpoint;
        if (fractime > 1)
            activateslerp = false;

    }
    public void GetCenter(Vector3 direction)
    {
        centerpoint = (initalpos.position + endpos.position) * 0.5f;
        centerpoint -= direction;
        startpostion = initalpos.position - centerpoint;
        endposition = endpos.position - centerpoint;
    }


    int i = 0;
    Vector3 point;
    void DrawSlerp()
    {
        int numpontis=25;
        line.positionCount = numpontis;
        GetCenter(Vector3.up);        
        point = Vector3.Slerp(startpostion, endposition, (float) i / numpontis);
        point += centerpoint;
        line.SetPosition(i,point);
        i++;
        if (i >= numpontis)
            i = 0;
        
        
    }

}
    */