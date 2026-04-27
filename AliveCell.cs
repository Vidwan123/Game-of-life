namespace GameOfLifeA24.Cells;

internal sealed class AliveCell : Cell
{
    public AliveCell(int x, int y) : base(x, y) { }

    public override bool IsAlive() => true;

    public override Cell NextState(int aliveNeighbors)
    {
        // Survival: 2 or 3 neighbors → stays alive
        if (aliveNeighbors == 2 || aliveNeighbors == 3)
            return new AliveCell(X, Y);

        // Death by isolation (<2) or overcrowding (>3)
        return new DeadCell(X, Y);
    }
}
