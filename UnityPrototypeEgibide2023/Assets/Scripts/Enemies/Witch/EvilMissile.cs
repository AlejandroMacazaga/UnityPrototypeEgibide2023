using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class EvilMissile : MonoBehaviour
{
    [SerializeField] private GameObject explosion;

    private Rigidbody2D _missileBody;
    private GameObject _playerRef;
    private LandWitchData _witchData;

    private float _angle;

    void Start()
    {

        _witchData = GameObject.Find("SorginaLand").GetComponent<LandWitch>().landWitchData;
        _playerRef = GameController.Instance.GetPlayerGameObject();
        _missileBody = gameObject.GetComponent<Rigidbody2D>();
        
        Rotacion();
        StartCoroutine(nameof(ApplyForce),0f);
        Invoke(nameof(MaximumAliveTime),15f);
        
        
    }

    /*Rotates the proyectile so that its X rotation var points to the player*/
    private void Rotacion()
    {
        var neededRotation = Quaternion.LookRotation(_playerRef.transform.position - transform.position);
        transform.rotation = neededRotation;
    }
    
    void OnCollisionEnter2D(Collision2D collision)
    {
        /*Temporary Damage Logic*/
        if (collision.collider.CompareTag("Player"))
        {   
            collision.collider.gameObject.GetComponent<HealthComponent>().SendMessage("RemoveHealth", _witchData.missileDamage, SendMessageOptions.RequireReceiver);
        }
        //Explode();
        Destroy(gameObject);

    }

    /*Launches the Missile Towards the player*/
    private IEnumerator ApplyForce()
    {
        yield return new WaitForSeconds(0.5f);
        
        Vector2 whereToGoPlease = _playerRef.transform.position - transform.position;
        whereToGoPlease.Normalize();
        Vector2 speedwagon = whereToGoPlease * _witchData.missileSpeed;
        _missileBody.velocity = speedwagon;
    }
    

    private void Explode()
    {   
        Instantiate(explosion, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }

    private void MaximumAliveTime()
    {
        Destroy(gameObject);
    }

}
