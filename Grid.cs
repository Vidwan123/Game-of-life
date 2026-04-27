using GameOfLifeA24.Cells;
using GameOfLifeA24.Factories;
using GameOfLifeA24.Rules;

namespace GameOfLifeA24;

internal sealed class Grid
{
    private readonly int _rows;
    private readonly int _cols;
    private Cell[,] _cells;
    private readonly ICellFactory _factory;
    private readonly IRule _rule;

    public Grid(int rows, int cols, List<(int x, int y)> initialAliveCells, IRule rule, ICellFactory factory)
    {
        _rows = rows;
        _cols = cols;
        _rule = rule;
        _factory = factory;
        _cells = new Cell[rows, cols];
        InitializeGrid(initialAliveCells);
    }

    public void InitializeGrid(List<(int x, int y)> initialAliveCells)
    {
        for (int x = 0; x < _rows; x++)
            for (int y = 0; y < _cols; y++)
            {
                bool alive = initialAliveCells.Any(p => p.x == x && p.y == y);
                _cells[x, y] = _factory.CreateCell(x, y, alive);
            }
    }

    public void UpdateGrid()
    {
        var newCells = new Cell[_rows, _cols];

        for (int x = 0; x < _rows; x++)
            for (int y = 0; y < _cols; y++)
            {
                int aliveNeighbors = GetAliveNeighborsCount(x, y);
                newCells[x, y] = _rule.GetNextState(_cells[x, y], aliveNeighbors);
            }

        _cells = newCells;
    }

    public Cell GetCell(int x, int y) => _cells[x, y];

    private int GetAliveNeighborsCount(int x, int y)
    {
        int count = 0;

        for (int dx = -1; dx <= 1; dx++)
            for (int dy = -1; dy <= 1; dy++)
            {
                if (dx == 0 && dy == 0) continue;

                int nx = x + dx;
                int ny = y + dy;

                if (nx >= 0 && nx < _rows && ny >= 0 && ny < _cols)
                    if (_cells[nx, ny].IsAlive())
                        count++;
            }

        return count;
    }
}
