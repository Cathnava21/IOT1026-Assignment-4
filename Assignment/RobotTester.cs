using Assignment.InterfaceCommand;

namespace Assignment;

static class RobotTester
{
    public static void TestRobot()
    {
        int totalCommands = 1;
        Robot robot = new Robot();
        Console.WriteLine("Give 6 commands to the robot. Possible commands are:");
        Console.WriteLine("ON");
        Console.WriteLine("OFF");
        Console.WriteLine("NORTH");
        Console.WriteLine("SOUTH");
        Console.WriteLine("EAST");
        Console.WriteLine("WEST");
        Console.WriteLine("REBOOT\n");
        do
        {
            Console.Write($"Assign command #{totalCommands}: ");
            string? choice = Console.ReadLine()?.ToUpper();
            RobotCommand? command = choice switch
            {
                "ON" => new OnCommand(),
                "OFF" => new OffCommand(),
                "NORTH" => new NorthCommand(),
                "SOUTH" => new SouthCommand(),
                "EAST" => new EastCommand(),
                "WEST" => new WestCommand(),
                "REBOOT" => new RebootCommand(),
                _ => null
            };
            if (command != null)
            {
                robot.LoadCommand(command);
                totalCommands++;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Invalid Command - try again");
                Console.ResetColor();
            }
        } while (totalCommands <= 6);
        Console.WriteLine();
        robot.Run();
        Console.ReadLine();
    }
}
