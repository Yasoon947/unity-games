using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatusEffectSystem : Singleton<StatusEffectSystem>
{
    private void OnEnable()
    {
        ActionSystem.AttachPerformer<AddStatusEffectGA>(AddStatusEffectPerformer);
    }
    private void OnDisable()
    {
        ActionSystem.DetachPerformer<AddStatusEffectGA>();
    }
    private IEnumerator AddStatusEffectPerformer(AddStatusEffectGA addStatusEffectGA)
    {
        foreach(var target in addStatusEffectGA.Targets)
        {
            target.AddStatusEffect(addStatusEffectGA.StatusEffectType, addStatusEffectGA.Stackcount);
            yield return null;
        }
    }
}
