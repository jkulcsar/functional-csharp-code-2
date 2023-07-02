﻿using System.Collections.Generic;

namespace Examples.Chapter7
{
   using static F;
   
   static class PopulationStatistics
   {
      record Person(decimal Earnings);

      static decimal AverageEarnings(this IEnumerable<Person> population)
         => population
            .Average(p => p.Earnings);

      static IEnumerable<Person> RichestQuartile(this List<Person> population)
         => population
            .OrderByDescending(p => p.Earnings)
            .Take(population.Count / 4);

      static decimal AverageEarningsOfRichestQuartile(List<Person> population)
         => population
            .OrderByDescending(p => p.Earnings)
            .Take(population.Count / 4)
            .Select(p => p.Earnings)
            .Average();

      [TestCase(ExpectedResult = 75000)]
      public static decimal AverageEarningsOfRichestQuartile()
         => SamplePopulation
            .RichestQuartile()
            .AverageEarnings();

      private static List<Person> SamplePopulation
         => Range(1, 8).Map(i => new Person(Earnings: i * 10000)).ToList();

      [TestCase(ExpectedResult = 75000)]
      public static decimal AverageEarningsOfRichestQuartile_()
      {
         var population = Range(1, 8)
            .Select(i => new Person(Earnings: i * 10000))
            .ToList();

         return PopulationStatistics
            .AverageEarningsOfRichestQuartile(population);
      }
   }
}