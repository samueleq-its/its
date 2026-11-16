using System.Text.Json;

namespace BikeStores.Backend.Services
{
    public sealed record LoginRecord(string Email, DateTimeOffset LoggedInAt);

    public sealed class LoginHistoryStore
    {
        private readonly string _filePath;
        private readonly SemaphoreSlim _lock = new(1, 1);
        private readonly JsonSerializerOptions _jsonOptions = new(JsonSerializerDefaults.Web)
        {
            WriteIndented = true
        };

        public LoginHistoryStore(IWebHostEnvironment environment)
        {
            _filePath = Path.Combine(environment.ContentRootPath, "Data", "logins.json");
        }

        public async Task AddAsync(string email)
        {
            await _lock.WaitAsync();
            try
            {
                var records = await ReadAsync();
                records.Add(new LoginRecord(email, DateTimeOffset.UtcNow));
                await WriteAsync(records);
            }
            finally
            {
                _lock.Release();
            }
        }

        public async Task<IReadOnlyList<LoginRecord>> GetAllAsync()
        {
            await _lock.WaitAsync();
            try
            {
                return (await ReadAsync())
                    .OrderByDescending(record => record.LoggedInAt)
                    .ToList();
            }
            finally
            {
                _lock.Release();
            }
        }

        private async Task<List<LoginRecord>> ReadAsync()
        {
            if (!File.Exists(_filePath))
            {
                return new List<LoginRecord>();
            }

            await using var stream = File.OpenRead(_filePath);
            return await JsonSerializer.DeserializeAsync<List<LoginRecord>>(stream, _jsonOptions)
                ?? new List<LoginRecord>();
        }

        private async Task WriteAsync(List<LoginRecord> records)
        {
            Directory.CreateDirectory(Path.GetDirectoryName(_filePath)!);
            await using var stream = File.Create(_filePath);
            await JsonSerializer.SerializeAsync(stream, records, _jsonOptions);
        }
    }
}
