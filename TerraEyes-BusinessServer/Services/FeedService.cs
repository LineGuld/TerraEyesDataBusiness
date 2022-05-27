using System.Collections.Generic;

namespace TerraEyes_BusinessServer.Services
{
    public class FeedService
    {
        private static FeedService _instance;

        //Disse requests er EUI på de terraria hvor en brugere har anmodet om at der fodres.
        private readonly List<string> _unsentRequests;
        private readonly List<string> _sentRequests;
        private readonly Dictionary<string, int> _waitList;

        private FeedService()
        {
            _unsentRequests = new List<string>();
            _sentRequests = new List<string>();
            _unsentRequests.Add("TESTING");
            _waitList = new Dictionary<string, int>();
        }

        public List<string> GetUnsentRequests()
        {
            return _unsentRequests;
        }

        public bool HasNewRequests()
        {
            return _unsentRequests.Count != 0;
        }

        public void UpdateSentRequests()
        {
            _sentRequests.AddRange(_unsentRequests);

            foreach (var request in _unsentRequests)
            {
                _waitList.Add(request, 4);
            }

            _unsentRequests.Clear();
        }

        public bool HasRequestedFeeding(string eui)
        {
            return _sentRequests.Contains(eui);
        }

        public int DecrementWaitTime(string eui)
        {
            _waitList[eui] -= 1;
            return _waitList[eui];
        }

        public void RemoveVerifiedRequest(string verifiedRequest)
        {
            _sentRequests.Remove(verifiedRequest);
            _waitList.Remove(verifiedRequest);
        }

        public void RequestFeeding(string eui)
        {
            if (!_unsentRequests.Contains(eui))
                _unsentRequests.Add(eui);
        }

        public static FeedService GetInstance()
        {
            _instance ??= new FeedService();

            return _instance;
        }
    }
}