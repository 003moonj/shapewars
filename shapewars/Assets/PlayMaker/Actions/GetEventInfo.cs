// (c) Copyright HutongGames, LLC 2010-2011. All rights reserved.

using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[ActionCategory(ActionCategory.StateMachine)]
	[Tooltip("Gets info on the last event that caused a state change. See also Set Event Data action.")]
	public class GetEventInfo : FsmStateAction
	{
		[UIHint(UIHint.Variable)]
		public FsmGameObject sentByGameObject;
		[UIHint(UIHint.Variable)]
		public FsmString fsmName;
		[UIHint(UIHint.Variable)]
		public FsmBool getBoolData;
		[UIHint(UIHint.Variable)]
		public FsmInt getIntData;
		[UIHint(UIHint.Variable)]
		public FsmFloat getFloatData;
		[UIHint(UIHint.Variable)]
		public FsmVector3 getVector3Data;
		[UIHint(UIHint.Variable)]
		public FsmString getStringData;
		[UIHint(UIHint.Variable)]
		public FsmGameObject getGameObjectData;

		public override void Reset()
		{
			sentByGameObject = null;
			fsmName = null;
			getBoolData = null;
			getIntData = null;
			getFloatData = null;
			getVector3Data = null;
			getStringData = null;
			getGameObjectData = null;
		}

		public override void OnEnter()
		{
			if (Fsm.EventData.SentByFsm != null)
			{
				sentByGameObject.Value = Fsm.EventData.SentByFsm.GameObject;
				fsmName.Value = Fsm.EventData.SentByFsm.Name;
			}
			else
			{
				sentByGameObject.Value = null;
				fsmName.Value = "";
			}
			
			getBoolData.Value = Fsm.EventData.BoolData;
			getIntData.Value = Fsm.EventData.IntData;
			getFloatData.Value = Fsm.EventData.FloatData;
			getVector3Data.Value = Fsm.EventData.Vector3Data;
			getStringData.Value = Fsm.EventData.StringData;
			getGameObjectData.Value = Fsm.EventData.ObjectData as GameObject;
			
			Finish();
		}
	}
}