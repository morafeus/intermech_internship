namespace WebAPI_internship.Services.Interfaces
{
    public interface INodeExecutorService
    {
        public Task<object> ExecuteAsync(string jsonData);
    }
}
