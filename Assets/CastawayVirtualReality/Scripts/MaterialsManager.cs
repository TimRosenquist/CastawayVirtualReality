using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameEventSystem
{
    public class MaterialsManager : MonoBehaviour
    {
        private int logCount = 0;
        private int ropeCount = 0;

        [SerializeField]
        private GameObject raft;
        private Animator raftAnimator;
        public GameEvent changeRaftmaterial;

        [SerializeField]
        private AudioSource raftSource;
        [SerializeField]
        private AudioClip raftClip;
        
        [SerializeField]
        private AudioSource deniedSource;
        [SerializeField]
        private AudioClip deniedClip;
        [SerializeField]
        private GameObject raftButton;

        [SerializeField]
        private GameObject credits;

        [SerializeField]
        private GameObject log_1;
        [SerializeField]
        private GameObject log_2;
        [SerializeField]
        private GameObject log_3; 
        [SerializeField]
        private GameObject log_4; 
        [SerializeField]
        private GameObject log_5; 
        [SerializeField]
        private GameObject rope_1; 
        [SerializeField]
        private GameObject rope_2;

        private void Start()
        {
            raftAnimator = raft.GetComponent<Animator>();
            raftSource = raft.GetComponent<AudioSource>();
            deniedSource = raftButton.GetComponent<AudioSource>();
            credits.SetActive(false);
        }

        // Increases and decreases the log and rope counters when object that are marked as "log" and "rope" are placed or removed from the inventory
        public void LogCountIncrease()
        {
            logCount++;
        }

        public void LogCountDecrease()
        {
            logCount--;
        }

        public void RopeCountIncrease()
        {
            ropeCount++;
        }

        public void RopeCountDecrease()
        {
            ropeCount--;
        }

        public void MaterialsCheck()
        {
            // Check for if the player has enough material to build the raft
            if (logCount == 5 && ropeCount == 2)
            {
                // Changes the rafts material, plays a "building" sound and pushes it into the water to simulate it being built
                changeRaftmaterial.TriggerEvent();
                raftSource.PlayOneShot(raftClip);
                raftAnimator.SetTrigger("RaftPush");

                // Disables the logs and ropes to simulate that they were used to build the raft
                log_1.SetActive(false);
                log_2.SetActive(false);
                log_3.SetActive(false);
                log_4.SetActive(false);
                log_5.SetActive(false);
                rope_1.SetActive(false);
                rope_2.SetActive(false);

                // Enables the credits that display each developers contributions to the project when the raft is built
                credits.SetActive(true);
            }
            else
            {
                // Plays a sound that indicates that the player doesn't have enough material to build the raft
                deniedSource.PlayOneShot(deniedClip);
            }
        }
    }
}