using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModuleBase : MonoBehaviour
{
    [SerializeField] public bool include = true;

    public bool OnIReturnInclude()
    {
        return include;
    }

    private void Reset()
    {
        MasterModuleTerrain master = gameObject.GetComponent<MasterModuleTerrain>();
        master.OnAutomaticAddToList(this);
    }

}
