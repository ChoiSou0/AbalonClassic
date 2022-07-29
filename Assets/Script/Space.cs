using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Space : MonoBehaviour
{
    Renderer renderer;

    public SpaceState spaceState;
    public int Num;

    private void Start()
    {
        renderer = GetComponent<Renderer>();
    }

    private void Update()
    {
        switch(spaceState)
        {
            case SpaceState.Black:
                renderer.material.color = Color.black;
                break;
            case SpaceState.White:
                renderer.material.color = Color.white;
                break;
            default:
                renderer.material.color = Color.gray;
                break;
        }
    }
}
