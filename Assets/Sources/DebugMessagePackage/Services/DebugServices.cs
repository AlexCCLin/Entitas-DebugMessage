//created by snippet - ecs_services
using System;

public class DebugServices {

	public static DebugServices singleton = new DebugServices();

	public void Initialize(Contexts contexts, DebugSystemUniTestController controller) {
		DebugMessageService.singleton.Initialize (contexts);

	}
}	