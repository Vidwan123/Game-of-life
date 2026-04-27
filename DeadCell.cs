namespace GameOfLifeA24.Cells;

internal sealed class DeadCell : Cell
{
    public DeadCell(int x, int y) : base(x, y) { }

    public override bool IsAlive() => false;

    public override Cell NextState(int aliveNeighbors)
    {
        // Birth: exactly 3 neighbors → becomes alive
        if (aliveNeighbors == 3)
            return new AliveCell(X, Y);

        // Stays dead
        return new DeadCell(X, Y);
    }
}
