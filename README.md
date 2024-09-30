# WordGameApp

## Description

In this app, you can search for anagrams of a word. It's a small project to familiarize myself with C# and WPF.

The word list is from https://github.com/davidak/wortliste, and the idea is from https://htdp.org/2024-8-20/Book/part_two.html#%28part._sec~3apermute-composition%29.

### Features
- Takes a user-provided word input and generates all possible permutations.
- Filters permutations based on a dictionary of valid words.
- Displays the valid word permutations in a message box.

### Technologies Used
- **C#** (Programming Language)
- **WPF (Windows Presentation Foundation)** for the user interface
- **.NET Framework** (or .NET Core, depending on your setup)

---

## Getting Started

### Prerequisites

To run the WordGameApp, you will need:
- Visual Studio (or any compatible C# IDE)
- .NET Framework or .NET Core SDK
- The word list file (`wortliste.txt`), which should be placed in the appropriate directory for the application to access.

### Installation

1. **Clone or download this repository**:
    ```bash
    git clone https://github.com/benjaminknopp/WordGameApp.git
    ```
2. **Open the solution in Visual Studio**.
  
3. **Build and run the application** by pressing `F5` or selecting `Build > Start Debugging` in Visual Studio.

### Usage

1. When the application starts, you will see a text input box.
2. Enter any word and click the button.
3. The app will:
   - Generate all permutations of the word.
   - Filter valid permutations based on the words present in the `wortliste.txt` file.
   - Display the valid words in a message box.

---


### TODO
- Add support for user-defined dictionary files.
- Implement a more robust UI to display the permutations in a list or table instead of a message box.

---

### Acknowledgments
- Word list is sourced from [wortliste on GitHub](https://github.com/davidak/wortliste).

---