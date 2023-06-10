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
    ///
    /// </summary>
    /// <throws> </throws>
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
    ///
    /// </summary>
    /// <param name="command"></param>
    /// <returns></returns>
    public bool LoadCommand(RobotCommand command)
    {
        if (_commandsLoaded >= NumCommands)
            return false;
        _commands.Enqueue(command);
        _commandsLoaded++;
        return true;
    }
}
