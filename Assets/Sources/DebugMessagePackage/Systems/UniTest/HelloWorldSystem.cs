//created by snippet - ecs_init_system
using System.Collections.Generic;
//using System.Linq;
using Entitas;
public sealed class HelloWorldSystem : IInitializeSystem {

	//connect services
	DebugMessageService _debug_message_service = DebugMessageService.singleton;

	readonly Contexts _contexts;

	public HelloWorldSystem (Contexts contexts) {
		_contexts = contexts;
	}

	public void Initialize() {
		_debug_message_service.create_oneshot_entity("Hello world", 0);

	}

}