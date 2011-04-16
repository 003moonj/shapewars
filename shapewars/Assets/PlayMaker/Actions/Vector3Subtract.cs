// (c) Copyright HutongGames, LLC 2010-2011. All rights reserved.

namespace HutongGames.PlayMaker.Actions
{
	[ActionCategory(ActionCategory.Vector3)]
	[Tooltip("Adds a Vector3 value to a Vector3 variable.")]
	public class Vector3Subtract : FsmStateAction
	{
		[RequiredField]
		[UIHint(UIHint.Variable)]
		public FsmVector3 vector3Variable;
		[RequiredField]
		public FsmVector3 subtractVector;
		public bool everyFrame;

		public override void Reset()
		{
			vector3Variable = null;
			subtractVector = new FsmVector3 { UseVariable = true };
			everyFrame = false;
		}

		public override void OnEnter()
		{
			vector3Variable.Value = vector3Variable.Value - subtractVector.Value;
			
			if (!everyFrame)
				Finish();		
		}

		public override void OnUpdate()
		{
			vector3Variable.Value = vector3Variable.Value - subtractVector.Value;
		}
	}
}

