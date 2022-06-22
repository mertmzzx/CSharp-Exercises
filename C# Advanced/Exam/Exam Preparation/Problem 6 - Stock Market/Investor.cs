using System;
using System.Collections.Generic;

namespace StockMarket
{
    public class Investor
    {
        public Investor(string fullName, string email, decimal money, string brokerName)
        {
            Portfolio = new List<Stock>();
            FullName = fullName;
            EmailAddress = email;
            MoneyToInvest = money;
            BrokerName = brokerName;
        }

        public List<Stock> Portfolio { get; set; }
        public int Count => Portfolio.Count;
        public string FullName { get; set; }
        public string EmailAddress { get; set; }
        public decimal MoneyToInvest { get; set; }
        public string BrokerName { get; set; }

        public void BuyStock(Stock stock)
        {
            if (stock.MarketCapitalization > 10000 && MoneyToInvest >= stock.PricePerShare)
            {
                Portfolio.Add(stock);
                MoneyToInvest -= stock.PricePerShare;
            }
        }

        public string SellStock(string companyName, decimal sellPrice)
        {
            foreach (var stock in Portfolio)
            {
                if (stock.CompanyName == companyName)
                {
                    if (sellPrice < stock.PricePerShare)
                    {
                        return $"Cannot sell {companyName}";
                    }
                    else
                    {
                        Portfolio.Remove(stock);
                        MoneyToInvest += sellPrice;

                        return $"{companyName} was sold.";
                    }
                }
            }

            return $"{companyName} does not exist.";
        }

        public Stock FindStock(string companyName)
        {
            foreach (var stock in Portfolio)
            {
                if (stock.CompanyName == companyName)
                {
                    return stock;
                }
            }

            return null;
        }

        public Stock FindBiggestCompany()
        {
            Stock biggestCompany = null;

            if (Count > 0)
            {
                decimal biggestCap = 0;

                foreach (var stock in Portfolio)
                {
                    if (stock.MarketCapitalization > biggestCap)
                    {
                        biggestCap = stock.MarketCapitalization;
                        biggestCompany = stock;
                    }
                }

                return biggestCompany;
            }

            return null;
        }

        public string InvestorInformation()
        {
            return $"The investor {FullName} with a broker {BrokerName} has stocks:" + string.Join(Environment.NewLine, Portfolio);
        }
    }
}
