public class TurnRight: Command  
{
    private PlayerMovement _playerMovement;
    public TurnRight(PlayerMovement playerMovement)
    {
        _playerMovement = playerMovement;
    }

    public void execute()
    {
        _playerMovement.Turn(PlayerMovement.Direction.Right);
    }
}
 