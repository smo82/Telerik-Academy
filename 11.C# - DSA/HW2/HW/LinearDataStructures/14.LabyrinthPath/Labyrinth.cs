using System;
using System.Collections.Generic;

public class Labyrinth
{
    private const string START_POSITION_VALUE = "*";
    private const string OCCUPIED_CELL_VALUE = "x";
    private const string UNREACHABLE_CELL_VALUE = "u";
    private const string EMPTY_CELL_VALUE = "0";

    public Labyrinth(string[,] intialState)
    {
        this.Data = intialState;
    }

    public string[,] Data { get; private set; }

    public Position GetStartPosition()
    {
        for (int i = 0; i < this.Data.GetLength(0); i++)
        {
            for (int j = 0; j < this.Data.GetLength(1); j++)
            {
                if (this.Data[i, j] == START_POSITION_VALUE)
                {
                    return new Position(i, j);
                }
            }
        }

        throw new InvalidOperationException("Missing starting point in the labyrinth!");
    }

    public List<Position> GetFreeNeighbors(Position currentPosition)
    {
        int x = currentPosition.X;
        int y = currentPosition.Y;

        List<Position> result = new List<Position>();

        if (x > 0 && this.Data[x - 1, y] == EMPTY_CELL_VALUE)
        {
            result.Add(new Position(x - 1, y));
        }

        if (x < (this.Data.GetLength(0) - 1) && this.Data[x + 1, y] == EMPTY_CELL_VALUE)
        {
            result.Add(new Position(x + 1, y));
        }

        if (y > 0 && this.Data[x, y - 1] == EMPTY_CELL_VALUE)
        {
            result.Add(new Position(x, y - 1));
        }

        if (y < (this.Data.GetLength(1) - 1) && this.Data[x, y + 1] == EMPTY_CELL_VALUE)
        {
            result.Add(new Position(x, y + 1));
        }

        return result;
    }

    public void FillLabyrinthWave()
    {
        Queue<Position> pendingCells = new Queue<Position>();
        Position startPosition = this.GetStartPosition();

        List<Position> neighbors = this.GetFreeNeighbors(startPosition);
        foreach (Position neighbor in neighbors)
        {
            this.SetCellAtPosition(neighbor, "1");
            pendingCells.Enqueue(neighbor);
        }

        while (pendingCells.Count > 0)
        {
            Position currentCell = pendingCells.Dequeue();
            int currentCellValue = int.Parse(this.GetValueAtPosition(currentCell));
            int neighborCellValue = currentCellValue + 1;

            List<Position> currentCellNeighbors = this.GetFreeNeighbors(currentCell);

            foreach (Position neighbor in currentCellNeighbors)
            {
                this.SetCellAtPosition(neighbor, neighborCellValue.ToString());
                pendingCells.Enqueue(neighbor);
            }
        }

        this.FillEmptyCellsAsUnreachable();
    }

    public void PrintLabyrinthOnConsole()
    {
        for (int i = 0; i < this.Data.GetLength(0); i++)
        {
            for (int j = 0; j < this.Data.GetLength(1); j++)
            {
                Console.Write("{0,3} ", this.Data[i, j]);
            }

            Console.WriteLine();
        }
    }

    private void FillEmptyCellsAsUnreachable()
    {
        for (int i = 0; i < this.Data.GetLength(0); i++)
        {
            for (int j = 0; j < this.Data.GetLength(1); j++)
            {
                if (this.Data[i, j] == EMPTY_CELL_VALUE)
                {
                    this.Data[i, j] = UNREACHABLE_CELL_VALUE;
                }
            }
        }
    }

    private string GetValueAtPosition(Position position)
    {
        return this.Data[position.X, position.Y];
    }

    private void SetCellAtPosition(Position position, string value)
    {
        this.Data[position.X, position.Y] = value;
    }
}