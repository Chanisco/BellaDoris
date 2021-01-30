using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightSwitch : UsableObject
{

    public Light lightSwitch;
    private float originalLightRange;
    private void Start()
    {
        originalLightRange = lightSwitch.range;
    }



    public override void OnUseItem()
    {
        base.OnUseItem();
        StopCoroutine("TurnLight");
        if (LightActive == true)
        {
            LightActive = false;
        }
        else
        {
            LightActive = true;
        }
        StartCoroutine("TurnLight");
    
    }

    bool LightActive;
    public IEnumerator TurnLight()
    {
        bool Routine = true;
        while (Routine == true)
        {
            if (LightActive == true)
            {
                if (lightSwitch.range < originalLightRange)
                {
                    lightSwitch.range += 1f;
                    yield return new WaitForSeconds(0.1f);
                }
                else
                {
                    Routine = false;
                }
            }
            else
            {
                if (lightSwitch.range > 1)
                {
                    lightSwitch.range -= 1f;
                    yield return new WaitForSeconds(0.1f);
                }
                else
                {
                    Routine = false;
                }
            }
        }
        yield break;
    }

}
