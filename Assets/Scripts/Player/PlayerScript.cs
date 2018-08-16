using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : Champion
{
    public VirtualJoytick joytick;

    private void Update()
    {
        Run();
    }

    public override void Run()
    {
        myBody.velocity = joytick.InputDirection * champion.speed;
        Vector3 temp = joytick.InputDirection;
        temp.z = Mathf.Lerp(joytick.InputDirection.z, transform.forward.z,  0.0125f);
        transform.forward = temp;
    }

    public override void Q()
    {
        throw new System.NotImplementedException();
    }

    public override void E()
    {
        throw new System.NotImplementedException();
    }

    public override void W()
    {
        throw new System.NotImplementedException();
    }

    public override void R()
    {
        throw new System.NotImplementedException();
    }

}
