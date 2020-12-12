# Logger Library

### A simple DLL that will allow you very simply log to a file asynchronously with an extension type of your choice with relative ease (I Hope).

------

## How To Use?

## Simply,

1. ### Create an Instance of the Logger class from the LoggerLibrary DLL.

2. ### Call **LogFileAsync()** from the Logger Instance you made.

3. ### Pass in the text you would like to log to a file along with the error level.

```c#
using LoggerLibrary;

namespace Yournamespace
{
    class Program
    {
        static void Main(string[] ars)
        {
            Logger logger = new Logger();
            logger.LogFileAsync("Message To Log", ErrorLevel).Wait();
        }
    }
}
```

## Alternatively 

### If you would like to Log to a file of your choosing you can simply pass you desired Folder name and file name along with the extension as parameters when creating the Logger Instance.

### See Bellow For Visual Guidance.

```c#
using LoggerLibrary;

namespace Yournamespace
{
    class Program
    {
        static void Main(string[] ars)
        {
            Logger logger = new Logger("Folder Name", "LoggedData.txt");
            logger.LogFileAsync("Message To Log", ErrorLevel).Wait();
        }
    }
}
```



## Conclusion

### Simply download the Solution and load up the .sln and hit **CTRL + F5**. It will create a file called *Loot* with a file inside called *Data.log*. Give it a try. Feedback it greatly appreciated.
