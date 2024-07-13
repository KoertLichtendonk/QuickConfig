# QuickConfig

QuickConfig is a simple configuration management library for .NET applications. It allows you to define configuration classes and manage their settings with ease.

## Features

- Easy-to-use configuration management.
- Supports saving and loading configuration settings.
- Automatically loads configuration from the application's assembly name.

## Usage

Here's a quick example to get you started with QuickConfig.

### Step 1: Define a Configuration Class

First, create a class that inherits from `ConfigBase` and define your configuration properties.

```csharp
using QuickConfig;

public class Config : ConfigBase
{
    public string SettingOne { get; set; }
    public string SettingTwo { get; set; }
}
```

### Step 2: Initialize ConfigManager and Load Configuration

Create an instance of `ConfigManager` with a name (in the example below I use the assembly name as the folder name, and Config as the file name) and load the configuration.

```csharp
ConfigManager configManager = new ConfigManager(System.Reflection.Assembly.GetExecutingAssembly().GetName().Name);
Config config = configManager.GetConfig<Config>("Config");
```

### Step 3: Modify and Save Configuration

You can now modify your configuration settings and save them.

```csharp
config.SettingOne = "Test";

if (config.SettingOne == "Test")
{
    Console.WriteLine("Config setting was set correctly.");
}
else
{
    Console.WriteLine("Config setting was not set correctly.");
}

config.Save();
```

## Complete Example

Here is the complete example code:

```csharp
using QuickConfig;

public class Config : ConfigBase
{
    public string SettingOne { get; set; }
    public string SettingTwo { get; set; }
}

public class Program
{
    public static void Main()
    {
        ConfigManager configManager = new ConfigManager(System.Reflection.Assembly.GetExecutingAssembly().GetName().Name);
        Config config = configManager.GetConfig<Config>("Config");

        config.SettingOne = "Test";

        if (config.SettingOne == "Test")
        {
            Console.WriteLine("Config setting was set correctly.");
        }
        else
        {
            Console.WriteLine("Config setting was not set correctly.");
        }

        config.Save();
    }
}
```
