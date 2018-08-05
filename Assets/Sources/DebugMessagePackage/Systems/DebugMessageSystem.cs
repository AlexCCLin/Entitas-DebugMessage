//created by snippet - ecs_react_system
using System.Collections.Generic;
//using System.Linq;
using Entitas;

public sealed class DebugMessageSystem : ReactiveSystem<GameEntity> {

	//connect services
	

	readonly Contexts _contexts;

	public DebugMessageSystem (Contexts contexts) : base(contexts.game) {
		_contexts = contexts;
	}

	protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context) {
		//return context.CreateCollector (GameMatcher.GameBoardElement.Removed ());
		return context.CreateCollector(GameMatcher.DebugMessage);
	}

	protected override bool Filter(GameEntity entity) {
		//return !entity.isGameBoardElement;
		return entity.hasDebugMessage;
	}

	protected override void Execute(List<GameEntity> entities) {
		//_contexts.gameState.ReplaceScore (_contexts.gameState.score.value + entities.Count);
		foreach (var e in entities)
		{
			// we can safely access their DebugMessage component
			// then grab the string data and print it
			//Debug.Log(e.debugMessage.message);
			DebugMessageService.singleton.console_log(e.debugMessage.message, e.debugMessageGroup.gid);
		}
	}

}