using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public bool MouseLook = true;
    public string HorzAxis = "Horizontal";
    public string VertAxis = "Vertical";
    public string FireAxis = "Fire1";
    public float ReloadDelay = 0.3f;
    public bool CanFire = true;
    public Transform[] TurretTransforms;
    public float MaxSpeed = 5f;

    private Rigidbody ThisBody = null;
    private bool FireButtonPresed = false;

    private void Awake()
    {
        ThisBody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (Input.GetButtonDown(FireAxis))
        {
            FireButtonPresed = true;
        }    
    }

    private void FixedUpdate()
    {
        float Horz = Input.GetAxis(HorzAxis);
        float Vert = Input.GetAxis(VertAxis);
        Vector3 MoveDirection = new Vector3(Horz, 0.0f, Vert);
        ThisBody.AddForce(MoveDirection.normalized * MaxSpeed);
        ThisBody.velocity = new Vector3(Mathf.Clamp(ThisBody.velocity.x, -MaxSpeed, MaxSpeed),
            Mathf.Clamp(ThisBody.velocity.y, -MaxSpeed, MaxSpeed),
            Mathf.Clamp(ThisBody.velocity.z, -MaxSpeed, MaxSpeed));

        if (MouseLook)
        {
            Vector3 MousePosWorld = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0.0f));
            MousePosWorld = new Vector3(MousePosWorld.x, 0.0f, MousePosWorld.z);
            Vector3 LoocDirection = MousePosWorld - transform.position;
            transform.localRotation = Quaternion.LookRotation(LoocDirection.normalized, Vector3.up);
        }

        if (FireButtonPresed && CanFire)
        {
            foreach (Transform T in TurretTransforms)
            {
                AmmoManager.SpawnAmmo(T.position, T.rotation);
            }
            CanFire = false;
            FireButtonPresed = false;
            Invoke("EnableFire", ReloadDelay);
        }
    }

    void EnableFire()
    {
        CanFire = true;
    }
}
