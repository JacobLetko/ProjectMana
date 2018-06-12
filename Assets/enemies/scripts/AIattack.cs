using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIattack : MonoBehaviour
{

    public EnemyController controller;
    public string[] targetTags;
    public float damage;
    [SerializeField]
    private float _attackRadius;//While target is within range, attack. Otherwise, loop back to chase. If the player dies, go into9 search mode.
    LayerMask layers;
    private void Awake()
    {
        if (GetComponent<EnemyController>() != null)
        {
            controller = GetComponent<EnemyController>();
        }
        else
        {
            Debug.Log("No EnemyController located on: " + gameObject.name);
        }
    }

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Attack()
    {
        if (targetTags.Length > 0)
        {
            Collider[] hit = Physics.OverlapSphere(transform.position, _attackRadius, layers, QueryTriggerInteraction.Ignore);

            if (hit.Length > 0)
            {
                foreach (Collider item in hit)
                {
                    if (item != null)
                    {
                        if ((item.tag != "Ground") && (item.tag != "Wall"))
                        {
                            for (int i = 0; i < targetTags.Length; i++)
                            {
                                if (targetTags[i] == item.tag)
                                {
                                    //deal damage
                                    //change state
                                }
                            }
                            break;
                        }
                    }
                }
            }
            else
            {
                //change state
            }
        }
        else
        {
            Debug.LogError("No target tags given to: " + gameObject.name);
        }
    }
}
