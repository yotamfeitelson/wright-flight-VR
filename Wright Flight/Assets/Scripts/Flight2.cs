using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flight2 : MonoBehaviour
{
    [SerializeField] private CharacterController controller;

    [SerializeField] private float base_speed = 10.0f;
    [SerializeField] private float rot_speed_x = 5.0f;
    [SerializeField] private float rot_speed_y = 5.0f;
    [SerializeField] private float rot_speed_z = 5.0f;
    [SerializeField]    private LeverController pitchLever;
    [SerializeField]    private HipController yawLever;

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
    }




    // Update is called once per frame
    void Update()
    {
        var x = transform.eulerAngles.x;
        var y = transform.eulerAngles.y;
        var z = transform.eulerAngles.z;

        //if (Input.GetKey(KeyCode.S))
        //{
        //    x += rot_speed_x * Time.deltaTime;
        //}
        //if (Input.GetKey(KeyCode.W))
        //{
        //    x -= rot_speed_x * Time.deltaTime;
        //}
        //if (Input.GetKey(KeyCode.D))
        //{
        //    y += rot_speed_y * Time.deltaTime;
        //    z -= rot_speed_z * Time.deltaTime;
        //}
        //if (Input.GetKey(KeyCode.A))
        //{
        //    y -= rot_speed_y * Time.deltaTime;
        //    z += rot_speed_z * Time.deltaTime;
        //}
        x += pitchLever.getVal() * rot_speed_x * Time.deltaTime;
        //Debug.Log(yawLever.getVal());
        y += yawLever.getVal() * rot_speed_y * Time.deltaTime; //yaw
        z -= yawLever.getVal() * rot_speed_z * Time.deltaTime;// -yaw
        //        if (Input.GetKey(KeyCode.Space))
        //      {
        //          base_speed += 0.1f;
        //      }

        Vector3 move_vector = transform.forward * base_speed * Time.deltaTime;

        //if (x >= -10 && x <= 50 && y >= -10 && y <= 50 && z >= -30 && z <= 30)
        //{
        //    transform.rotation = Quaternion.Euler(x, y, z);
        //}

        transform.rotation = Quaternion.Euler(x, y, z);

        controller.Move(move_vector);
    }
}

