using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjFace : MonoBehaviour
{
    public Transform ObjToFollow = null;
    public bool FollowPlayer = false;

    private void Awake()
    {
        if (!FollowPlayer)
        {
            return;
        }
        GameObject PlayerObj = GameObject.FindGameObjectWithTag("Player");
        if (PlayerObj != null)
        {
            ObjToFollow = PlayerObj.transform;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (ObjToFollow == null)
        {
            return;
        }

        Vector3 DirToObject = ObjToFollow.position - transform.position;
        gameObject.transform.localRotation = Quaternion.LookRotation(DirToObject, Vector3.up);
    }
}
