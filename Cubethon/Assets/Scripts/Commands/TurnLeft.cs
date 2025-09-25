public class TurnLeft: Command  
{
    private PlayerMovement _playerMovement;
    public TurnLeft(PlayerMovement playerMovement)
    {
        _playerMovement = playerMovement;
    }

    public void execute()
    {
        _playerMovement.Turn(PlayerMovement.Direction.Left);
    }
}
 