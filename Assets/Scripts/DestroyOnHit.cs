using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnHit : MonoBehaviour
{
    [Tooltip("Every object tagged with this tag will trigger the destruction of this object")]
    [SerializeField] string triggeringTag;



    private void OnTriggerEnter2D(Collider2D other)
    {



        if (other.tag == triggeringTag )
        {


            Destroy(this.gameObject);
            Destroy(other.gameObject);


        }
    }

    private void Update()
    {

    }
}
