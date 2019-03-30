using Ship.Stats;
using UnityEngine;

namespace Ship.Input
{
    public class PlayerInput : BaseInput
    {
        PlayerStats playerStats;
        
        bool isPlayerStatsNotNull;

        void Start()
        {
            playerStats = GetComponent<PlayerStats>();
            isPlayerStatsNotNull = playerStats != null;
        }

        void Update()
        {
            if (isPlayerStatsNotNull)
            {
                useInput = !playerStats.dead;
            }
            
            if (!useInput)
            {
                Direction = Vector2.zero;
            }
            else
            {
                Direction = new Vector2
                {
                    x = UnityEngine.Input.GetAxis("Horizontal"),
                    y = UnityEngine.Input.GetAxis("Vertical")
                };    
            }
        }

        public override bool GetButton(string button)
        {
            return useInput && UnityEngine.Input.GetButton(button);
        }
        
        public override bool GetButtonDown(string button)
        {
            return useInput && UnityEngine.Input.GetButtonDown(button);
        }
        
        public override bool GetButtonUp(string button)
        {
            return useInput && UnityEngine.Input.GetButtonUp(button);
        }
    }
}
