using System.Text;

namespace Lab;

public static class Keyboard
{

    public static void Run()
    {
        string argm2 = "C:\\Program Files\\Common Files\\microsoft shared\\ink\\tabtip.exe";

        Console.WriteLine(argm2);

        int retVal = NativeMethods.ShellExecute(IntPtr.Zero, new StringBuilder("Open"), new StringBuilder(argm2), new StringBuilder(" /SeekDesktop"), new StringBuilder(""), 1);

        Console.WriteLine(retVal);
    }


}
