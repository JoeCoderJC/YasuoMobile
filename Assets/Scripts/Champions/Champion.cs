using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Champion : MonoBehaviour {

    public ChampionConfig champion;

    protected Animator anim;
    protected Rigidbody myBody;

    protected virtual void Awake()
    {
        anim = GetComponent<Animator>();
        myBody = GetComponent<Rigidbody>();
    }

    public abstract void Run();
    public abstract void Q();
    public abstract void W();
    public abstract void E();
    public abstract void R();

}
