using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageSystem : Singleton<DamageSystem>
{
    [SerializeField] private GameObject damageVFX;
    private void OnEnable()
    {
        ActionSystem.AttachPerformer<DealDamageGA>(DealDamgePerformer);
    }
    private void OnDisable()
    {
        ActionSystem.DetachPerformer<DealDamageGA>();
    }
    private IEnumerator DealDamgePerformer(DealDamageGA dealDamageGA)
    {
        foreach (var target in dealDamageGA.Targets)
        {
            target.Damage(dealDamageGA.Amount);
            Instantiate(damageVFX,target.transform.position,Quaternion.identity);
            yield return new WaitForSeconds(0.15f);
            if(target.CurrentHealth <= 0)
            {
                if(target is EnemyView enemyView)
                {
                    KillEnemyGA killEnemyGA = new(enemyView);
                    ActionSystem.Instance.AddReaction(killEnemyGA);
                }else
                {

                }
            }
        }
     }
}
