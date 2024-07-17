<a id="readme-top"></a>

[![MIT License][license-shield]][license-url]




<!-- PROJECT LOGO -->
<br />
<div align="center">
  <a href="https://github.com/sic-mundus-creatus-est/sysprog-project-three">
    <img src="images/Rx.png" alt="Logo" width="80" height="80">
  </a>

<h3 align="center">sysprog-project-three</h3>

  <p align="center">
    The project's main goal was to familiarize with reactive programming in .NET Framework as part of the System Programming course.
    <br />
    <br />
    <br />
    <strong>Check out my solutions of other System Programming course projects »</strong>
    <br />
    <a href="https://github.com/sic-mundus-creatus-est/sysprog-project-one">sysprog-project-one</a>
    ·
    <a href="https://github.com/sic-mundus-creatus-est/sysprog-project-two">sysprog-project-two</a>
  </p>
</div>




<!-- TABLE OF CONTENTS -->
<details>
  <summary>Table of Contents</summary>
  <ol>
    <li>
      <a href="#about-the-project">About the Project</a>
      <ul>
        <li><a href="#built-with">Built With</a></li>
      </ul>
    </li>
    <li>
      <a href="#getting-started">Getting Started</a>
      <ul>
        <li><a href="#prerequisites">Prerequisites</a></li>
        <li><a href="#installation-and-setup">Installation and Setup</a></li>
      </ul>
    </li>
    <li><a href="#usage">Usage</a></li>
    <li><a href="#license">License</a></li>
  </ol>
</details>




<!-- ABOUT THE PROJECT -->
## About the Project

This project is not related to the previous two but it also involved creating a web server that logs all received requests and their processing details. For this assignment, I was randomly given TheCocktailDB API to fetch cocktail preparation instructions based on the cocktail name and display them with a `WORD CLOUD`. The primary focus was on utilizing the `Reactive Extensions for .NET (Rx)` to implement reactive programming paradigms. Though Rx is single-threaded by default, this implementation includes multithreading and `schedulers` to enhance performance and responsiveness. `.NET Core` was chosen for its cross-platform capabilities, performance, and rich support for asynchronous programming, making it an excellent fit for reactive programming.

<div style="text-align: center;">
  <img src="images/not_found.png" alt="Homepage" style="border-radius: 10px;">
</div>

</br>

A simple web-based frontend, inspired by TheCocktailDB's theme, was developed to facilitate testing, though it was not necessary for this assignment. This frontend supports searching for cocktails by name, displaying preparation instructions, and generating a word cloud to show the frequency of words in the instructions.

</br>

- To search for cocktail instructions, simply enter the name of a cocktail in the search field and submit the query.

<div align="center">
  <img src="images/search.png" alt="Search example" style="border-radius: 10px; display: block; margin-top: 10px; margin-bottom: 10px;">
</div>

- The server will fetch preparation instructions of all cocktails that contain entered word/s from TheCocktailDB API and display them in the following format with the addition of `WORD CLOUD`:

<div align="center">
  <img src="images/result.png" alt="Result example" style="border-radius: 10px; display: block; margin-top: 10px;">
</div>

</br>

<p align="right"><a href="#readme-top">⬆️</a></p>

### Built With

* ![C#][CSharp] ![.NET][Dotnet]
* ![CSS][Css]
* ![HTML][Html]

<p align="right"><a href="#readme-top">⬆️</a></p>




<!-- GETTING STARTED -->
## Getting Started

To get a local copy up and running follow these simple steps.

### Prerequisites

For the easiest setup, I recommend having Visual Studio installed and set up, with .NET 8.0 installed.

### Installation and Setup

1. Clone the repo
   ```sh
   git clone https://github.com/sic-mundus-creatus-est/sysprog-project-three.git
   ```
2. Open the solution file » `ThirdProject/ThirdProject.sln`
3. Done! You're ready to start the server.
4. To stop the server, simply press `Ctrl+C` inside of the server console

### Optional

This solution is using the free public test API key for educational use. If you would like to further explore the possibilities of this API or purchase a production key, follow this hyperlink:
   - [TheCocktailDB API](https://www.thecocktaildb.com/api.php)

      - To change the API key, navigate to `CocktailService.cs` and configure an environment variable to replace the free test key "1" in the API endpoint link


<br/>
<br/>

<p align="right"><a href="#readme-top">⬆️</a></p>




<!-- USAGE EXAMPLES -->
## Usage

_Compared to the previous projects, this one has practical and real-life use :)_

This project primarily serves as an exploration of reactive programming paradigm, showcasing how Rx.NET can handle asynchronous and event-driven tasks efficiently. By leveraging observables, operators, and schedulers, it demonstrates the benefits of reactive programming in building responsive and scalable applications.

I recon that this implementation is not fully optimized and that there’s definitely room for improvement, but I’m leaving it as is to serve as a point of reference for my progress in coding. Additionally, it served as great practice for writing a README file, which is an essential skill for software documentation.

<p align="right"><a href="#readme-top">⬆️</a></p>




<!-- LICENSE -->
## License

Distributed under the MIT License. See `LICENSE` for more information.

<p align="right"><a href="#readme-top">⬆️</a></p>




<!-- MARKDOWN LINKS & IMAGES -->
[license-shield]: https://img.shields.io/github/license/sic-mundus-creatus-est/sysprog-project-three?style=for-the-badge
[license-url]: https://github.com/sic-mundus-creatus-est/sysprog-project-three/blob/main/LICENSE

[CSharp]: https://custom-icon-badges.demolab.com/badge/C%23-%23239120.svg?logo=cshrp&logoColor=white
[Dotnet]: https://img.shields.io/badge/.NET-512BD4?logo=dotnet&logoColor=fffS
[Css]: https://img.shields.io/badge/CSS-1572B6?logo=css3&logoColor=fff
[Html]: https://img.shields.io/badge/HTML-%23E34F26.svg?logo=html5&logoColor=white
