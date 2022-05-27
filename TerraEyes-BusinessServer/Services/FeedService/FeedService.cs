using System.Collections.Generic;

namespace TerraEyes_BusinessServer.Services.FeedService
{
    public class FeedService
    {
        private static FeedService _instance;
        
        private readonly List<string> _unsentRequests;
        private readonly List<string> _sentRequests;

        private FeedService()
        {
            _unsentRequests = new List<string>();
            _sentRequests = new List<string>();
        }

        public List<string> GetUnsentRequests()
        {
            return _unsentRequests;
        }

        public List<string> GetSentRequests()
        {
            return _sentRequests;
        }

        public bool HasNewRequests()
        {
            return _unsentRequests.Count != 0;
        }

        public void UpdateSentRequests(List<string> sentRequests)
        {
            _sentRequests.AddRange(sentRequests);
            foreach (var request in sentRequests)
            {
                _unsentRequests.Remove(request);
            }
        }

        public void RemoveVerifiedRequests(List<string> verifiedRequests)
        {
            foreach (var request in verifiedRequests)
            {
                _sentRequests.Remove(request);
            }
        }

        public static FeedService GetInstance()
        {
            _instance ??= new FeedService();

            return _instance;
        }
    }
}