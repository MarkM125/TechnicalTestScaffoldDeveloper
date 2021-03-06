﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TechnicalTestScaffoldDeveloper.Models
{
    //public interface CardsModel
    //{
    //    List<int> Cards { get; set; }
    //    int Count { get; set; }
    //    string CardNumberRequired { get; set; }
    //    //CardsModel()
    //    //{
    //    //    this.CardNumberRequired = "first";
    //    //    this.Count = 1;
    //    //}
    //}
    public class CardsModel
    {
        public List<int> CardButtons {get; }
        public List<int> Cards { get; set; }
        public int Count { get; set; }
        public string CardNumberRequired { get; set; }
        public CardsModel()
        {
            this.CardNumberRequired = "first";
            this.Count = 0;
            this.Cards = new List<int>();
            this.CardButtons = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
        }

        public static Models.CardsModel AddCard(Models.CardsModel data, int card)
        {
            data.Cards.Add(card);
            switch (data.Count)
            {
                case 2:
                    data.CardNumberRequired = "second";
                    break;
                case 3:
                    data.CardNumberRequired = "third";
                    break;
                case 4:
                    data.CardNumberRequired = "fourth";
                    break;
                case 5:
                    data.CardNumberRequired = "fith";
                    break;
            }

            return data;
        }

        public static Models.CardsModel AddCard(Models.CardsModel data, List<int> cards)
        {
            data.Cards.AddRange(cards);
            return data;
        }


    }


}
