# FsCsHybrid
This is an example of using F# library from C#.
The following steps show how to create a F# library and use it from a C# console application.

## 1. Create a Solution
```
% dotnet new sln -o FsCsHybrid
```

## 2. Create a F# Library
```
% cd FsCsHybrid
% dotnet new classlib -lang "F#" -o LibFs
```

## 3. Create a C# Console App
```
% dotnet new console -lang "C#" -o AppCs
```

## Current Directory Structure
```
% tree
.
├── AppCs
│   ├── AppCs.csproj
│   ├── Program.cs
│   └── obj
├── FooProj.sln
└── LibFs
    ├── LibFs.fsproj
    ├── Library.fs
    └── obj
```

## 4. Add LibFs to AppCs
```
% dotnet add AppCs/AppCs.csproj reference LibFs/LibFs.fsproj
```

## 5. Edit Program.cs
```
% cd AppCs
% vim Program.cs
```

### Program.cs
```csharp
// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello C#");

LibFs.Say.hello("F#");
```

## 6. Run
```
% dotnet run Program.cs
```

## Result
```
Hello C#
Hello F#
```

## 7. Add a F# module (Camera.fs)
```
% cd ../LibFs
% touch Camera.fs
% vim Camera.fs
```

### Camera.fs
```fshap
module CameraModule

// Greatest Common Divisor (GCD)
let rec gcd :
        int32->int32->int32 =
    fun a b ->
        match b with
        | 0 -> a
        | _ -> gcd b (a % b)

// camelCase is the convention in F#
let getBaseRatio :
        int32->
        int32->
        int32*int32 =
    fun width height ->
        let div = gcd width height
        width / div, height /div
```


## 8. Add the module (Camera.fs) to LibFs.fsproj
```
% vim LibFs.fsproj 
```

### LibFs.fsproj
```
<Project Sdk="Microsoft.NET.Sdk">

  <PropertyGroup>
    <TargetFramework>net7.0</TargetFramework>
    <GenerateDocumentationFile>true</GenerateDocumentationFile>
  </PropertyGroup>

  <ItemGroup>
    <Compile Include="Library.fs" />
    <Compile Include="Camera.fs" />
  </ItemGroup>

</Project>
```

## 9. Run
```
% cd ../AppCs
% dotnet run Program.cs
```

## Result
```
Hello C#
Hello F#
width : height = 16 : 9
```


## References
[https://learn.microsoft.com/en-us/dotnet/fsharp/get-started/get-started-command-line](https://learn.microsoft.com/en-us/dotnet/fsharp/get-started/get-started-command-line)

