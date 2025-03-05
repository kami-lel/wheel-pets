public class PointCoinManager
{
    private readonly PlayerData playerData;
    private const int MINIGAME_WIN_COIN = 50; // coin gained by winning a minigame
    private const int MINIGAME_LOSS_COIN = 10; // coin gained by winning a minigame

    public PointCoinManager(PlayerData playerData)
    {
        this.playerData = playerData;
    }

    public int WinMinigame()
    {
        playerData.minigameCoin += MINIGAME_WIN_COIN;
        return MINIGAME_WIN_COIN;
    }

    public int LoseMinigame()
    {
        playerData.minigameCoin += MINIGAME_LOSS_COIN;
        return MINIGAME_LOSS_COIN;
    }
}
