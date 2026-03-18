using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EnemyView : CombatantView
{
    [SerializeField] private TMP_Text attackText;
    public int AttackPower {  get; set; }
    public void Setup(EnemyData enemyData)
    {
        AttackPower = enemyData.AttackPower;
        UpdataAttackText();
        SetupBase(enemyData.Health, enemyData.Image);
    }
    private void UpdataAttackText()
    {
        attackText.text = "ATK:" + AttackPower;
    }
}
