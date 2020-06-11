using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hook : MonoBehaviour
{

    private Vector3 mousepos;
    private Camera cam;
    private DistanceJoint2D joint;
    private LineRenderer line;
    public PlayerManager p;
    private Vector3 temppos;
    public soundManagerScript soundfx;
    public LayerMask grappelayer;
    public GameObject braço;
    bool checker;
    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
        joint = GetComponent<DistanceJoint2D>();
        line = GetComponent<LineRenderer>();

        joint.enabled = false;
        line.positionCount = 0;
        checker = false;

    }

    // Update is called once per frame
    void Update()
    {
        checker = Physics2D.OverlapCircle( mousepos, 1, grappelayer);

        braço.transform.LookAt(mousepos, new Vector3(0,0,1));

        getMouse();

        if (Input.GetMouseButtonDown(0) && checker)
            EnableHook();
        else if (Input.GetMouseButtonDown(1))
            DisableHook();
        
        drawLine();
    }
    public void EnableHook()
    {
        soundfx.playHook();
        joint.enabled = true;
        line.enabled = true;
        joint.connectedAnchor = mousepos;
        line.positionCount = 2;
        temppos = mousepos;

    }
    public void DisableHook()
    {
        joint.enabled = false;
        line.enabled = false;
        line.positionCount = 0;
    }
    private void drawLine() 
    {
        if (line.positionCount <= 0) return;
        line.SetPosition(0, transform.position);
        line.SetPosition(1,temppos);

    }
    private void getMouse() 
    {
        mousepos = cam.ScreenToWorldPoint(Input.mousePosition);
    }
}
