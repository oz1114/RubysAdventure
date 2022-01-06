using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageZone : MonoBehaviour
{
    private void OnTriggerStay2D(Collider2D character)
    {
        RubyController controller = character.GetComponent<RubyController>();

        if(controller != null && controller.health > 0)
        {
            controller.changeHealth(-1);
        }
    }
}
