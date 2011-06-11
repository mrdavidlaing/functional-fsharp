﻿namespace CIAPI
{
    public class Market
    {
        public Market(int marketId, string marketName)
        {
            MarketId = marketId;
            Name = marketName;
        }

        public int MarketId { get; set; }   
        public string Name { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }
}
