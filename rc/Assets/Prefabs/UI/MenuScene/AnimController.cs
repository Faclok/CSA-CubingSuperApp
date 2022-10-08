using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimController : MonoBehaviour
{
    public Animation Anim;
    private void Awake()
    {
        
        Anim.Play();
    }
}
