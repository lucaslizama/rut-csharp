# Rut - Validator, Formatter & Generator

## Table of Contents

- [Introduction](#introduction)
- [Technologies](#technologies)

### Introduction

Rut is a library written with the purpose of centralizing all
common Chilean Rut operations and use cases in a lightweight 
and easy to use package. It's written in C# and targets most 
.NET recent versions. It's main features include a **Parser**, 
**Formatter** and a **Generator** for Chilean Ruts. 

### Technologies

- .NET 5.0
- XUnit (Testing)

### Framework Compatibility

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

### Setup

#### Install from NuGet

##### .NET CLI

`dotnet add package LucasLizama.Rut --version 0.1.2`

##### Package Manager

`Install-Package LucasLizama.Rut -Version 0.1.2`

#### Build from source

To build from source you need .NET 5.0 SDK and either: 
- **Dotnet CLI**, 
- **Visual Studio IDE**
- **Jetbrains Rider IDE**.

##### Dotnet CLI

1. Open a command line window and place yourself in the root directory of the project.
2. Run the `dotnet restore` command.
3. Run the `dotnet publish -f [DOTNET_FRAMEWORK_VERSION]` command.
4. The compiled .DLL files will be in the `Rut\bin\Release\[DOTNET_FRAMEWORK_VERSION]\`

The **DOTNET_FRAMEWORK_VERSION** values can be found [here](https://docs.microsoft.com/en-us/dotnet/standard/frameworks)

##### IDE
1. Open the project in your IDE of choice
2. Choose the **Release** publish configuration
3. Build the .DLL files, output directories are usually the same with all methods.