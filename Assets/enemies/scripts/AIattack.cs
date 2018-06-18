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
    public LayerMask layers;
    
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

        if (GetComponent<AbilityScore>() != null)
        {
            damage = GetComponent<AbilityScore>().abilities.PhysicalDamage;
        }

    }

    //public IEnumerator AtkTimer()
    //{
    //    yield return new WaitForSeconds(attackTimer);
    //}
    bool canAttack = true;
    public void Attack()
    {
        if (canAttack)
        {
            canAttack = false;
            StartCoroutine(MyAttack());
        }
    }


    IEnumerator MyAttack()
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
                            if (item.transform != transform)
                            {
                                for (int i = 0; i < targetTags.Length; i++)
                                {
                                    if (targetTags[i].ToString() == item.tag)
                                    {
                                        transform.LookAt(item.transform);
                                        item.gameObject.GetComponent<AbilityScore>().abilities.Health -= damage;

                                        yield return new WaitForSeconds(attackTimer);

                                        if (item != null)
                                        {
                                            if (Vector3.Distance(item.transform.position, (transform.position * attackOffset)) > _attackRadius)
                                            {
                                                controller.stateStack.Pop();
                                                controller.stateStack.Push(EnemyController.States.GOTO);
                                            }
                                        }
                                        else
                                        {
                                            controller.stateStack.Pop();
                                            controller.stateStack.Push(EnemyController.States.GOTO);
                                        }

                                    }
                                }
                                canAttack = true;
                                break;
                            }
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
        canAttack = true;
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position + (transform.forward * attackOffset), _attackRadius);
    }
}
