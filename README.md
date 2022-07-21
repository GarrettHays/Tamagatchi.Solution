# Minion Tamagotchi

#### By _**Alex Shevlin Matt Herbert Garrett Hays**_  

#### _Web app that allows the user to generate a minion tamagotchi._  

---

## Table of Contents

**[Technologies Used](#technologies-used)  
[Description](#description)  
[Technology Requirements](#technology-requirements)  
[Setup and Installation](#setupinstallation-requirements)  
[Known Bugs](#known-bugs)  
[License](#license)**

## Technologies Used

* _C#_
* _.NET_
* _Markdown_
* _HTML_
* _CSS_
* _BootStrap_

---
## Description

_A web app that lets the user input a name to receive a randomly generated minion. Users have access to a play/feed button to increase the minion's current Hunger and Happy levels. If the minion is not fed regularly both of those numbers will decrease until they hit 0. If both Hunger and Happy hit 0 you will no longer be able to feed it and it will display a status as dead._

---
## Setup/Installation Requirements

* Install *`Microsoft .NET SDK`*
* Place files in a folder named `ProjectName.Solution`
    <pre>Tamagatchi.Solution
    ├── Tamagatchi
    └── Tamagatchi.Tests</pre>
<details>
<summary><strong>To Run</strong></summary>
Navigate to  
   <pre>Tamagatchi.Solution
   ├── <strong>Tamagatchi</strong>
   └── Tamagatchi.Tests</pre>

Run ```$ dotnet run``` in the console
</details>

<details>
<summary><strong>For Testing</strong></summary>
Navigate to  
    <pre>Tamagatchi.Solution
    ├── Tamagatchi
    └── <strong>Tamagatchi.Tests</strong></pre>

Run ```$ dotnet test``` in the console

</details>
<br>

This program was built using *`Microsoft .NET SDK 6.0.6`*, and may not be compatible with other versions. Your milage may vary.

---
## Known Bugs

* _The page will not update every time the Happy and Hunger levels are decreased and require a manual reload to display._

## License

[GNU](/LICENSE-GNU)

Copyright (c) 2022 Alex Shevlin, Matt Herbert, Garrett Hays


