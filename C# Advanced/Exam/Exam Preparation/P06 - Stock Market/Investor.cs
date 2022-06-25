using System;
using System.Collections.Generic;
using System.Text;

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
            var company = Portfolio.Find(company => company.CompanyName == companyName);

            if (company == null)
            {
                return $"{companyName} does not exist.";
            }
            if (company.PricePerShare > sellPrice)
            {
                return $"Cannot sell {companyName}.";
            }

            Portfolio.Remove(company);
            MoneyToInvest += sellPrice;
            return $"{companyName} was sold.";
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
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"The investor {FullName} with a broker {BrokerName} has stocks:");
            sb.AppendLine(string.Join(Environment.NewLine, Portfolio));

            return sb.ToString().TrimEnd();
        }
    }
}
