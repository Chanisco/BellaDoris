using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalBase : UsableObject
{
    public SceneController _sceneController;
    public string levelName;
    public bool passingThePortal;
    private void OnEnable()
    {
        _sceneController = SceneController.Instance;
    }

    private void OnDisable()
    {
        
    }

    public override void OnUseItem(CharacterBase characterUsingObject)
    {
        if(passingThePortal == false)
        {
            passingThePortal = true;
            base.OnUseItem(characterUsingObject);
            //characterUsingObject.animator.SetBool("PassingTheGate",true);
            StartCoroutine("ChangeLevelAfterDelay");

        }
    }

    public IEnumerator ChangeLevelAfterDelay()
    {
        yield return new WaitForSeconds(1);
        _sceneController.CheckupLevel("InitUI");
    }
}
