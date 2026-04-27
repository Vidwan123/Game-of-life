# Conway's Game of Life MVC

A C# MVC application that simulates Conway's Game of Life, a cellular automaton where the next state of the grid is determined by simple rules based on neighboring cells.

## Features
- MVC architecture
- Game of Life simulation
- Unit tests
- Database persistence for rules and initial states
- Design patterns: Factory, Singleton, Repository, Strategy

## Rules
- A dead cell with exactly 3 live neighbors becomes alive
- A live cell with 2 or 3 neighbors survives
- A live cell with fewer than 2 neighbors dies
- A live cell with more than 3 neighbors dies

## Requirements
- Windows / SQL Server
- Visual Studio
- .NET / C#

## Project Structure
- Controllers
- Models
- Views
- Services
- Repositories
- Tests

## Grading Focus
- Unit tests
- Core engine correctness
- MVC separation
- Design patterns
- Persistence
- UI completeness
