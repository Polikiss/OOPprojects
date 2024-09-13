namespace Lab5.Presentation.Console;

public interface IScenario
{
    string ScenarioName { get; }

    void Run();
}