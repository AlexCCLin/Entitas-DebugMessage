//created by snippet - ecs_feature_systems


public sealed class DebugSystems : Feature {
	public DebugSystems(Contexts contexts) {
		Add (new HelloWorldSystem(contexts));  //For UniTest
		Add (new LogMouseClickSystem (contexts)); //For UniTest

		Add (new DebugMessageSystem (contexts));
		Add (new CleanupDebugMessageSystem(contexts));
	}
}