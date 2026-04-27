using GameOfLifeA24.Cells;

namespace GameOfLifeA24.Rules;

public sealed class HighLifeRule : IRule
{
    public Cell GetNextState(Cell cell, int aliveNeighbors)
    {
        if (cell.IsAlive())
        {
            // Same survival rule as Standard: 2 or 3 neighbors
            if (aliveNeighbors == 2 || aliveNeighbors == 3)
                return new AliveCell(cell.X, cell.Y);

            return new DeadCell(cell.X, cell.Y);
        }
        else
        {
            // HighLife birth rule: 3 OR 6 neighbors (different from Standard!)
            if (aliveNeighbors == 3 || aliveNeighbors == 6)
                return new AliveCell(cell.X, cell.Y);

            return new DeadCell(cell.X, cell.Y);
        }
    }
}
