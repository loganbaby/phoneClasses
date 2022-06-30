namespace phoneClasses
{
    internal class main
    {
        private enum MenuCommand
        {
            ADD = 1,
            CALL,
            SMS,
            EXIT
        }

        private static MenuCommand getCommands()
        {
            System.Console.WriteLine("Enter the command:");
            System.Console.WriteLine(System.Convert.ToUInt16(MenuCommand.ADD) + "# Add phone number");
            System.Console.WriteLine(System.Convert.ToUInt16(MenuCommand.CALL) + "# Call to phone number");
            System.Console.WriteLine(System.Convert.ToUInt16(MenuCommand.SMS) + "# Sms to phone number");
            System.Console.WriteLine(System.Convert.ToUInt16(MenuCommand.EXIT) + "# Exit");
            System.Console.Write(">>> ");
            return (MenuCommand)System.Convert.ToUInt16(System.Console.ReadLine());
        }
        private static int Main()
        {
            do
            {
                MenuCommand command = getCommands();

                switch (command)
                {
                    case MenuCommand.ADD:
                        Phone.add();
                        break;
                    case MenuCommand.CALL:
                        Phone.call();
                        break;
                    case MenuCommand.SMS:
                        Phone.sms();
                        break;
                    case MenuCommand.EXIT:
                        return 1;
                    default:
                        System.Console.WriteLine("Wrong data!");
                        break;
                }

                System.Console.ReadKey();
                System.Console.Clear();
            } while (true);
        }
    }
}      //namespace PhoneClasses
