﻿namespace BrokerService.Services.Models
{
    public class TokenModel
    {
        public bool Authenticated { get; set; }
        public string Created { get; set; }
        public string Expiration { get; set; }
        public string AccessToken { get; set; }
    }
}
