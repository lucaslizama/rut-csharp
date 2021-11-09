# Rut - Validator, Formatter & Generator
![Nuget](https://img.shields.io/nuget/v/Lucaslizama.Rut?style=for-the-badge)
![Nuget](https://img.shields.io/nuget/dt/LucasLizama.Rut?style=for-the-badge)
![GitHub](https://img.shields.io/github/license/lucaslizama/rut?style=for-the-badge)
[![Donate](https://img.shields.io/badge/Donate-Paypal-blue?style=for-the-badge&logo=paypal)](https://www.paypal.com/donate?business=PYWFG2U5KRY2N&no_recurring=0&item_name=Develop+and+maintain+quality%2C+free+and+open+source+software&currency_code=USD)

## Table of Contents

- [Rut - Validator, Formatter & Generator](#rut---validator-formatter--generator)
  - [Table of Contents](#table-of-contents)
  - [Introduction](#introduction)
  - [Setup](#setup)
    - [Install from NuGet](#install-from-nuget)
      - [.NET CLI](#net-cli)
      - [Package Manager](#package-manager)
  - [Technologies](#technologies)
  - [Framework Compatibility](#framework-compatibility)
  - [Features](#features)
  - [Usage](#usage)
    - [Rut Class](#rut-class)
    - [Generator Class](#generator-class)
    - [Utility Clases](#utility-clases)
    - [Build from source](#build-from-source)
      - [Command Line](#command-line)
      - [IDE](#ide)

## Introduction

Rut is a library written with the purpose of centralizing all
common Chilean Rut operations and use cases in a lightweight
and easy to use package. It's written in C# and targets most 
.NET recent versions. This package has no external dependencies
so it's very small.

## Setup

### Install from NuGet

#### .NET CLI

`dotnet add package LucasLizama.Rut --version 0.4.4`

#### Package Manager

`Install-Package LucasLizama.Rut -Version 0.4.4`

## Technologies

- .NET 5.0
- XUnit (Testing)

## Framework Compatibility

- .NET Standard 2.1
- .NET Standard 2.0
- .NET 5.0
- .NET Core 3.1
- .NET Framework 4.8.0
- .NET Framework 4.7.2
- .NET Framework 4.7.1
- .NET Framework 4.7.0
- .NET Framework 4.6.2
- .NET Framework 4.6.1
- .NET Framework 4.6.0
- .NET Framework 4.5.2
- .NET Framework 4.5.1
- .NET Framework 4.5.0

## Features

- Manage all rut related operations from an instance of the Rut class.
- Parse rut from text in various formats.
- Calculate rut DV (Verification Digit) automatically or on demand.
- Validate rut DV.
- Generate random Rut or Rut's with or without duplicates.
- Generate random Rut or Rut's with specific DV with or without duplicates.
- Generate Rut's from a numeric range.
- All code used by the Rut class to calculate, parse, validate 
and format is public and stored in utility classes on the `Rut.Utils`
namespace, you can use them any way you want.

## Usage

### Rut Class

All functionality is available by creating an instance of the Rut class using
one the many constructors available, in almost all cases the DV will be calculated
automatically except if it's specified explicitly.

```c#
using Rut;

static void Main(string[] args) // args = {"11111111", "1-9", "18.464.695", "Not A Rut"} 
{
    var rut1 = new Rut(args[0]);
    var rut2 = new Rut(args[1]);
    var rut3 = new Rut(args[2]);
    var rut4 = new Rut(args[3]); // This would throw an InvalidRutStringException
    var rut5 = new Rut("11.111.111", '5'); // The Dv is wrong in this one
    
    // Check if rut is valid
    Console.WriteLine($"Rut 1 valid: ${rut1.Valid}"); // True
    Console.WriteLine($"Rut 2 valid: ${rut2.Valid}"); // True
    Console.WriteLine($"Rut 3 valid: ${rut3.Valid}"); // True
    Console.WriteLine($"Rut 5 valid: ${rut5.Valid}"); // False
    
    // Rut string Formats
    Console.WriteLine($"Rut 1: ${rut1.Number}-${rut1.Dv}"); //Rut 1: 11111111-1
    Console.WriteLine($"Rut 1: ${rut1.CleanRut}");          //Rut 1: 11111111-1
    Console.WriteLine($"Rut 1: ${rut1.WithDots}");          //Rut 1: 11.111.111-1
    Console.WriteLine($"Rut 1: ${rut1.WithDotsNoDv}");      //Rut 1: 11.111.111
    
    Console.WriteLine($"Rut 2: ${rut2.Number}-${rut1.Dv}"); //Rut 2: 1-1
    Console.WriteLine($"Rut 2: ${rut2.CleanRut}");          //Rut 2: 1-9
    Console.WriteLine($"Rut 2: ${rut2.WithDots}");          //Rut 2: 1-9
    Console.WriteLine($"Rut 2: ${rut2.WithDotsNoDv}");      //Rut 2: 1
    
    Console.WriteLine($"Rut 3: ${rut3.Number}-${rut1.Dv}"); //Rut 3: 18464695-1
    Console.WriteLine($"Rut 3: ${rut3.CleanRut}");          //Rut 3: 18464695-1
    Console.WriteLine($"Rut 3: ${rut3.WithDots}");          //Rut 3: 18.464.695-1
    Console.WriteLine($"Rut 3: ${rut3.WithDotsNoDv}");      //Rut 3: 18.464.695
    
    Console.WriteLine($"Rut 5: ${rut5.Number}-${rut5.Dv}"); //Rut 5: 11111111-5
    Console.WriteLine($"Rut 5: ${rut5.CleanRut}");          //Rut 5: 11111111-5
    Console.WriteLine($"Rut 5: ${rut5.WithDots}");          //Rut 5: 11.111.111-5
    Console.WriteLine($"Rut 5: ${rut5.WithDotsNoDv}");      //Rut 5: 11.111.111
}
```

### Generator Class

```c#
using Rut;
using Rut.Utils;

static void Main(string[] args) 
{
    // Generate a Random Rut
    var rut1 = Generator.RandomRut(); // Totally random
    var rut2 = Generator.RandomRut('K'); // DV will be 'K'
    var rut3 = Generator.RandomRut('1'); // DV will be '1'

    // Generate a List of random Rut's
    var ruts1 = Generator.RandomRuts(100); // Totally random, 100 ruts, can repeat.
    var ruts2 = Generator.RandomRuts(100, 'K'); // DV's will be 'K', 100 ruts, can repeat.
    var ruts3 = Generator.RandomRuts(100, '5', true); // DV's will be '5', 100 ruts, no duplicates.

    // Generate a List of Rut's from a given numeric range
    var ruts4 = Generator.RutRange(1, 100); // All rut's from 1 to 100 inclusive, 100 ruts.
    var ruts5 = Generator.RutRange(18_000_000, 19_000_000); // 1.000.001 rut's because of inclusive min/max.
}
```

### Utility Clases

The `Rut.Utils` namespace has various static classes that are used by the `Rut`
class for **Parsing, Validation, Formatting, etc**, and all methods are public.

The main classes are:

- Calculator
- Validator
- Formatter
- Generator
- Parser
- Cleaner

### Build from source

To build from source you need .NET 5.0 SDK and either: 
- Dotnet CLI, 
- Visual Studio IDE
- Jetbrains Rider IDE.

#### Command Line

1. Open a command line window and place yourself in the root directory of the project.
2. Run the `dotnet restore` command.
3. Run the `dotnet publish -f [DOTNET_FRAMEWORK_VERSION]` command.
4. The compiled .DLL files will be in the `Rut\bin\Release\[DOTNET_FRAMEWORK_VERSION]\`

The **DOTNET_FRAMEWORK_VERSION** values can be found [here](https://docs.microsoft.com/en-us/dotnet/standard/frameworks)

#### IDE
1. Open the project in your IDE of choice
2. Choose the **Release** publish configuration
3. Build the .DLL files, output directories are usually the same with all methods.
