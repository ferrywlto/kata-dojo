namespace Tetris.Model;

public interface IShapeRenderer 
{
    bool CanGoDown(int[,] board, int row, int col);
    void GoDown(int[,] board, int row, int col);
    bool CanGoLeft(int[,] board, int row, int col);
    void GoLeft(int[,] board, int row, int col);
    void GoRight(int[,] board, int row, int col);
    bool CanGoRight(int[,] board, int row, int col);
    bool CanRotateLeft(int[,] board, int row, int col);
    void RotateLeft(int[,] board, int row, int col);
    bool CanRotateRight(int[,] board, int row, int col);
    void RotateRight(int[,] board, int row, int col);
}