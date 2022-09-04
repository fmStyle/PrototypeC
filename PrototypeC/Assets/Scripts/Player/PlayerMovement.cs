using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody2D rigidbody;
    Vector2 velocity;
    PlayerData playerData;
    private GameObject miningBoulder;
    private GameObject buildingObject;
    private GameObject constructableItem;
    public Camera mainCamera;
    // HashSet<GameObject> objectsTouchingBuildingObject;
    public float acceleration;
    public float maxVelocity;
    public float friction;
    public float desacceleration;
    public float velocityLevelScaling;
    public float miningSpeed = 1.0f;
    private float miningTimer;
    private bool mining;
    public bool actionHappening;
    public bool building;
    Animator animator;
    bool runningLeft;
    

    // Start is called before the first frame update
    void Start()
    {
        runningLeft = false;
        // objectsTouchingBuildingObject = new HashSet<GameObject>();
        mainCamera = GameObject.FindWithTag("MainCamera").GetComponent<Camera>();
        building = false;
        miningTimer = 0.0f;
        actionHappening = false;
        rigidbody = GetComponent<Rigidbody2D>();
        playerData = GetComponent<PlayerData>();
        animator = GetComponent<Animator>();
    }

    void Update(){
        /// The health of the boulder gets reduced the last tick
        if(CheckMining()){
            BoulderData boulderData = miningBoulder.GetComponent<BoulderData>();
            boulderData.durability -= (10*playerData.strengthLevel) + 10.0f;
            playerData.energy -= 1;
        }
        if (building){
            Vector3 newPos = mainCamera.ScreenToWorldPoint(Input.mousePosition);
            newPos.z = 0f;
            buildingObject.transform.position = newPos;
            if (Input.GetKeyDown(KeyCode.Escape)){
                Destroy(buildingObject);
                GetComponent<PlayerInventory>().OpenInventory();
                building = false;
            }
            if (Input.GetMouseButtonDown(0)){
                if (!buildingObject.GetComponent<BuildingObject>().IsObstructing()){
                    buildingObject.GetComponent<SpriteRenderer>().color = new Color32(255, 255, 255, 255);
                    GetComponent<PlayerInventory>().RemoveItem(constructableItem);
                    buildingObject.GetComponent<BuildingObject>().FinishedBuilding();
                    building = false;
                }
            }
        }
        SetAnimations();
    }
    void FixedUpdate()
    {

        if (!actionHappening && !mining){
            if (Input.GetKey(KeyCode.A)){
                velocity.x -= acceleration + (playerData.velocityLevel * velocityLevelScaling);
            }
            if (Input.GetKey(KeyCode.D)){
                velocity.x += acceleration + (playerData.velocityLevel * velocityLevelScaling);
            }
            if (Input.GetKey(KeyCode.W)){
                velocity.y += acceleration + (playerData.velocityLevel * velocityLevelScaling);
            }
            if (Input.GetKey(KeyCode.S)){
                velocity.y -= acceleration + (playerData.velocityLevel * velocityLevelScaling);
            }
        }
        if (velocity.magnitude < friction){
            velocity.x = 0.0f;
            velocity.y = 0.0f;
        }
        if (velocity.magnitude > (maxVelocity + (playerData.velocityLevel * velocityLevelScaling))){
            velocity.x = velocity.normalized.x * (maxVelocity + (playerData.velocityLevel * velocityLevelScaling));
            velocity.y = velocity.normalized.y * (maxVelocity + (playerData.velocityLevel * velocityLevelScaling));
        }
        velocity *= desacceleration;
        rigidbody.velocity = velocity;
    }
    public void Mine(GameObject boulder){
        if (!building){
            if (mining == true) return;
            mining = true;
            miningTimer = miningSpeed - ((1/4)*playerData.pickaxeAbilityLevel);
            miningBoulder = boulder;
        }
    }
    /// Returns true when finished the timer
    public bool CheckMining(){
        if (mining){
            miningTimer -= Time.deltaTime;
            if (miningTimer <= 0.0f){
                mining = false;
                miningTimer = 1.0f;

                return true;
            }
        }
        return false;
    }

    public void EnterBuildingMode(GameObject objectToBuild, GameObject constructableItem){
        building = true;
        GetComponent<PlayerInventory>().CloseInventory();
        buildingObject = objectToBuild;
        this.constructableItem = constructableItem;
    }

    public void EnterActionHappening(){
        actionHappening = true;
    }
    public void ExitActionHappening(){
        actionHappening = false;
    }

    private void SetAnimations(){
        if (rigidbody.velocity.x > 0.05){
            if (runningLeft){
                Vector3 localTransform = transform.localScale;
                localTransform.x = Mathf.Abs(localTransform.x);
                transform.localScale = localTransform;
            }
            runningLeft = false;
            animator.Play("RunningSide");
            
        }
        else if (rigidbody.velocity.x < -0.05){
            if (!runningLeft){
                Vector3 localTransform = transform.localScale;
                localTransform.x = localTransform.x * (-1);
                transform.localScale = localTransform;
                runningLeft = true;
                animator.Play("RunningSide");
            }
            
        }
        else if (Mathf.Abs(rigidbody.velocity.x) < 0.1 && Mathf.Abs(rigidbody.velocity.y) > 0.1){
            animator.Play("RunningUp");
        }
        else{
            runningLeft = false;
            animator.Play("Idle");
        }
    }

    // void OnTriggerEnter2D(Collider2D collider){
    //     objectsTouchingBuildingObject.Add(collider.gameObject);
    // }
    // void OnTriggerExit2D(Collider2D collider){
    //     if (objectsTouchingBuildingObject.Contains(collider.gameObject)){
    //         objectsTouchingBuildingObject.Remove(collider.gameObject);
    //     }
    // }
}
