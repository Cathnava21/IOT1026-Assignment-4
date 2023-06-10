using Assignment.InterfaceCommand;

namespace Assignment;

public class Robot
{
    public int NumCommands { get; }
    public int X { get; set; }
    public int Y { get; set; }
    public bool IsPowered { get; set; }

    private const int DefaultCommands = 6;
    //with new type of collect we can control the number of commands in a better way
    private readonly Queue<RobotCommand> _commands;
    private int _commandsLoaded = 0;

    /// <summary>
    /// Returns a string representation of the robot's current state.
    /// </summary>
    /// <returns>A string representation of the robot's current state.</returns>
    public override string ToString()
    {
        return $"[{X} {Y} {IsPowered}]";
    }

    public Robot() : this(DefaultCommands) { }

    /// <summary>
    /// Constructor that initializes the robot with the capacity to store a user specified
    /// number of commands
    /// </summary>
    /// <param name="numCommands">The maximum number of commands the robot can store</param>
    public Robot(int numCommands)
    {
        _commands = new Queue<RobotCommand>(numCommands);
        NumCommands = numCommands;
    }

    /// <summary>
    /// Executes the loaded commands in the robot's queue.
    /// </summary>
    /// <returns><c>true</c> if the commands were executed successfully; otherwise, <c>false</c>.</returns>
    public bool Run()
    {
        if (_commands.Count == 0)
            return false;

        while (_commands.Count > 0)
        {
            var command = _commands.Dequeue();
            command.Run(this);
            Console.WriteLine(this);
        }
        return true;
    }

    /// <summary>
    /// Loads a command into the robot's queue.
    /// </summary>
    /// <param name="command">The command to be loaded.</param>
    /// <returns><c>true</c> if the command was loaded successfully; otherwise, <c>false</c>.</returns>
    public bool LoadCommand(RobotCommand command)
    {
        if (_commandsLoaded >= NumCommands)
            return false;
        _commands.Enqueue(command);
        _commandsLoaded++;
        return true;
    }
}
