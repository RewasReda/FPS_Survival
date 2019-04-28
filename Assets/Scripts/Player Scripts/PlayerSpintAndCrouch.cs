using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpintAndCrouch : MonoBehaviour
{
    // Start is called before the first frame update

    private PlayerMovment playerMovment;
    public float sprint_Speed = 10f;
    public float move_Speed = 5f;
    public float crouch_Speed = 2f;

    private Transform look_Root;
    private float stand_Height = 1.6f;
    private float crouch_Height = 1f;
    private bool is_Crouching;

    private PlayerFootSteps1 player_Footsteps;
    private float sprint_Volume = 1f;
    private float crouch_Volume = 0.1f;
    private float walk_Volume_Min = 0.2f;
    private float walk_Volume_Max = 0.6f;
    private float walk_Step_Distance = 0.4f;
    private float sprint_Step_Distance = 0.25f;
    private float crouch_Step_Distance = 0.5f;

    private PlayerStats player_Stats;
    private float sprint_Value = 100f;
    public float sprint_Threshold = 10f;

    private CharacterController character_Controller;


    private void Start()
    {
        player_Footsteps.volume_Min = walk_Volume_Min;
        player_Footsteps.volume_Max = walk_Volume_Max;
        player_Footsteps.step_Distance = walk_Step_Distance;


    }

    void Awake()
    {
        playerMovment = GetComponent<PlayerMovment>();

        look_Root = transform.GetChild(0);

        player_Footsteps = GetComponentInChildren<PlayerFootSteps1>();
        player_Stats = GetComponent<PlayerStats>();
        character_Controller = GetComponentInParent<CharacterController>();

    }

    // Update is called once per frame
    void Update()
    {
        Sprint();
        Crouch();
    }

    void Sprint()
    {
        //sprint with stamina

        if(sprint_Value > 0)
        {
            if (Input.GetKeyDown(KeyCode.LeftShift) && !is_Crouching && character_Controller.velocity.magnitude>0 )
            {
                playerMovment.speed = sprint_Speed;
                player_Footsteps.step_Distance = sprint_Step_Distance;
                player_Footsteps.volume_Min = sprint_Volume;
                player_Footsteps.volume_Max = sprint_Volume;
            }
        }
        
        if (Input.GetKeyUp(KeyCode.LeftShift) && !is_Crouching)
        {
            playerMovment.speed = move_Speed;
            player_Footsteps.step_Distance = walk_Step_Distance;
            player_Footsteps.volume_Min = walk_Volume_Min;
            player_Footsteps.volume_Max = walk_Volume_Max;
            
        }

        if (Input.GetKey(KeyCode.LeftShift) && !is_Crouching && character_Controller.velocity.magnitude > 0)
        {
            sprint_Value -= sprint_Threshold * Time.deltaTime;
            if(sprint_Value <= 0f )
            {
                sprint_Value = 0f;

                // reset speed and sound

                playerMovment.speed = move_Speed;
                player_Footsteps.step_Distance = walk_Step_Distance;
                player_Footsteps.volume_Min = walk_Volume_Min;
                player_Footsteps.volume_Max = walk_Volume_Max;

            }
            player_Stats.Display_StaminaStats(sprint_Value);
        }
        else
        {
            if(sprint_Value != 100f)
            {
                sprint_Value += (sprint_Threshold / 2f) * Time.deltaTime;

                player_Stats.Display_StaminaStats(sprint_Value);

                if (sprint_Value > 100f)
                {
                    sprint_Value = 100f;
                }
            }
        }
    }

    void Crouch()
    {
        if(Input.GetKeyDown(KeyCode.LeftControl))
        {
            if(is_Crouching)
            {
                look_Root.localPosition = new Vector3(0f, stand_Height, 0f);
                playerMovment.speed = move_Speed;
                is_Crouching = false;
                player_Footsteps.step_Distance = walk_Step_Distance;
                player_Footsteps.volume_Min = walk_Volume_Min;
                player_Footsteps.volume_Max = walk_Volume_Max;

            }
            else
            {
                look_Root.localPosition = new Vector3(0f, crouch_Height, 0f);
                playerMovment.speed = crouch_Speed;
                is_Crouching = true;
                player_Footsteps.step_Distance = crouch_Step_Distance;
                player_Footsteps.volume_Min = crouch_Volume;
                player_Footsteps.volume_Max = crouch_Volume;
            }
        }
    }
}
