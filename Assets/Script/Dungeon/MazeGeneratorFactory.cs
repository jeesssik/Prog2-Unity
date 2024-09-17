using UnityEngine;

public class MazeGeneratorFactory : IMazeGeneratorFactory
{
    public IMazeGenerator CreateMazeGenerator(Vector2 dungeonSize, int startPos)
    {
        return new MazeGenerator(dungeonSize, startPos);
    }
}
