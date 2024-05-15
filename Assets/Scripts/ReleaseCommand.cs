using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReleaseCommand : Command
{
    public override void Execute(ObjectPicker picker)
    {
        picker.SetObject(null);
        picker.ChangeCommand(new PickCommand());
    }
}
