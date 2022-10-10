﻿using Fintech.Shared.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Json;

namespace Fintech.Client.Shared
{
    public partial class SecurityList : ComponentBase
    {
        [Inject]
        public ISecurityService? SecurityService { get; set; } = null;

        private List<Security> Securities = new();

        private static float ValueOfEachStock(Security security)
            => security.Price * security.StockesOwned;

        private float SumOfStocks()
        {
            float sumOfStocks = 0f;
            foreach (var security in Securities)
            {
                sumOfStocks += ValueOfEachStock(security);
            }
            return sumOfStocks;

        }

        private int NumberOfStocks()
        {
            int numberOfStocks = 0;
            foreach (var security in Securities)
            {
                numberOfStocks += security.StockesOwned;
            }
            return numberOfStocks;
        }

        protected override async Task OnInitializedAsync()
        {
            Securities = await SecurityService.GetSecurities();
        }

        private string CutTheText (string description)
        {
            const int maxLength = 20;

            var words = description.Split(' ');
            if (words.Length > maxLength)
            {
                var totalCharacters = 0;
                var summaryWords = new List<string>();

                foreach (var word in words)
                {
                    summaryWords.Add(word);

                    totalCharacters += word.Length + 1;
                    if (totalCharacters > maxLength)
                        break;
                }

                return String.Join(" ", summaryWords) + "...";
            }
            return description;
        }

        
    }
}
