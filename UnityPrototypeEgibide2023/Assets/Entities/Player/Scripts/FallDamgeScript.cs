using System.Collections;
using System.Collections.Generic;
using Entities.Player.Scripts;
using UnityEngine;

public class FallDamgeScript : MonoBehaviour
{
    protected Rigidbody2D Rb;
    private GameObject killArea;
    public float fallDamageDistance;
    
    // Start is called before the first frame update
    void Start()
    {
        killArea = GameObject.Find("KillArea");
        Rb ??= killArea.GetComponent<Rigidbody2D>();
        killArea.transform.position = new Vector3(0,gameObject.transform.position.y-fallDamageDistance,0);
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.GetComponent<PlayerController>().IsGrounded())
        {
            killArea.transform.position = new Vector3(0,gameObject.transform.position.y-fallDamageDistance,0);
        }
    }
}
