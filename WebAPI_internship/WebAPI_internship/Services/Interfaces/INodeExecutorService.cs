namespace WebAPI_internship.Services.Interfaces
{
    public interface INodeExecutorService
    {
        public Task<Dictionary<Guid, Dictionary<string, object>>> ExecuteAsync(string jsonData);
    }
}
