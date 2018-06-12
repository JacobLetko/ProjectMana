using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIattack : MonoBehaviour
{

    public EnemyController controller;
    public string[] targetTags;
    public float attackTimer;
    public float attackOffset = 2;
    public float damage;
    [SerializeField]
    private float _attackRadius;//While target is within range, attack. Otherwise, loop back to chase. If the player dies, go into9 search mode.
    LayerMask layers;
    private void Start()
    {
        if (GetComponent<EnemyController>() != null)
        {
            controller = GetComponent<EnemyController>();
        }
        else
        {
            Debug.Log("No EnemyController located on: " + gameObject.name);
        }
        damage = GetComponent<AbilityScore>().abilities.PhysicalDamage;
    }

    public IEnumerator AtkTimer()
    {
        yield return new WaitForSeconds(attackTimer);
    }

    public void Attack()
    {
        if (targetTags.Length > 0)
        {
            Collider[] hit = Physics.OverlapSphere(transform.position + (transform.forward * attackOffset), _attackRadius, layers, QueryTriggerInteraction.Ignore);

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
                                    item.GetComponent<AbilityScore>().abilities.Health -= GetComponent<AIattack>().damage;
                                    StartCoroutine(GetComponent<AIattack>().AtkTimer());

                                    if (Vector3.Distance(item.transform.position, transform.position) > GetComponent<AIattack>()._attackRadius)
                                    {
                                        controller.stateStack.Pop();
                                        controller.stateStack.Push(EnemyController.States.GOTO);
                                    }
                                }
                            }
                            break;
                        }
                    }
                }
            }
            else
            {
                controller.stateStack.Pop();
                controller.stateStack.Push(EnemyController.States.GOTO);
            }
        }
        else
        {
            Debug.LogError("No target tags given to: " + gameObject.name);
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position + (transform.forward * attackOffset), _attackRadius);
    }
}
