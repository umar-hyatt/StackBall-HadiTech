using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    UIManager uIManager;
    public Transform ball1, ball2, ball3, ball4;
    public Vector3 offset;

    private void Start() 
    {
        uIManager=(UIManager)FindObjectOfType(typeof(UIManager));

    }
    // Update is called once per frame
    void Update()
    {
        if(uIManager.ball1.activeInHierarchy)
        {
        transform.position = ball1.position + offset;
        }
        if(uIManager.ball2.activeInHierarchy)
        {
        transform.position = ball2.position + offset;
        }
        if(uIManager.ball3.activeInHierarchy)
        {
        transform.position = ball3.position + offset;
        }
        if(uIManager.ball4.activeInHierarchy)
        {
        transform.position = ball4.position + offset;
        }
    }
}
