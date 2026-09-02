namespace BlazorApp_WebApp_Server_Global_Include.Code
{
    public class SharedDiceService
    {
        public int? LastRoll { get; private set; }
        public string? LastPlayer { get; private set; }
        public DateTime? RolledAt { get; private set; }

        // Událost, kterou budou komponenty poslouchat
        public event Action? OnChange;

        public void BroadcastRoll(string player, int value)
        {
            LastPlayer = string.IsNullOrWhiteSpace(player) ? "Anonym" : player;
            LastRoll = value;
            RolledAt = DateTime.Now;

            // Upozorníme všechny přihlášené klienty / komponenty
            NotifyStateChanged();
        }

        private void NotifyStateChanged() => OnChange?.Invoke();
    }
}
