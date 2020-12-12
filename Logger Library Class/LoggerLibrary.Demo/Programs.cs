using LoggerLibrary;

namespace LoggerLibrary.Demo
{
    class Programs
    {
        static void Main()
        {
            //  Create a Logger Instace
            Logger log = new Logger("Loot", "Data.log");            
            log.LogFileAsync("Hello, World!", ErrorLevel.LogAlways).Wait();
        }
    }
}
