using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public Transform playerSpawnTransform;

    public GameObject playerControllerPrefab;

    public GameObject tankPawnPrefab;

    public List<PlayerController> player;

    // Awake is called when the object is first created - before even Start can run!
    private void Awake()
    {
        // If the instance doesn't exist yet...
        if (instance == null)
        {
            // This is the instance
            instance = this;
            //Don't destroy it if we load a new scene
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            // Otherwise, there is already an instance, so destroy this gameObject
            Destroy(gameObject);
        }

    }
    public void SpawnPlayer()
    {
        // Spawn the Player Controller at (0,0,0) with no rotation
        GameObject newPlayerObj = Instantiate(playerControllerPrefab, Vector3.zero, Quaternion.identity) as GameObject;

        // Spawn the Pawn and connect it to the Controller
        GameObject newPawnObj = Instantiate(tankPawnPrefab, playerSpawnTransform.position, playerSpawnTransform.rotation) as GameObject;

        // Get the Player Controller component and Pawn component. 
        Controller newController = newPlayerObj.GetComponent<Controller>();
        Pawn newPawn = newPawnObj.GetComponent<Pawn>();

        // Hook them up!
        newController.pawn = newPawn;
    }
    // Start is called before the first frame update
    void Start()
    {
        // Temp Code - for now, we spawn player as soon as the GameManager starts
        SpawnPlayer();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
