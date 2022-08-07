using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageDiller
{
    private Transform attackPoint;
    private PunchSettings punchSettings;

    public DamageDiller(PunchSettings PunchSettings, Transform AttackPoint)
    {
        this.attackPoint = AttackPoint;
        this.punchSettings = PunchSettings;
    }


}
