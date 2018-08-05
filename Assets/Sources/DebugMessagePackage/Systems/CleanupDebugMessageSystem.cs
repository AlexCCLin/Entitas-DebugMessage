//created by snippet - ecs_cleanup_system
using System.Collections.Generic;
//using System.Linq;
using Entitas;
public sealed class CleanupDebugMessageSystem : ICleanupSystem{

	//connect services
	

	readonly Contexts _contexts;
	readonly IGroup<GameEntity> _debugMessages;

	public CleanupDebugMessageSystem (Contexts contexts) {
		_contexts = contexts;
		_debugMessages = _contexts.game.GetGroup(GameMatcher.DebugMessage);
	}

	public void Cleanup() {
		foreach(var e in _debugMessages.GetEntities()) {
			
			if (e.isDebugMessageOneshot) {
				e.Destroy ();
			} else {  
				//我們不要destroy entity ,而是消化掉entity內的 message component
				e.RemoveDebugMessage ();
			}
		}
	}

}