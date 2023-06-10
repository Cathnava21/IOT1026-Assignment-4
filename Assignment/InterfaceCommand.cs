namespace Assignment.InterfaceCommand;

public interface RobotCommand
{
    void Run(Robot robot);
}
public class OffCommand : RobotCommand
{
    public void Run(Robot robot) => robot.IsPowered = false;
}

public class OnCommand : RobotCommand
{
    public void Run(Robot robot) => robot.IsPowered = true;
}

public class WestCommand : RobotCommand
{
    public void Run(Robot robot) { if (robot.IsPowered) robot.X--; }
}

public class EastCommand : RobotCommand
{
    public void Run(Robot robot) { if (robot.IsPowered) robot.X++; }
}

public class SouthCommand : RobotCommand
{
    public void Run(Robot robot) { if (robot.IsPowered) robot.Y--; }
}

public class NorthCommand : RobotCommand
{
    public void Run(Robot robot) { if (robot.IsPowered) robot.Y++; }
}

public class RebootCommand : RobotCommand
{
    public void Run(Robot robot) { if (robot.IsPowered) robot.Y = 0; robot.X = 0; robot.IsPowered = false; }
}

