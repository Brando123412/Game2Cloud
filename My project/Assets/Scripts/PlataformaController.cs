using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlataformaController : MonoBehaviour
{
    [SerializeField] Transform plataforma1;
    [SerializeField] Transform plataforma2;
    [SerializeField] float speed;
    float initialZPosition;

    private void Start()
    {
        initialZPosition = 75;
    }

    private void Update()
    {
        float step = speed * Time.deltaTime;
        plataforma1.Translate(Vector3.back * step);
        plataforma2.Translate(Vector3.back * step);

        if (plataforma1.position.z <= -40)
        {
            plataforma1.position = new Vector3(0,0,initialZPosition-5);
        }
        if (plataforma2.position.z <= -40)
        {
            plataforma2.position = new Vector3(0,0,initialZPosition-5);
        }
    }

}
