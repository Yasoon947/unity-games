using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddStatusEffectGA : GameAction
{
    public StatusEffectType StatusEffectType { get; private set; }
    public int Stackcount {  get; private set; }
    public List<CombatantView> Targets { get; private set; }
    public AddStatusEffectGA(StatusEffectType statusEffectType, int stackcount, List<CombatantView> targets)
    {
        StatusEffectType = statusEffectType;
        Stackcount = stackcount;
        Targets = targets;
    }
}
