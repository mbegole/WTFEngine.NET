# WTF Engine .NET
--
Inspired by the [WTFEngine](https://github.com/soulwire/WTFEngine) originally made in JavaScript and now converted to .NET!

![build](https://github.com/mbegole/WTFEngine.NET/workflows/.NET%20Core/badge.svg?branch=master)
[![License: MIT](https://img.shields.io/badge/License-MIT-yellow.svg)](https://opensource.org/licenses/MIT)

## Usage
Download the source code and add to your project or download from [NuGet.](https://www.nuget.org/packages/WTFEngine.NET/)

## WTF is this?
This is a simple interface made in C# for creating what are essentially mad-libs. For example:

```c# 
IEnumerable<string> names = new List<string>
{
  "Ed",
  "Kevin",
};

IEnumerable<string> nouns = new List<string>
{
    "Plank",
    "Jawbreakers",
};

var template = "@ProperNoun loves @Noun.";
var sets = new List<IEnumerable<string>> { names, nouns };

var wtf = new WTF();
var result = wtf.Generate(template, sets);
```

This code could generate ```Ed loves Jawbreakers.``` or ```Kevin loves Plank.``` or ```Ed loves Plank.``` and so on.

You can even pass in a custom regex pattern to use instead of using @ as the prepend, for example:

```c#
var wtf = new WTF(@"~([A-Za-z]*)");
```

This code would look for substrings in the template with the ~ prepend.

#### Dependency Injection
An interface was included in this project for simple dependency injection use cases.

## Why TF did you make this?
This was just a side project I made while using the idea of the WTF Engine on a C# project. Nothing too crazy is going on here.
