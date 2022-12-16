namespace LolChallenges.Server.Interfaces.Repositories
{
    public interface IRiotRepository
    {
        Task<HttpResponseMessage> HandleRequestAsync(string endpointSuffix);
    }
}