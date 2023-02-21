using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class CameraControlleur : MonoBehaviour
{
    bool camMove = true;

    public float panSpeed = 30f;
    public float panBorder = 10f;
    public float scrollSpeed = 5f;

    [SerializeField] public float minY = 10f;
    [SerializeField] public float maxY = 150f;

    void Start()
    {
        
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            camMove = !camMove;
        }
        if(!camMove)
        {
            return;
        }


        if(Input.GetKey(KeyCode.Z) || Input.mousePosition.y >= Screen.height - panBorder)
        {
            transform.Translate(Vector3.forward * panSpeed * Time.deltaTime, Space.World);
        }//déplacement avant
//////////////////////////////////////////////////////////////////////////////////////////////
        if(Input.GetKey(KeyCode.S) || Input.mousePosition.y <= panBorder)
        {
            transform.Translate(Vector3.back * panSpeed * Time.deltaTime, Space.World);
        }//déplacement arrière
//////////////////////////////////////////////////////////////////////////////////////////////
        if(Input.GetKey(KeyCode.Q) || Input.mousePosition.x <=  panBorder)
        {
            transform.Translate(Vector3.left * panSpeed * Time.deltaTime, Space.World);
        }//déplacement vers la gauche
//////////////////////////////////////////////////////////////////////////////////////////////
        if(Input.GetKey(KeyCode.D) || Input.mousePosition.x >= Screen.width - panBorder)
        {
            transform.Translate(Vector3.right * panSpeed * Time.deltaTime, Space.World);
        }//déplacement vers la droite

        Vector3 limitesZ = transform.position;
        limitesZ.z = Mathf.Clamp(limitesZ.z, 0, 100);
        transform.position = limitesZ;

        Vector3 limitesX = transform.position;
        limitesX.x = Mathf.Clamp(limitesX.x, -30, 50);
        transform.position = limitesX;



        float scroll = Input.GetAxis("Mouse ScrollWheel");
        
        Vector3 position = transform.position;

        position.y -= scroll * 1000 * scrollSpeed * Time.deltaTime;
        position.y = Mathf.Clamp(position.y, minY, maxY);

        transform.position = position;
    }
}
