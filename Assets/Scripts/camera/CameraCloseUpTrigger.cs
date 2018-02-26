using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraCloseUpTrigger : MonoBehaviour {

    public GameObject Player;
    public Camera mainCamera;
    public Camera closeUpCamera;

    private PlayerController playerController;

    private bool enterTriggerPosition;
    private void Start()
    {
        playerController = Player.GetComponent<PlayerController>();
     }

    // runs pn the first frame this object collides with another o jegt
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            mainCamera.enabled = false;
            closeUpCamera.enabled = true;
            enterTriggerPosition = true;
        }
    }

   // runs on the last frame this oject collides with an object leaving it's area
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            mainCamera.enabled = true;
            closeUpCamera.enabled = false;
            enterTriggerPosition = false;
        }

    }


    // run on every frame that an object is in the collision area
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (enterTriggerPosition && closeUpCamera.orthographicSize > 0) {
            closeUpCamera.orthographicSize -= playerController.moveH / 60;
        }
    }


}
