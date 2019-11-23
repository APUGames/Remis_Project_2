using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollisions : MonoBehaviour
{
    //Logic for shack door
    private bool doorIsOpen = false;
    private float doorTimer = 0.0f;
    public float doorOpenTime = 3.0f;

    //Door sounds
    public AudioClip doorOpenSound;
    public AudioClip doorShutSound;
    private new AudioSource audio;

    //battery sound
    public AudioClip batteryCollectSound;

    // Start is called before the first frame update
    void Start()
    {
        audio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        //timer that shuts door if doorIsOpen
        if (doorIsOpen)
        {
            doorTimer += Time.deltaTime;
        }
        if (doorTimer > doorOpenTime)
        {
            ShutDoor();
            doorTimer = 3.0f;
        }
    }
    //Collision Detecion
    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if(hit.gameObject.tag == "shackDoor" && !doorIsOpen && BatteryCollect.charge >= 4)
        {
            OpenDoor();
            BatteryCollect.chargeUI.enabled = false;
        }
        else if (hit.gameObject.tag == "shackDoor" && !doorIsOpen && BatteryCollect.charge < 4)
        {
            BatteryCollect.chargeUI.enabled = true;
            TextHints.message = "The door seems to need more power...";
            TextHints.textOn = true;
        }
    }

    //battery collision
    private void OnTriggerEnter(Collider coll)
    {
        if (coll.gameObject.tag == "battery")
        { 
        BatteryCollect.charge++;
            audio.PlayOneShot(batteryCollectSound);
            Destroy(coll.gameObject);
        }
    }

    void OpenDoor()
    //Play Audio
    {
        audio.PlayOneShot(doorOpenSound);
        //Set doorIsOpen to true
        doorIsOpen = true;
        //find GameObject that has animation
        GameObject Shack = GameObject.Find("Shack");
            //Play animation
            Shack.GetComponent<Animation>().Play("doorOpen");
    }

    void ShutDoor()
    //Play Audio
    {
        audio.PlayOneShot(doorShutSound);
        //Set doorIsOpen to true
        doorIsOpen = false;
        //find GameObject that has animation
        GameObject Shack = GameObject.Find("Shack");
        //Play animation
        Shack.GetComponent<Animation>().Play("doorShut");
    }
}
