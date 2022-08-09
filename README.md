# Library

#### By _Joe Jack, Seung Lee_

#### _A simple website that ._

## Technologies Used

* _C#_
* _MSTest_
* _Razor_
* _HTML_
* _CSS_
* _Bootstrap_
* _Entity Framework_
* _Identity_

## Description

A simple website where a user can .

## Setup/Installation Requirements
_Requires console application such as Git Bash, Terminal, or PowerShell_

1. Open Git Bash or PowerShell if on Windows and Terminal if on Mac
2. Run the command

    ``git clone https://github.com/leark/Library.Solution.git``

3. Run the command

    ``cd Library.Solution``

* You should now have a folder `Library.Solution` with the following structure.
    <pre>Library.Solution
    ├── .gitignore 
    ├── ... 
    └── Library
        ├── Controllers
        ├── Models
        ├── ...
        ├── README.md
        └── Startup.cs</pre>

4. Add a file named appsettings.json in the following location 

    <pre>Library.Solution
    ├── .gitignore 
    ├── ... 
    └── Library
        ├── Controllers
        ├── Models
        ├── ...
        ├── Startup.cs
        └── <strong>appsettings.json</strong></pre>
      
5. Copy and paste below JSON text in appsettings.json.

```json
{
  "ConnectionStrings": {
      "DefaultConnection": "Server=localhost;Port=3306;database=library;uid=root;pwd=[YOUR-PASSWORD-HERE]"
  }
}
```

7. Replace [YOUR-PASSWORD-HERE] with your MySQL password.

8. Run the command

    ```dotnet ef database update```


<strong>To Run</strong>

Navigate to the following directory in the console
    <pre>Library.Solution
    └── <strong>Library</strong></pre>

Run the following command in the console

  ``dotnet build``

Then run the following command in the console

  ``dotnet run``

This program was built using _`Microsoft .NET SDK 5.0.401`_, and may not be compatible with other versions. Your milage may vary.

## Known Bugs

* _No known issues_

## License

[GNU](/LICENSE)

Copyright (c) 2022 Seung Lee