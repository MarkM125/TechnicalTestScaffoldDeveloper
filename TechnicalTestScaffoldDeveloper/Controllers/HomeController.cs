using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TechnicalTestScaffoldDeveloper.Models;

namespace TechnicalTestScaffoldDeveloper.Controllers
{
    public class HomeController : Controller
    {
        public static Models.CardsModel Cards;

        //[HttpGet]
        public IActionResult Index(int data = 0)
        {
            if (data.Equals(0))
            {
                Cards = new Models.CardsModel();
            }
            Cards.Count++;
            switch (Cards.Count)
            {
                case 1:
                    return View(Cards);
                case 6:
                    Cards = CardsModel.AddCard(Cards, data);
                    ScoreModel Results = ScoreModel.CalculateScore(Cards.Cards);
                    if (Results.Valid)
                    {
                        return View("Results", Results);
                    }
                    else
                    {
                        return View("Invalid", Results);
                    }
                default:
                    Cards = CardsModel.AddCard(Cards, data);
                    return View(Cards);
            }
        }

        public IActionResult FindZeroScore()
        {
            return View("CardList",ScoreModel.FindScore());
        }

        public IActionResult CountScoresThatEqualValues()
        {
            return View("NumberOfCardSets", ScoreModel.CountSumsThatEqualValues());
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
