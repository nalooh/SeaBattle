namespace SeaBattle.API.ViewModels;

public record class CreateGameModel(string FirstPlayerName, string SecondPlayerName, int MapSize);
