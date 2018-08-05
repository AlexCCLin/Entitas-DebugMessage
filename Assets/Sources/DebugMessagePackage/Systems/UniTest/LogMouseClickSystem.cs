//created by snippet - ecs_init_system
using System.Collections.Generic;
//using System.Linq;
using Entitas;
using UnityEngine;

public sealed class LogMouseClickSystem : IInitializeSystem , IExecuteSystem {

	//connect services
	DebugMessageService _debug_message_service = DebugMessageService.singleton;

	readonly Contexts _contexts;
	List<GameEntity> _log_mouse_entities = new List<GameEntity>();

	public LogMouseClickSystem (Contexts contexts) {
		_contexts = contexts;
	}

	public void Initialize() {
		GameEntity ge;
		ge = _debug_message_service.create_entity("Active logMouseClickSystem 1", DEBUG_MESSAGE_GID.DEBUG_MESSAGE_GID_1);
		_log_mouse_entities.Add (ge);
		ge = _debug_message_service.create_entity("Active logMouseClickSystem 2", DEBUG_MESSAGE_GID.DEBUG_MESSAGE_GID_2);
		_log_mouse_entities.Add (ge);
	}

	public void Execute() {
		
		if (Input.GetMouseButtonDown(0))
		{
			_log_mouse_entities[0].AddDebugMessage("Left Mouse Button Clicked");
		}

		if (Input.GetMouseButtonDown(1))
		{
			_log_mouse_entities[1].AddDebugMessage("Right Mouse Button Clicked");
		}
	}

}