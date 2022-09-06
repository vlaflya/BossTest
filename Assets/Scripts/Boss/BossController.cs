using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.Events;

public class BossController : MonoBehaviour
{
    public Transform player;
    private bool active = true;
    private bool rotate = true;
    [SerializeField] private float rotSpeed;
    [SerializeField] private Animator animator;
    [SerializeField] private Transform headTarget;
    [SerializeField] private string startAttack;
    [SerializeField] private List<AttackChain> chains;
    [SerializeField] private List<ObjectSpawner> trasureSpawners; 
    public UnityEvent onFightStart = new UnityEvent();
    public AttackChain currentAttack;

    void Start()
    {
        //StartFight();
        animator.speed = 0;
    }

    public void StartFight() {
        animator.speed = 1;
        active = true;
        onFightStart.Invoke();
        currentAttack = GetAttack(startAttack);
    }

    public void SecondPhaseStart() {
        Debug.Log("New Phase");
        animator.SetTrigger("StageTransition");
        animator.SetTrigger("StageTransition1");
    }

    public void StartNewAttack () {
        int r = Random.Range(0, currentAttack.attackChains.Count);
        currentAttack = GetAttack(currentAttack.attackChains[r]);
        if (currentAttack.triggers.Count != 0) {
            Debug.Log(currentAttack.name);
            foreach(var t in currentAttack.triggers)
                animator.SetTrigger(t);
        }
    }

    private AttackChain GetAttack(string name) {
        Debug.Log(name);
        for (int i = 0; i < chains.Count; i++) {
            if (chains[i].name.Equals(name))
            {
                Debug.Log("oke");
                return chains[i];
            }
        }
        return null;
    }

    // Update is called once per frame
    void Update()
    {
        if (!active)
            return;
        headTarget.position = player.position;

        if (rotate)
        {
            Quaternion lookRot = Quaternion.LookRotation(player.position - transform.position, Vector3.up);
            Vector3 rot = lookRot.eulerAngles;
            rot.x = 0;
            rot.z = 0;
            float l = Mathf.LerpAngle(transform.eulerAngles.y, rot.y, Time.deltaTime * rotSpeed);
            rot = new Vector3(0, l, 0);
            transform.eulerAngles = rot;
        }
    }

    public void StartRotation() {
        rotate = true;
    }

    public void DestroySelf() {
        foreach (var t in trasureSpawners) {
            t.SpawnObject();
        }
        Destroy(gameObject);
    }

    public void StopRotation() {
        rotate = false;
    }
    [System.Serializable]
    public class AttackChain {
        public string name;
        public List<string> triggers = new List<string>();
        public List<string> attackChains = new List<string>();
    }
}
