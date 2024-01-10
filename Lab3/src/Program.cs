using Lab3.Commands;
using Lab3.Data;
using Lab3.Models;
using Lab3.Models.Commands;

TurtleContext context = new();

CommandExecutor executor = new();

Turtle tr = context.Turtles.FirstOrDefault() ?? new Turtle();

executor.AddCommands(
	new AngleCommand(tr),
	new ColorCommand(tr),
	new ListCommand(tr),
	new MoveCommand(tr),
	new PenDownCommand(tr),
	new PenUpCommand(tr),
	new SaveJsonCommand<Turtle>(tr),
	new LoadJsonCommand<Turtle>(tr),
	new SaveXmlCommand<Turtle>(tr),
	new LoadXmlCommand<Turtle>(tr)
);



executor.Help();
while (true)
{
	try
	{
		if (!executor.TryExecuteCommand())
		{
			break;
		}
	}
	catch (ExecutionException e)
	{
		Console.Error.WriteLine($"Error: {e.Message}");
	}
}
