using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoundsLock : MonoBehaviour
{
    public Rect levelBounds;
    private Rigidbody ThisBody = null;

    private void Start()
    {
        ThisBody = GetComponent<Rigidbody>();
    }

    private void LateUpdate()
    {
        float xVelocity = ThisBody.velocity.x;
        float zVilocity = ThisBody.velocity.z;
        if (transform.position.x >= levelBounds.xMax || transform.position.x <= levelBounds.xMin)
        {
            xVelocity = 0;
        }
        if (transform.position.z >= levelBounds.yMax || transform.position.z <= levelBounds.yMin)
        {
            zVilocity = 0;
        }
        ThisBody.velocity = new Vector3(xVelocity, 0, zVilocity);

            

        transform.position = new Vector3(Mathf.Clamp(transform.position.x, levelBounds.xMin, levelBounds.xMax),
            transform.position.y, Mathf.Clamp(transform.position.z, levelBounds.yMin, levelBounds.yMax));
    }

    private void OnDrawGizmosSelected()
    {
        const int cubeDepth = 1;
        Vector3 boundsCenter = new Vector3(levelBounds.xMin + levelBounds.width * 0.5f, 0, levelBounds.yMin + levelBounds.height * 0.5f);
        Vector3 boundsHeight = new Vector3(levelBounds.width, cubeDepth, levelBounds.height);
        Gizmos.DrawWireCube(boundsCenter, boundsHeight);
    }
}
